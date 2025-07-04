using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows;
using System.Windows.Input;

namespace Classes
{
	public partial class Lista<T> : ObservableCollection<T>, IAggiornata
	{
		// EVENTI
		public event Action<int, string> Completato;
		private void OnCompletato(int v, string m = "") => Completato?.Invoke(v, m);

		public event Action Aggiornata;
		private void OnAggiornata() => Application.Current.Dispatcher.Invoke(() => Aggiornata?.Invoke());

		// CAMPI
		public IMongoCollection<T> DB;
		private readonly string Ordinamento;
		private string nome;

		// COSTRUTTORE
		public Lista(string n, IMongoCollection<T> dB, string sort = "{}")
		{
			nome = n;
			DB = dB;
			Ordinamento = sort;
			LanciaChangeStream();
		}

		// Controllo modifiche al DataBase
		public void LanciaChangeStream()
		{
			Task ChangeStream = new(() => {
				try
				{
					var cursor = DB.Watch();
					var enumerator = cursor.ToEnumerable().GetEnumerator();
					while (enumerator.MoveNext()) { Carica(); }
				}
				catch (Exception)
				{
					MessageBox.Show("Errore connessione a ChangeStream...", nome);
				}
			});
			ChangeStream.Start();
		}

		public Lista()
		{
			Ordinamento = "{}";
		}

		public void SalvaJson(string nomefile)
		{
			System.IO.File.WriteAllText(nomefile, JsonSerializer.Serialize(Items, JsonOptions.Options));
		}

		public void CaricaJson(string nomefile)
		{
			if (System.IO.File.Exists(nomefile))
			{
				try
				{
					Items.Clear();
					string Jstr = System.IO.File.ReadAllText(nomefile);
					var ListaRisultato = JsonSerializer.Deserialize<Lista<T>>(Jstr);
					foreach (T elemento in ListaRisultato)
					{
						Items.Add(elemento);
					}
				}
				catch (Exception ex)
				{
					_ = MessageBox.Show(nomefile + ex.Message);
				}
			}
		}

		public void Carica(int avanzamento = 0)
		{
			try
			{
				var elenco = DB.Find(new BsonDocument()).Sort(Ordinamento).ToList();
				Items.Clear();
				foreach (T elemento in elenco)
				{
					Items.Insert(0, elemento);
				}
				OnAggiornata();

				if (avanzamento > 0) { OnCompletato(avanzamento); }
			}
			catch (Exception)
			{
				MessageBox.Show($"Errore connessione a Database.", nome);
			}

		}

		public async void CaricaAsync(int avanzamento = 0)
		{
			try
			{
				var elenco = await DB.Find(new BsonDocument()).Sort(Ordinamento).ToListAsync();
				Items.Clear();
				foreach (T elemento in elenco)
				{
					Items.Insert(0, elemento);
				}
				OnAggiornata();
				if (avanzamento > 0) { OnCompletato(avanzamento, nome); }
			}
			catch (Exception)
			{
				MessageBox.Show($"Errore connessione a Database.", nome);
			}

		}

		public void SalvaTutto()
		{
			DB.DeleteMany(new BsonDocument());
			var TempItems = Items.Reverse();
			DB.InsertMany(TempItems);
		}

		public void AggiungiElemento(object elemento)
		{
			try
			{
				Mouse.OverrideCursor = Cursors.Wait;
				DB.InsertOne((T)elemento);
				Carica();
				OnCompletato(100, "Elemento aggiunto");
				Mouse.OverrideCursor = Cursors.Arrow;
			}
			catch (Exception)
			{
				MessageBox.Show("Errore connessione a Database. Elemento non salvato... ");
			}

		}

		public void AggiungiMolti(object elementi)
		{
			Mouse.OverrideCursor = Cursors.Wait;
			DB.InsertMany((IEnumerable<T>)elementi);
			Carica();
			OnCompletato(100, "Elementi aggiunti");
			Mouse.OverrideCursor = Cursors.Arrow;
		}

		public void AggiornaElemento(object elemento, bool Ricarica = true)
		{
			Mouse.OverrideCursor = Cursors.Wait;
			var filtro = Builders<T>.Filter.Eq<ObjectId>("_id", ObjectId.Parse(((Mongo)elemento).Id));

			var result = DB.ReplaceOne(filtro, (T)elemento);

			if (result.ModifiedCount == 0)
			{
				OnCompletato(0, "Non aggiornato");
			}
			else
			{
				if (Ricarica) { Carica(); }
				OnCompletato(100, "Elemento aggiornato");
			}
			Mouse.OverrideCursor = Cursors.Arrow;
		}

		public void CancellaElemento(object elemento)
		{
			Mouse.OverrideCursor = Cursors.Wait;
			var filtro = Builders<T>.Filter.Eq<ObjectId>("_id", ObjectId.Parse(((Mongo)elemento).Id));
			var result = DB.DeleteOne(filtro);
			if (result.DeletedCount == 0)
			{
				MessageBox.Show("Qualcosa è andato storto! nessun elemento cancellato.");
			}
			else
			{
				Carica();
				OnCompletato(100, "Elemento cancellato");
			}
			Mouse.OverrideCursor = Cursors.Arrow;
		}
	}
}
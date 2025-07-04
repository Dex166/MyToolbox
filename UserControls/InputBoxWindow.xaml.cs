using System.Windows;

namespace UserControls
{
	public partial class InputBoxWindow : Window
	{
		public string Text { get; set; } = "";
		public string Messaggio { get; set; } = "";

		public InputBoxWindow(string message)
		{
			InitializeComponent();
			Messaggio = message;
			DataContext = this;
			TextBox.Focus();
		}

		private void Button_OK_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void TextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
		{
			if (e.Key == System.Windows.Input.Key.Enter) Close();
		}
	}
}

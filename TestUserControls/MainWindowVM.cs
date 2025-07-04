using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using UserControls;

namespace TestUserControls
{
	internal partial class MainWindowVM :ObservableObject
	{
		
		[ObservableProperty] string cerca;

		[RelayCommand]
		void UserButtonClick(object o)
		{
			MessageBox.Show($"Command eseguito!{o.ToString()}");
		}

        [RelayCommand]
        void Input(object o)
        {
            Cerca = InputBox.ShowDialog("domandami qualcosa");
        }

        [RelayCommand]
        void BLInput(object o)
        {
            Cerca = BL.Controls.InputBox.ShowDialog("domandami qualcosa");
        }
    }
}

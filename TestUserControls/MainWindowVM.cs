using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using BL.Controls;

namespace TestUserControls
{
	internal partial class MainWindowVM :ObservableObject
	{
		
		[ObservableProperty] string cerca;

        [RelayCommand]
        void BLInput(object o)
        {
            Cerca = BL.Controls.InputBox.ShowDialog("domandami qualcosa");
        }
    }
}

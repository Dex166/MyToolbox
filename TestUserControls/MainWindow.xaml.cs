using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace TestUserControls
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summry>

   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         InitializeComponent();
         DataContext = new MainWindowVM();
         //image.Source = new BitmapImage(new Uri("pack://application:,,,/UserControls;component/Image/inputbox.ico"));

		}
   }
}

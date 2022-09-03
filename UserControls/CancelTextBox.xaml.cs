using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UserControls
{
    public partial class CancelTextBox : UserControl
    {
        public CancelTextBox()
        {
            InitializeComponent();
            DataContext = this;
        }

        public string? Title { get; set; }

        public readonly DependencyProperty? TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(CancelTextBox));
        public String? Text
        {
            get => (string?)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }


        private void Cancella_Click(object sender, RoutedEventArgs e)
        {
            Text = "";
        }

        private void Escape_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape) Text = "";
        }
    }
}

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BL.Controls
{
    public class CancelTextBox : TextBox
    {
        static CancelTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CancelTextBox), new FrameworkPropertyMetadata(typeof(CancelTextBox)));
        }
        public static readonly DependencyProperty? LabelProperty = DependencyProperty.Register("Label", typeof(string), typeof(CancelTextBox));
        public string? Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public static readonly RoutedCommand ClearCommand = new(nameof(ClearCommand), typeof(CancelTextBox));

        public CancelTextBox()
        {
            CommandBindings.Add(new CommandBinding(ClearCommand, OnClearCommandExecuted));
        }

        private void OnClearCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Text = "";
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            base.OnPreviewKeyDown(e);
            if (e.Key == Key.Escape)
            {
                if (ClearCommand.CanExecute(null, this))
                {
                    ClearCommand.Execute(null, this);
                    e.Handled = true;
                }
            }
        }
    }
}
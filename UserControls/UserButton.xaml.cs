using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace UserControls
{
    public partial class UserButton : UserControl
    {
        public UserButton()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty? TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(UserButton));
        public string? Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        //public static readonly DependencyProperty? ImageProperty = DependencyProperty.Register("Image", typeof(string), typeof(UserButton));
        //public string? Image
        //{
        //    get => (string)GetValue(ImageProperty);
        //    set => SetValue(ImageProperty, value);
        //}

        public static readonly DependencyProperty? IconProperty = DependencyProperty.Register("Icon", typeof(string), typeof(UserButton));
        public string? Icon
        {
            get => (string)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty? FillIconProperty = DependencyProperty.Register("FillIcon", typeof(string), typeof(UserButton));
        public string? FillIcon
        {
            get => (string)GetValue(FillIconProperty);
            set => SetValue(FillIconProperty, value);
        }

        public static readonly DependencyProperty? FillIconColorProperty = DependencyProperty.Register("FillIconColor", typeof(Brush), typeof(UserButton));
        public Brush? FillIconColor
        {
            get => (Brush?)GetValue(FillIconColorProperty);
            set => SetValue(FillIconColorProperty, value);
        }

        public static readonly DependencyProperty? IconColorProperty = DependencyProperty.Register("IconColor", typeof(Brush), typeof(UserButton));
        public Brush? IconColor
        {
            get => (Brush?)GetValue(IconColorProperty);
            set => SetValue(IconColorProperty, value);
        }

        public event EventHandler? Click;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Click?.Invoke(sender, e);
        }

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(UserButton), new UIPropertyMetadata(null));
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register("CommandParameter", typeof(object), typeof(UserButton), new UIPropertyMetadata(null));
        public ICommand CommandParameter
        {
            get { return (ICommand)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
    }
}
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BL.Controls
{
    public class IconButton : Button
    {
        static IconButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IconButton), new FrameworkPropertyMetadata(typeof(IconButton)));
        }

        public static readonly DependencyProperty? TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(IconButton));
        public string? Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly DependencyProperty? IconProperty = DependencyProperty.Register("Icon", typeof(string), typeof(IconButton));
        public string? Icon
        {
            get => (string)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty? IconColorProperty = DependencyProperty.Register("IconColor", typeof(Brush), typeof(IconButton));
        public Brush? IconColor
        {
            get => (Brush?)GetValue(IconColorProperty);
            set => SetValue(IconColorProperty, value);
        }

        public double IconColumn => ((Height - 30) / 2) + 30;

    }
}
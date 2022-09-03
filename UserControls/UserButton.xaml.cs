﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace UserControls
{
    public partial class UserButton : UserControl
    {
        public UserButton()
        {
            InitializeComponent();
            Title = "Prova";
            Image = "";
            DataContext =this;
        }

        public string? Title { get; set; }
        
        public string? Image { get; set; }

        public string? FillImage { get; set; }

        public readonly DependencyProperty? FillColorProperty = DependencyProperty.Register("FillColor", typeof( Brush), typeof(UserButton));
        public Brush? FillColor
        {
            get => (Brush?)GetValue(FillColorProperty); 
            set => SetValue(FillColorProperty, value);
        }


        public event EventHandler<EventArgs>? Click;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Click?.Invoke(sender, e);
        }
    }
}
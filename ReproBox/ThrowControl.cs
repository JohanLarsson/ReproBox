namespace ReproBox
{
    using System;
    using System.Windows;
    using System.Windows.Controls;

    public class ThrowControl : Control
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            nameof(Value),
            typeof(object),
            typeof(ThrowControl),
            new PropertyMetadata(default(object), OnValueChanged));

        public object Value
        {
            get { return (object)this.GetValue(ValueProperty); }
            set {  this.SetValue(ValueProperty, value); }
        }

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new Exception();
        }
    }
}

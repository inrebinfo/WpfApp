using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Wpf.ViewModels.Samples
{
    public class ConverterViewModel : ViewModel
    {
        #region Bool property
        public bool Bool
        {
            get { return (bool)GetValue(BoolProperty); }
            set { SetValue(BoolProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Bool.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BoolProperty =
            DependencyProperty.Register("Bool", typeof(bool), typeof(ConverterViewModel), new PropertyMetadata(true));
        #endregion

        #region Text property
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(ConverterViewModel), new PropertyMetadata(string.Empty));
        #endregion

        public string Color
        {
            get
            {
                return "#FF00AA00";
            }
        }
    }
}

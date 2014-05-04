using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Wpf.ViewModels.Samples
{
    public class DataBindingViewModel : ViewModel
    {
        private string _text = "Simple text binding with INotifyPropertyChanged";
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                if (_text != value)
                {
                    _text = value;
                    OnPropertyChanged("Text");
                }
            }
        }

        public string TextDP
        {
            get { return (string)GetValue(TextDPProperty); }
            set { SetValue(TextDPProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextDP.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextDPProperty =
            DependencyProperty.Register("TextDP", typeof(string), typeof(DataBindingViewModel), new PropertyMetadata("Simple text binding with Dependency Property"));


        public IEnumerable Values
        {
            get
            {
                return new[] 
                {
                    new { IsChecked = true, Text="Kawasaky ZZR 1100"},
                    new { IsChecked = false, Text="Yamaha R1"},
                    new { IsChecked = false, Text="Suzuki ER 5"},
                    new { IsChecked = true, Text="BMW GS 1200"},
                    new { IsChecked = true, Text="Suzuki GSX 1000"},
                };
            }
        }
    }
}

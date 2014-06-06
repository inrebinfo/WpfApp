using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Wpf.ViewModels;

namespace Wpf
{
    /// <summary>
    /// Interaktionslogik für InvoiceForm.xaml
    /// </summary>
    public partial class InvoiceForm : Window
    {
        public InvoiceForm(InvoiceEditViewModel model)
        {
            InitializeComponent();

            this.DataContext = model;
            model.PropertyChanged += model_PropertyChanged;
        }

        public InvoiceEditViewModel ViewModel
        {

            get
            {
                return (InvoiceEditViewModel)this.DataContext;
            }
        }

        void model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Close")
            {
                if (this.ViewModel.Close == true)
                {
                    this.Close();
                }
            }
        }
    }
}

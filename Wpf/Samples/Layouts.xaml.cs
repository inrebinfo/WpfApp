﻿using System;
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
using Wpf.ViewModels.Samples;

namespace Wpf.Samples
{
    /// <summary>
    /// Interaction logic for Layouts.xaml
    /// </summary>
    public partial class Layouts : Window
    {
        public Layouts()
        {
            InitializeComponent();

            this.DataContext = new LayoutsViewModel();
        }
    }
}

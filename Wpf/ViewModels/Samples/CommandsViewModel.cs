using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Wpf.ViewModels.Samples
{
    public class CommandsViewModel : ViewModel
    {
        private bool _enableMyCommand = false;
        public bool EnableMyCommand
        {
            get {
                return _enableMyCommand;
            }
            set
            {
                if (_enableMyCommand != value)
                {
                    _enableMyCommand = value;
                    OnPropertyChanged("EnableMyCommand");
                    if (_MyCommand != null) _MyCommand.OnCanExecuteChanged();
                }
            }            
        }

        private ICommandViewModel _MyCommand;
        public ICommandViewModel MyCommand
        {
            get
            {
                if (_MyCommand == null)
                {
                    _MyCommand = new SimpleCommandViewModel(
                        "My Command",
                        "My command in this sample application",
                        () =>
                        {
                            MessageBox.Show("Hello from my command", "Hello!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        },
                        () => EnableMyCommand);
                }
                return _MyCommand;
            }
        }
    }
}

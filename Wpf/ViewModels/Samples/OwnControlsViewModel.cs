using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Wpf.ViewModels.Samples
{
    public class OwnControlsViewModel : ViewModel
    {
        private ICommandViewModel _SearchCommand;
        public ICommandViewModel SearchCommand
        {
            get
            {
                if (_SearchCommand == null)
                {
                    _SearchCommand = new SimpleParameterCommandViewModel<string>(
                        "Search",
                        "",
                        (p) =>
                        {
                            MessageBox.Show(p, "Search for...", MessageBoxButton.OK, MessageBoxImage.Information);
                        });
                }
                return _SearchCommand;
            }
        }
    }
}

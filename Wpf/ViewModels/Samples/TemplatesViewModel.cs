using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Wpf.ViewModels.Samples
{
    public abstract class PetViewModel : ViewModel
    {
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(PetViewModel));
    }

    public class CatViewModel : PetViewModel
    {
    }

    public class DogViewModel : PetViewModel
    {
    }

    public class TemplatesViewModel : ViewModel
    {
        public IEnumerable<PetViewModel> Items
        {
            get
            {
                return new PetViewModel[] 
                {
                    new CatViewModel()  { Name = "Moritz" },
                    new DogViewModel()  { Name = "Strolchi" },
                    new DogViewModel()  { Name = "Spike" },
                    new CatViewModel()  { Name = "Billy" },
                };
            }
        }
    }
}

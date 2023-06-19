using EFCore_MPS.Core;
using EFCore_MPS.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EFCore_MPS.ViewModel
{
    class MainViewModel:ObservableObject
    {
        public RelayCommand<string> ContentNavigationCommand { get; set; }
        public Page ContentPage { get; set; }

        private Uri _contentUri;
        public Uri ContentUri { get { return _contentUri; } set { _contentUri = value; OnPropertyChanged(); } }
        public MainViewModel() 
        {
            ContentNavigationCommand = new RelayCommand<string>(SwitchPage);
            
        }

        private void SwitchPage(string pageName)
        {
            switch (pageName)
            {
                case "RegisterMpsPage":
                    ContentUri = new Uri("/View/RegisterMps.xaml", UriKind.Relative);
                    break;
                case "DisposalPage":
                    break;
            }
        }


    }
}

using EFCore_MPS.Core;
using EFCore_MPS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_MPS.ViewModel
{
    class RegisterViewModel:ObservableObject
    {
        public RelayCommand<object> OpenRegistrationWindowCommand { get; set; }
        public RelayCommand<object> SaveChangesCommand { get; set; }
        IDialogService _dialogService = new DialogService();
        RegistrationMpsView _registrationMpsView;
        string dialogResult;
        public ObservableCollection<RegistrationMpsView> RegisterMps { get; set; }

        public RegisterViewModel()
        {
            _registrationMpsView= new RegistrationMpsView();
            OpenRegistrationWindowCommand = new RelayCommand<object>(ExecuteShowDialog);

            using (var dbContext = new MpsContext())
            {
                RegisterMps = new ObservableCollection<RegistrationMpsView>(dbContext.RegistrationMpsViews.ToList());
            }

            
            
        }

        void ExecuteShowDialog(Object obj)
        {
            _dialogService.ShowDialog("CreateRegisterMps", (result,mpsToRegister) =>
            {
                dialogResult = result.ToString();
                if (dialogResult == "True")
                {
                    _registrationMpsView = (RegistrationMpsView)mpsToRegister;
                }
            });
        }
    }
}

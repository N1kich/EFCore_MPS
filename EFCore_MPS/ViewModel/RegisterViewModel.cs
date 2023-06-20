using EFCore_MPS.Core;
using EFCore_MPS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_MPS.ViewModel
{
    class RegisterViewModel:ObservableObject
    {
        public RelayCommand<object> OpenRegistrationWindowCommand { get; set; }
        IDialogService _dialogService = new DialogService();
        RegistrationMpsView _registrationMpsView;
        string dialogReuslt;

        public RegisterViewModel()
        {
            _registrationMpsView= new RegistrationMpsView();
            OpenRegistrationWindowCommand = new RelayCommand<object>(ExecuteShowDialog);
        }

        void ExecuteShowDialog(Object obj)
        {
            _dialogService.ShowDialog("CreateRegisterMps", (result,mpsToRegister) =>
            {
                dialogReuslt = result.ToString();
                _registrationMpsView = (RegistrationMpsView)mpsToRegister;
            });
        }
    }
}

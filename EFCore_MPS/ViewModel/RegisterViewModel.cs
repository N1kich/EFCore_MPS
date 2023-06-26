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
        public RelayCommand OpenRegistrationWindowCommand { get; set; }
        public RelayCommand<object> SaveChangesCommand { get; set; }
        IDialogService _dialogService = new DialogService();
        RegistrationMpsView _registrationMpsView;
        public ObservableCollection<RegistrationMpsView> RegisterMps { get; set; }

        public RegisterViewModel()
        {
            _registrationMpsView= new RegistrationMpsView();
            OpenRegistrationWindowCommand = new RelayCommand(ExecuteShowDialog);

            using (var dbContext = new MpsContext())
            {
                RegisterMps = new ObservableCollection<RegistrationMpsView>(dbContext.RegistrationMpsViews.ToList());
            }

            
            
        }

        void ExecuteShowDialog()
        {
            _dialogService.ShowDialog("CreateRegisterMps", (result,mpsToRegister) =>
            {
                
                if (result.ToString() == "True")
                {
                    RegisterMps.Add((RegistrationMpsView)mpsToRegister);
                    //using (var dbContext = new MpsContext())
                    //{
                    //    dbContext.RegistrationMpsViews.Add((RegistrationMpsView)mpsToRegister);
                    //    RegisterMps.Add((RegistrationMpsView)mpsToRegister);
                    //    dbContext.SaveChanges();
                    //}
                }
            });
        }
    }
}

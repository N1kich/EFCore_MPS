using EFCore_MPS.Core;
using EFCore_MPS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EFCore_MPS.ViewModel
{
    class RegisterViewModel:ObservableObject
    {
        public RelayCommand OpenRegistrationWindowCommand { get; set; }
        public RelayCommand<object> SaveChangesCommand { get; set; }

        public RelayCommand SearchMpsCommand { get; set; }

        IDialogService _dialogService = new DialogService();

        public List<string> MpsTypeList { get; set; }
        
        public List<string> MpsMeasureList { get; set; }
        public List<string> SupplierList { get; set; }

        RegistrationMpsView _selectedMps;

        string _mpsToFind;
        public string MpsToFind
        {
            get { return _mpsToFind; }
            set { _mpsToFind = value; OnPropertyChanged(); }
        }

        ObservableCollection<RegistrationMpsView> _registerMps;
        public ObservableCollection<RegistrationMpsView> RegisterMps
        {
            get { return _registerMps; }
            set { _registerMps = value; OnPropertyChanged(); }
        }

        public RegisterViewModel()
        {
            _selectedMps= new RegistrationMpsView();

            OpenRegistrationWindowCommand = new RelayCommand(ExecuteShowDialog);
            SearchMpsCommand = new RelayCommand(SearchMps);

            using (var dbContext = new MpsContext())
            {
                _registerMps = new ObservableCollection<RegistrationMpsView>(dbContext.RegistrationMpsViews.ToList());
                MpsTypeList = dbContext.TypeMps.Select(x => x.TypeMps).ToList();
                MpsMeasureList = dbContext.UnitMeasurementsMps.Select(x => x.NameMeasurements).ToList();
                SupplierList = dbContext.SupplierMps.Select(x => x.NameCompany).ToList();
            }

        }

        void ExecuteShowDialog()
        {
            _dialogService.ShowDialog("CreateRegisterMps", (result,mpsToRegister) =>
            {
                
                if (result.ToString() == "True")
                {
                    
                    using (var dbContext = new MpsContext())
                    {
                        IncrementMpsId((RegistrationMpsView)mpsToRegister);

                        dbContext.RegistrationMpsViews.Add((RegistrationMpsView)mpsToRegister);
                        dbContext.SaveChanges();

                        _registerMps.Add(dbContext.RegistrationMpsViews.OrderBy(x => x.IdMps).Last());
                    }
                }
            });
        }


        // To prevent ConcurrencyException increment mps_id manually
        void IncrementMpsId(RegistrationMpsView newMps)
        {
            newMps.IdMps = ++_registerMps.Last().IdMps;
        }

        void SearchMps()
        {
            var foundMps = _registerMps.Where(x => x.CodeMps == _mpsToFind).ToList();
            
            _registerMps = new ObservableCollection<RegistrationMpsView>(foundMps);

            
        }

    }
}

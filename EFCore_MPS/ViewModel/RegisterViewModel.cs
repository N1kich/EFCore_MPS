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
        public RelayCommand UpdateMpsCommand { get; set; }

        public RelayCommand SearchMpsCommand { get; set; }

        public RelayCommand DisplayAllMpsCommand { get; set; }

        readonly IDialogService _dialogService = new DialogService();

        public List<string> MpsTypeList { get; set; }
        
        public List<string> MpsMeasureList { get; set; }
        public List<string> SupplierList { get; set; }

        RegistrationMpsView _selectedMps;
        public RegistrationMpsView SelectedMps
        {
            get { return _selectedMps; }
            set { _selectedMps = value; OnPropertyChanged(); }
        }

        string _mpsCodeToFind;
        public string MpsCodeToFind
        {
            get { return _mpsCodeToFind; }
            set { _mpsCodeToFind = value; OnPropertyChanged(); }
        }

        ObservableCollection<RegistrationMpsView> _registeredMps;
        public ObservableCollection<RegistrationMpsView> RegisteredMps
        {
            get { return _registeredMps; }
            set { _registeredMps = value; OnPropertyChanged(); }
        }

        public RegisterViewModel()
        {
            
            OpenRegistrationWindowCommand = new RelayCommand(ExecuteShowDialog);
            SearchMpsCommand = new RelayCommand(SearchMps);
            UpdateMpsCommand = new RelayCommand(UpdateSelectedMps);

            InitialiazeDataCollections();

        }

        void ExecuteShowDialog()
        {
            _dialogService.ShowDialog("CreateRegisterMps", (result,mpsToRegister) =>
            {
                
                if (result.ToString() == "True")
                {
                    AddNewMps((RegistrationMpsView)mpsToRegister);                    
                }
            });
        }


        void InitialiazeDataCollections()
        {
            using (var dbContext = new MpsContext())
            {
                _registeredMps = new ObservableCollection<RegistrationMpsView>(dbContext.RegistrationMpsViews.ToList());
                MpsTypeList = dbContext.TypeMps.Select(x => x.TypeMps).ToList();
                MpsMeasureList = dbContext.UnitMeasurementsMps.Select(x => x.NameMeasurements).ToList();
                SupplierList = dbContext.SupplierMps.Select(x => x.NameCompany).ToList();
            }
        }

        void AddNewMps(RegistrationMpsView mpsToRegister)
        {
            using (var dbContext = new MpsContext())
            {
                IncrementMpsId(mpsToRegister);

                dbContext.RegistrationMpsViews.Add(mpsToRegister);
                dbContext.SaveChanges();

                _registeredMps.Add(dbContext.RegistrationMpsViews.OrderBy(x => x.IdMps).Last());
            }
        }

        // To prevent ConcurrencyException increment mps_id manually
        void IncrementMpsId(RegistrationMpsView newMps)
        {
            newMps.IdMps = ++_registeredMps.Last().IdMps;
        }

        void DisplayAllMps()
        {

        }

        void SearchMps()
        {
            var foundMps = _registeredMps.FirstOrDefault(x => x.CodeMps == _mpsCodeToFind);

            _registeredMps.Clear();
            _registeredMps.Add(foundMps);

        }

        void UpdateSelectedMps()
        {
            using (var dbContext = new MpsContext())
            {
                dbContext.Update(_selectedMps);
                dbContext.SaveChanges();
            }
        }

    }
}

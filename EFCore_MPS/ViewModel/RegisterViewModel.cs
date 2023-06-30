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
            DisplayAllMpsCommand = new RelayCommand(DisplayAllMps);

            InitialiazeDataCollections();

        }

        /// <summary>
        /// Execute dialogWindow, and handle dialog results
        /// </summary>
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

        /// <summary>
        /// Initialize dataCollection from DB
        /// </summary>
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
        /// <summary>
        /// add new mps record to DB and observable collection
        /// </summary>
        /// <param name="mpsToRegister"></param>
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

        /// <summary>
        /// To prevent ConcurrencyException increment mps_id manually
        /// </summary>
        /// <param name="newMps"></param>
        void IncrementMpsId(RegistrationMpsView newMps)
        {
            newMps.IdMps = ++_registeredMps.Last().IdMps;
        }
        /// <summary>
        /// Display all mps
        /// </summary>
        void DisplayAllMps()
        {
            _registeredMps.Clear();
            AddDataFromDbToCollection();
        }

        /// <summary>
        /// Add data from DBSet to ObservableCollection
        /// </summary>
        void AddDataFromDbToCollection()
        {
            using (var dbContext = new MpsContext())
            {
                foreach (var item in dbContext.RegistrationMpsViews)
                {
                    _registeredMps.Add(item);
                }
            }
        }

        /// <summary>
        /// Search mps by code
        /// </summary>
        void SearchMps()
        {
            var foundMps = _registeredMps.FirstOrDefault(x => x.CodeMps == _mpsCodeToFind);

            _registeredMps.Clear();
            _registeredMps.Add(foundMps);

        }
        /// <summary>
        /// Update modified mps object to DB
        /// </summary>
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

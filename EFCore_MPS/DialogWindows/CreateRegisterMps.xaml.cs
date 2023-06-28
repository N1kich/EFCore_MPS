using EFCore_MPS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EFCore_MPS.DialogWindows
{
    /// <summary>
    /// Логика взаимодействия для CreateRegisterMps.xaml
    /// </summary>
    public partial class CreateRegisterMps : UserControl
    {
        RegistrationMpsView _mpsToCreate;
        public RegistrationMpsView MpsToCreate
        {
            get { return _mpsToCreate; }
            set { _mpsToCreate = value; }
        }
        public CreateRegisterMps()
        {
            InitializeComponent();
            _mpsToCreate= new RegistrationMpsView();
        }

        private void LoadMPS_Click(object sender, RoutedEventArgs e)
        {
            var window = this.Parent as DialogWindow;
            _mpsToCreate.Name = Name_MPS.Text;
            _mpsToCreate.CodeMps = Code_MPS.Text;
            _mpsToCreate.MeasureType = Measurements_Box.SelectedItem.ToString();
            _mpsToCreate.PricePerUnit = Int32.Parse(PricePerUnit_MPS.Text);
            _mpsToCreate.Supplier = Suppliers_Box.SelectedItem.ToString();
            _mpsToCreate.ExpireDate = ExpireDate_Picker.DisplayDate;
            _mpsToCreate.MpsType = Type_Box.SelectedItem.ToString() ;
            _mpsToCreate.ArrivalDate = ArrivalDate_MPS.DisplayDate;
            _mpsToCreate.Quantity = Int32.Parse(Amount_MPS.Text);
            _mpsToCreate.TotalCost = _mpsToCreate.PricePerUnit * _mpsToCreate.Quantity;
            window.ObjectToDbSave = MpsToCreate;
            window.DialogResult = true;
            
            
        }
    }
}

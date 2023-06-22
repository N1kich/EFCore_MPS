using EFCore_MPS.Core;
using EFCore_MPS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_MPS.ViewModel
{
    class CreateMpsViewModel: ObservableObject
    {
        public List<SupplierMp> SupplierMps;
        public List<UnitMeasurementsMp> UnitMeasurements;
        public List<TypeMp> TypeMps;

        RelayCommand<object>? CreateNewMpsCommand;
        public CreateMpsViewModel() 
        {
            SupplierMps= new List<SupplierMp>();
            UnitMeasurements= new List<UnitMeasurementsMp>();
            TypeMps= new List<TypeMp>();
            using (var dbContext = new MpsContext())
            {
                SupplierMps = dbContext.SupplierMps.ToList();
                UnitMeasurements= dbContext.UnitMeasurementsMps.ToList();
                TypeMps= dbContext.TypeMps.ToList();
            }
        }
    }
}

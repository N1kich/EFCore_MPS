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
        public List<string> SupplierMpsList { get; set; }
        public List<string> UnitMeasurementsList { get; set; }
        public List<string> TypeMpsList { get; set; }

        public CreateMpsViewModel() 
        {
            
            using (var dbContext = new MpsContext())
            {
                SupplierMpsList = dbContext.SupplierMps.Select(supplier => supplier.NameCompany).ToList();
                UnitMeasurementsList = dbContext.UnitMeasurementsMps.Select(measurements => measurements.NameMeasurements).ToList();
                TypeMpsList = dbContext.TypeMps.Select(typeMps => typeMps.TypeMps).ToList();


            }
        }

        
    }
}

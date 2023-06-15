using System;
using System.Collections.Generic;

namespace EFCore_MPS.Models;

public partial class SupplierMp
{
    public int IdSupplier { get; set; }

    public string? NameCompany { get; set; }

    public string? AddressCompany { get; set; }

    public string? PhoneNumberCompany { get; set; }

    public string? EmailCompany { get; set; }

    public virtual ICollection<Mp> Mps { get; set; } = new List<Mp>();
}

using System;
using System.Collections.Generic;

namespace EFCore_MPS.Models;

public partial class PlaceStorage
{
    public int IdPlaceStorage { get; set; }

    public string? PlaceStorage1 { get; set; }

    public virtual ICollection<InventoryReport> InventoryReports { get; set; } = new List<InventoryReport>();
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCore_MPS.Models;

public partial class Mp
{
    [Key]
    public int IdMps { get; set; }

    public string? NameMps { get; set; }

    public string? CodeMps { get; set; }

    public int? IdTypeMps { get; set; }

    public int? IdMeasurements { get; set; }

    public decimal? PricePerUnitMps { get; set; }

    public int? IdSupplier { get; set; }

    public DateTime? ExpireDateMps { get; set; }

    public int? AmountMps { get; set; }

    public DateTime? ArrivalDateMps { get; set; }

    public decimal? TotalCostMps { get; set; }

    public virtual ICollection<DefectList> DefectLists { get; set; } = new List<DefectList>();

    public virtual ICollection<DisposalList> DisposalLists { get; set; } = new List<DisposalList>();

    public virtual UnitMeasurementsMp? IdMeasurementsNavigation { get; set; }

    public virtual SupplierMp? IdSupplierNavigation { get; set; }

    public virtual TypeMp? IdTypeMpsNavigation { get; set; }

    public virtual ICollection<InventoryReport> InventoryReports { get; set; } = new List<InventoryReport>();
}

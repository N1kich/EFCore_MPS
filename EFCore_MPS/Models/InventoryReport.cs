using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCore_MPS.Models;

public partial class InventoryReport
{
    [Key]
    public int IdReportInventorisation { get; set; }

    public int? IdWorker { get; set; }

    public int? IdPlaceStorage { get; set; }

    public int? IdMps { get; set; }

    public string? DiscrepancyReason { get; set; }

    public DateTime? DateReportInventorisation { get; set; }

    public int? AmountReport { get; set; }

    public virtual Mp? IdMpsNavigation { get; set; }

    public virtual PlaceStorage? IdPlaceStorageNavigation { get; set; }

    public virtual Worker? IdWorkerNavigation { get; set; }
}

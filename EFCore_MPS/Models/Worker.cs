using System;
using System.Collections.Generic;

namespace EFCore_MPS.Models;

public partial class Worker
{
    public int IdWorker { get; set; }

    public string? FullnameWorker { get; set; }

    public string? EmailWorker { get; set; }

    public string? GenderWorker { get; set; }

    public int? AgeWorker { get; set; }

    public string? AddressWorker { get; set; }

    public virtual ICollection<DisposalList> DisposalLists { get; set; } = new List<DisposalList>();

    public virtual ICollection<InventoryReport> InventoryReports { get; set; } = new List<InventoryReport>();

    public virtual ICollection<NotificationList> NotificationLists { get; set; } = new List<NotificationList>();
}

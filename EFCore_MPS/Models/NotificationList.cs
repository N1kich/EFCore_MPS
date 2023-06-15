using System;
using System.Collections.Generic;

namespace EFCore_MPS.Models;

public partial class NotificationList
{
    public int IdNotification { get; set; }

    public int? IdWorker { get; set; }

    public string? DescriptionNotification { get; set; }

    public DateTime? DateNotification { get; set; }

    public virtual Worker? IdWorkerNavigation { get; set; }
}

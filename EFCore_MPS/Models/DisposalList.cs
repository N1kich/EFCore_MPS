using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCore_MPS.Models;

public partial class DisposalList
{
    [Key]
    public int IdDisposal { get; set; }

    public int? IdDisposalReason { get; set; }

    public int? IdStatusMps { get; set; }

    public int? IdWorker { get; set; }

    public int? IdMps { get; set; }

    public int? AmountDisposal { get; set; }

    public string? DescriptionDisposal { get; set; }

    public DateTime? DisposalDate { get; set; }

    public virtual DisposalReason? IdDisposalReasonNavigation { get; set; }

    public virtual Mp? IdMpsNavigation { get; set; }

    public virtual StatusMp? IdStatusMpsNavigation { get; set; }

    public virtual Worker? IdWorkerNavigation { get; set; }
}

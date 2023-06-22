using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCore_MPS.Models;

public partial class DisposalReason
{
    [Key]
    public int IdDisposalReason { get; set; }

    public string? DisposalReason1 { get; set; }

    public virtual ICollection<DisposalList> DisposalLists { get; set; } = new List<DisposalList>();
}

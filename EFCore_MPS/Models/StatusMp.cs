using System;
using System.Collections.Generic;

namespace EFCore_MPS.Models;

public partial class StatusMp
{
    public int IdStatusMps { get; set; }

    public string? NameStatus { get; set; }

    public virtual ICollection<DisposalList> DisposalLists { get; set; } = new List<DisposalList>();
}

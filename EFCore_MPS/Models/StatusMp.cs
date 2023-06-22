using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCore_MPS.Models;

public partial class StatusMp
{
    [Key]
    public int IdStatusMps { get; set; }

    public string? NameStatus { get; set; }

    public virtual ICollection<DisposalList> DisposalLists { get; set; } = new List<DisposalList>();
}

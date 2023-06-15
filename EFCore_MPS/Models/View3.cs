using System;
using System.Collections.Generic;

namespace EFCore_MPS.Models;

public partial class View3
{
    public string? NameMps { get; set; }

    public string? CodeMps { get; set; }

    public string? DisposalReason { get; set; }

    public string? StatusMps { get; set; }

    public int? DisposalQuantity { get; set; }

    public DateTime? DisposalDate { get; set; }

    public string? DisposalDescription { get; set; }

    public string? Worker { get; set; }
}

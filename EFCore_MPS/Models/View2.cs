using System;
using System.Collections.Generic;

namespace EFCore_MPS.Models;

public partial class View2
{
    public string? NameMps { get; set; }

    public string? CodeMps { get; set; }

    public string? DefectType { get; set; }

    public int? Quantity { get; set; }

    public DateTime? DateDefect { get; set; }

    public string? CorrectionDefectType { get; set; }

    public string? DefectDesription { get; set; }
}

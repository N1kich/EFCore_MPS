using System;
using System.Collections.Generic;

namespace EFCore_MPS.Models;

public partial class TypeDefect
{
    public int IdDefect { get; set; }

    public string? TypeDefect1 { get; set; }

    public virtual ICollection<DefectList> DefectLists { get; set; } = new List<DefectList>();
}

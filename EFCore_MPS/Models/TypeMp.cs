using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCore_MPS.Models;

public partial class TypeMp
{
    [Key]
    public int IdTypeMps { get; set; }

    public string? TypeMps { get; set; }

    public virtual ICollection<Mp> Mps { get; set; } = new List<Mp>();
}

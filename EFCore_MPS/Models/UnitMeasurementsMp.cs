using System;
using System.Collections.Generic;

namespace EFCore_MPS.Models;

public partial class UnitMeasurementsMp
{
    public int IdMeasurements { get; set; }

    public string? NameMeasurements { get; set; }

    public virtual ICollection<Mp> Mps { get; set; } = new List<Mp>();
}

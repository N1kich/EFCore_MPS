﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCore_MPS.Models;

public partial class DefectCorrection
{
    [Key]
    public int IdCorrection { get; set; }

    public string? TypeCorrection { get; set; }

    public virtual ICollection<DefectList> DefectLists { get; set; } = new List<DefectList>();
}

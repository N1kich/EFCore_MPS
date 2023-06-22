using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCore_MPS.Models;

public partial class DefectList
{
    [Key]
    public int IdDefectList { get; set; }

    public int? IdDefect { get; set; }

    public int? IdMps { get; set; }

    public int? IdCorrection { get; set; }

    public string? DescriptionDefect { get; set; }

    public int? AmountDefectMps { get; set; }

    public DateTime? DateDefect { get; set; }

    public virtual DefectCorrection? IdCorrectionNavigation { get; set; }

    public virtual TypeDefect? IdDefectNavigation { get; set; }

    public virtual Mp? IdMpsNavigation { get; set; }
}

﻿using System;
using System.Collections.Generic;

namespace EFCore_MPS.Models;

public partial class RegistrationMpsView
{
    public int IdMps { get; set; }

    public string? Name { get; set; }

    public string? CodeMps { get; set; }

    public string? MpsType { get; set; }

    public string? MeasureType { get; set; }

    public decimal? PricePerUnit { get; set; }

    public string? Supplier { get; set; }

    public DateTime? ExpireDate { get; set; }

    public int? Quantity { get; set; }

    public DateTime? ArrivalDate { get; set; }

    public decimal? TotalCost { get; set; }
}

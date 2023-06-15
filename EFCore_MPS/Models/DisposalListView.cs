using System;
using System.Collections.Generic;

namespace EFCore_MPS.Models;

public partial class DisposalListView
{
    public string? Наименование { get; set; }

    public string? КодМпз { get; set; }

    public string? ПричинаСписания { get; set; }

    public string? СтатусМпз { get; set; }

    public int? КоличествоНаСписание { get; set; }

    public DateTime? ДатаСписания { get; set; }

    public string? Описание { get; set; }

    public string? Ответственный { get; set; }
}

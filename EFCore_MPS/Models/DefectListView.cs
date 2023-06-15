using System;
using System.Collections.Generic;

namespace EFCore_MPS.Models;

public partial class DefectListView
{
    public string? НаименованиеМпз { get; set; }

    public string? КодМпз { get; set; }

    public string? ТипБрака { get; set; }

    public int? Количество { get; set; }

    public DateTime? ДатаОбнаруженияДефетка { get; set; }

    public string? ТипИсправленияДефекта { get; set; }

    public string? ОписаниеБрака { get; set; }
}

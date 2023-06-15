using System;
using System.Collections.Generic;

namespace EFCore_MPS.Models;

public partial class NotificationListView
{
    public string? Сотрудник { get; set; }

    public string? Email { get; set; }

    public string? Сообщение { get; set; }

    public DateTime? ДатаУведомления { get; set; }
}

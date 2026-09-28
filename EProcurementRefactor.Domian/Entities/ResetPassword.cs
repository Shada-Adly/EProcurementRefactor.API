using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class ResetPassword
{
    public int? UserId { get; set; }

    public string? Code { get; set; }

    public DateTime? InsertedTime { get; set; }

    public virtual UserHeader? User { get; set; }
}

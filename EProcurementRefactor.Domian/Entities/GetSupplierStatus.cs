using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class GetSupplierStatus
{
    public string? Company { get; set; }

    public bool? Verifyied { get; set; }

    public bool? Refused { get; set; }

    public DateTime? UserDatetime { get; set; }
}

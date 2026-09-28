using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class TempTaxId
{
    public string? SapCode { get; set; }

    public string? TaxId { get; set; }
}

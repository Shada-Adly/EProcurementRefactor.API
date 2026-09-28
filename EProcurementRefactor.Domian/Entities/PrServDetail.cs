using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class PrServDetail
{
    public int Id { get; set; }

    public int? HeaderId { get; set; }

    public string? MtrGrpCode { get; set; }

    public string? MtrGrpDesc { get; set; }

    public string? InudstryDesc { get; set; }

    public string? IndustryCode { get; set; }
}

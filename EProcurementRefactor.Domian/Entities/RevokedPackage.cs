using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class RevokedPackage
{
    public int Id { get; set; }

    public string? PrNum { get; set; }

    public string? LineItem { get; set; }

    public DateOnly? PrDate { get; set; }

    public string? MtrCode { get; set; }

    public string? MtrDesc { get; set; }

    public string? MtrLongDesc { get; set; }

    public string? MtrBatch { get; set; }

    public string? MtrQty { get; set; }

    public string? MtrUom { get; set; }

    public string? MGrp { get; set; }

    public DateTime InsertedDate { get; set; }

    public int? ProjectId { get; set; }

    public int? IndustryId { get; set; }

    public DateTime? Cancelledrevoke { get; set; }

    public bool? Cancelled { get; set; }

    public string? Serial { get; set; }
}

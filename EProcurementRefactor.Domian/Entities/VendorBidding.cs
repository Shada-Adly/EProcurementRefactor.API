using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class VendorBidding
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? PkgDetailsId { get; set; }

    public string? Price { get; set; }

    public DateTime? InsertedDate { get; set; }

    public DateOnly? DeliveryDate { get; set; }

    public string? AdvancedPayment { get; set; }

    public string? TechnicalApproval { get; set; }

    public bool? Rejected { get; set; }

    public string? FilePath { get; set; }

    public string? MaterialPayment { get; set; }

    public string? WorksPayment { get; set; }

    public string? Transportation { get; set; }

    public string? DurationDays { get; set; }

    public string? Comment { get; set; }
}

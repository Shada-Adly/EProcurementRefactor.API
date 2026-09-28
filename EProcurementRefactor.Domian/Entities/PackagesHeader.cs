using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class PackagesHeader
{
    public int Id { get; set; }

    public string? PkgName { get; set; }

    public string? AssignType { get; set; }

    public int? ProjectId { get; set; }

    public int? IndustryId { get; set; }

    public DateTime? InsertedDate { get; set; }

    public bool? Bid { get; set; }

    public bool? Cancelled { get; set; }

    public int? PkgNum { get; set; }

    public int? AssignedBy { get; set; }

    public string? FilePath { get; set; }

    public bool? ExclImport { get; set; }

    public bool? IsService { get; set; }

    public string? Currency { get; set; }

    public virtual ICollection<AcceptedOffer> AcceptedOffers { get; set; } = new List<AcceptedOffer>();

    public virtual ICollection<PackagesDetail> PackagesDetails { get; set; } = new List<PackagesDetail>();
}

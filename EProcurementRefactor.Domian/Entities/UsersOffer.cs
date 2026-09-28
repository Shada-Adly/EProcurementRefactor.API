using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class UsersOffer
{
    public int Id { get; set; }

    public int? PackageId { get; set; }

    public string? FileName { get; set; }

    public string? FilePath { get; set; }

    public int? UserId { get; set; }

    public DateTime? OfferDate { get; set; }

    public virtual ProjPackage? Package { get; set; }

    public virtual UserHeader? User { get; set; }
}

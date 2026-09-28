using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class AcceptedOffer
{
    public int Id { get; set; }

    public int? PkgHeaderId { get; set; }

    public int? UserId { get; set; }

    public DateTime? AcceptDate { get; set; }

    public virtual PackagesHeader? PkgHeader { get; set; }

    public virtual UserHeader? User { get; set; }
}

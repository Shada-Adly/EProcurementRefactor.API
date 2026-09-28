using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class ProjPackage
{
    public int Id { get; set; }

    public int? PrjId { get; set; }

    public int? BoqCptId { get; set; }

    public string? FilePath { get; set; }

    public string? FileName { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? Comments { get; set; }

    public DateTime? DateInserted { get; set; }

    public string? LinkOfDrive { get; set; }

    public virtual BoqChapter? BoqCpt { get; set; }

    public virtual ICollection<DownloadedPackage> DownloadedPackages { get; set; } = new List<DownloadedPackage>();

    public virtual Project? Prj { get; set; }

    public virtual ICollection<UsersBidding> UsersBiddings { get; set; } = new List<UsersBidding>();

    public virtual ICollection<UsersOffer> UsersOffers { get; set; } = new List<UsersOffer>();
}

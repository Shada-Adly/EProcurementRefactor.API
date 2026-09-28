using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class Project
{
    public int Id { get; set; }

    public string? ProjectNumb { get; set; }

    public string? ProjectName { get; set; }

    public string? DeliveryPoint { get; set; }

    public int? AreaId { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public bool? Status { get; set; }

    public DateTime? InsertedDate { get; set; }

    public virtual ProjectsArea? Area { get; set; }

    public virtual ICollection<ProjPackage> ProjPackages { get; set; } = new List<ProjPackage>();

    public virtual ICollection<ProjectsTenderDetail> ProjectsTenderDetails { get; set; } = new List<ProjectsTenderDetail>();

    public virtual ICollection<ProjectsTender> ProjectsTenders { get; set; } = new List<ProjectsTender>();
}

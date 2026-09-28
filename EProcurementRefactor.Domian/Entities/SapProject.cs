using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class SapProject
{
    public int Id { get; set; }

    public string? ProjNum { get; set; }

    public string? ProjName { get; set; }

    public string? EnglishDesc { get; set; }

    public int? AreaId { get; set; }

    public virtual SupportedArea? Area { get; set; }

    public virtual ICollection<SapProjectsStorloc> SapProjectsStorlocs { get; set; } = new List<SapProjectsStorloc>();
}

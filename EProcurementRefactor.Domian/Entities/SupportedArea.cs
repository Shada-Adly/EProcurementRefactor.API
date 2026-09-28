using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class SupportedArea
{
    public int Id { get; set; }

    public string? AreaName { get; set; }

    public virtual ICollection<SapProject> SapProjects { get; set; } = new List<SapProject>();

    public virtual ICollection<UserHeader> UserHeaders { get; set; } = new List<UserHeader>();
}

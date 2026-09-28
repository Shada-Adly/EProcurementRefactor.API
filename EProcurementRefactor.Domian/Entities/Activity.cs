using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class Activity
{
    public int Id { get; set; }

    public string? ActivityName { get; set; }

    public virtual ICollection<ActivitiesDetail> ActivitiesDetails { get; set; } = new List<ActivitiesDetail>();
}

using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class ActivitiesDetail
{
    public int Id { get; set; }

    public int? ActivityId { get; set; }

    public string? ActivityName { get; set; }

    public virtual Activity? Activity { get; set; }

    public virtual ICollection<UserActivity> UserActivities { get; set; } = new List<UserActivity>();
}

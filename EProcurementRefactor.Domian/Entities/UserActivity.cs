using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class UserActivity
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? AcitivityDetailsId { get; set; }

    public virtual ActivitiesDetail? AcitivityDetails { get; set; }

    public virtual UserHeader? User { get; set; }
}

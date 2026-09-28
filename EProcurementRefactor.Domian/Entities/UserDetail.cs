using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class UserDetail
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? TypeId { get; set; }

    public int? IndustriesDetails { get; set; }

    public DateTime? CurrentDate { get; set; }

    public virtual ServicesIndustry? IndustriesDetailsNavigation { get; set; }

    public virtual UsersType? Type { get; set; }

    public virtual UserHeader? User { get; set; }
}

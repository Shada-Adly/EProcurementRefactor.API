using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class UsersType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<UserDetail> UserDetails { get; set; } = new List<UserDetail>();
}

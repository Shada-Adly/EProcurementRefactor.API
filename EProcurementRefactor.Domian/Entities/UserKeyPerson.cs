using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class UserKeyPerson
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }
}

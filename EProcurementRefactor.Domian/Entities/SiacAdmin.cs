using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class SiacAdmin
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }
}

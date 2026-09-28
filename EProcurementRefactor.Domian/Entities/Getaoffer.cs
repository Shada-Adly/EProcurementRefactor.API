using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class Getaoffer
{
    public DateTime? AcceptDate { get; set; }

    public string? PkgName { get; set; }

    public string? Company { get; set; }
}

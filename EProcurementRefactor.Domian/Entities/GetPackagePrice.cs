using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class GetPackagePrice
{
    public double? TotalPrice { get; set; }

    public string? PkgName { get; set; }
}

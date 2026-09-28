using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class BoqChpPackage
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? ChpId { get; set; }
}

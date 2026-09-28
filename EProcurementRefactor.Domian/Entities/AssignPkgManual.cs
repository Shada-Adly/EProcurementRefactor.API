using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class AssignPkgManual
{
    public int Id { get; set; }

    public int? PkgManualId { get; set; }

    public int? UserId { get; set; }

    public DateTime? InsertedDate { get; set; }
}

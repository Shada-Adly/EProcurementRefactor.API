using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class UsersComment
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? PkgId { get; set; }

    public string? Comment { get; set; }

    public string? DateInserted { get; set; }
}

using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class SrvMtr
{
    public int Id { get; set; }

    public string? ServDesc { get; set; }

    public string? ServCode { get; set; }

    public string? MtrDesc { get; set; }

    public string? MtrCode { get; set; }
}

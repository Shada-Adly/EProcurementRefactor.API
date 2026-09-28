using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class ServiceMtrGrp
{
    public int Id { get; set; }

    public int? MtrSrvId { get; set; }

    public string? MtrSrvGrpDesc { get; set; }

    public string? MtrSrvGrpCode { get; set; }

    public virtual ServicesIndustry? MtrSrv { get; set; }
}

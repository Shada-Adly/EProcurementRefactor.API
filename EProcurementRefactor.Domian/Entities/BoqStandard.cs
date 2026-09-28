using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class BoqStandard
{
    public short Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<BoqChapter> BoqChapters { get; set; } = new List<BoqChapter>();
}

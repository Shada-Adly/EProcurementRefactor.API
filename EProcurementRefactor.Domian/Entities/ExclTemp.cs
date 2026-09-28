using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class ExclTemp
{
    public string? SapCode { get; set; }

    public string? City { get; set; }

    public string? PostalCode { get; set; }

    public string? Street { get; set; }

    public string? TelephoneOne { get; set; }

    public string? TelephoneTwo { get; set; }
}

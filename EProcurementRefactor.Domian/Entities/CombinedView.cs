using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class CombinedView
{
    public int Id { get; set; }

    public string? CombinedUser { get; set; }

    public string? KeypersonName { get; set; }

    public string? Area { get; set; }

    public string? Email { get; set; }

    public string? KeyPersonMail { get; set; }

    public string? KeyPersonPhone { get; set; }

    public string? Capital { get; set; }

    public string? EngineersNo { get; set; }

    public string? TaxId { get; set; }

    public string? EquipmentNo { get; set; }

    public string? ProjectValue { get; set; }

    public string? Phone { get; set; }

    public string? Company { get; set; }

    public string? Fax { get; set; }

    public string? SapCode { get; set; }

    public string? IsoDocumentFilePath { get; set; }

    public string? TaxidDocumentFilePath { get; set; }

    public string? CommercialRegisterDocumentFilePath { get; set; }

    public string? PrevWorkFilePath { get; set; }

    public string? IncomeTaxFilePath { get; set; }

    public string? ElectronicInvoiceFilePath { get; set; }

    public string? Category { get; set; }
}

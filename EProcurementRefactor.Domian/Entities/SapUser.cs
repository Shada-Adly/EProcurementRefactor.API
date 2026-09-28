using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class SapUser
{
    public int Id { get; set; }

    public string? Fname { get; set; }

    public string? Lname { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Address { get; set; }

    public bool? Verifyied { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Company { get; set; }

    public DateTime? UserDatetime { get; set; }

    public bool? Refused { get; set; }

    public string? TaxidDocumentFilePath { get; set; }

    public string? CommercialRegisterDocumentFilePath { get; set; }

    public bool? IsoVerifyed { get; set; }

    public int? AreasId { get; set; }

    public string? KeypersonName { get; set; }

    public string? KeypersonMail { get; set; }

    public string? KeypersonPhone { get; set; }

    public string? Moneybudget { get; set; }

    public string? Projectno { get; set; }

    public string? Engineersno { get; set; }

    public string? Equipment { get; set; }

    public bool? UploadedData { get; set; }

    public string? TaxId { get; set; }

    public string? SapCode { get; set; }

    public string? PrevWorkDocumentFilePath { get; set; }

    public string? PhoneTwo { get; set; }

    public string? City { get; set; }

    public string? PostalCode { get; set; }

    public string? Fax { get; set; }

    public string? CommentsSalesPerson { get; set; }

    public string? ExternalAddressNumberSale { get; set; }

    public string? SalesPersonEmail { get; set; }

    public string? IncomeTaxDocument { get; set; }

    public string? ElectronicInvoiceDocument { get; set; }

    public string? IsoDocumentFilePath { get; set; }
}

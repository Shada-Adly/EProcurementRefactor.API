using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace EProcurementRefactor.Domain.Entities;

public partial class EprocuremntrefactorContext : DbContext
{
    public EprocuremntrefactorContext()
    {
    }

    public EprocuremntrefactorContext(DbContextOptions<EprocuremntrefactorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AcceptedOffer> AcceptedOffers { get; set; }

    public virtual DbSet<ActivitiesDetail> ActivitiesDetails { get; set; }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<AssignPkgManual> AssignPkgManuals { get; set; }

    public virtual DbSet<BoqChapter> BoqChapters { get; set; }

    public virtual DbSet<BoqChpPackage> BoqChpPackages { get; set; }

    public virtual DbSet<BoqStandard> BoqStandards { get; set; }

    public virtual DbSet<CombinedView> CombinedViews { get; set; }

    public virtual DbSet<DownloadedPackage> DownloadedPackages { get; set; }

    public virtual DbSet<ExclTemp> ExclTemps { get; set; }

    public virtual DbSet<GetAcceptedOffer> GetAcceptedOffers { get; set; }

    public virtual DbSet<GetPackagePrice> GetPackagePrices { get; set; }

    public virtual DbSet<GetSupplierStatus> GetSupplierStatuses { get; set; }

    public virtual DbSet<Getaoffer> Getaoffers { get; set; }

    public virtual DbSet<IndustryMaterialGrp> IndustryMaterialGrps { get; set; }

    public virtual DbSet<PackageManual> PackageManuals { get; set; }

    public virtual DbSet<PackagesDetail> PackagesDetails { get; set; }

    public virtual DbSet<PackagesHeader> PackagesHeaders { get; set; }

    public virtual DbSet<PrServDetail> PrServDetails { get; set; }

    public virtual DbSet<PrServHeader> PrServHeaders { get; set; }

    public virtual DbSet<ProjBoq> ProjBoqs { get; set; }

    public virtual DbSet<ProjPackage> ProjPackages { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectsArea> ProjectsAreas { get; set; }

    public virtual DbSet<ProjectsTender> ProjectsTenders { get; set; }

    public virtual DbSet<ProjectsTenderDetail> ProjectsTenderDetails { get; set; }

    public virtual DbSet<ReleasedPackage> ReleasedPackages { get; set; }

    public virtual DbSet<ResetPassword> ResetPasswords { get; set; }

    public virtual DbSet<RevokedPackage> RevokedPackages { get; set; }

    public virtual DbSet<RevokedPkgManual> RevokedPkgManuals { get; set; }

    public virtual DbSet<SapProject> SapProjects { get; set; }

    public virtual DbSet<SapProjectsStorloc> SapProjectsStorlocs { get; set; }

    public virtual DbSet<SapUser> SapUsers { get; set; }

    public virtual DbSet<ServiceHeader> ServiceHeaders { get; set; }

    public virtual DbSet<ServiceMtrGrp> ServiceMtrGrps { get; set; }

    public virtual DbSet<ServicesIndustry> ServicesIndustries { get; set; }

    public virtual DbSet<SiacAdmin> SiacAdmins { get; set; }

    public virtual DbSet<SrvMtr> SrvMtrs { get; set; }

    public virtual DbSet<SupportedArea> SupportedAreas { get; set; }

    public virtual DbSet<TempTaxId> TempTaxIds { get; set; }

    public virtual DbSet<UserActivity> UserActivities { get; set; }

    public virtual DbSet<UserDetail> UserDetails { get; set; }

    public virtual DbSet<UserHeader> UserHeaders { get; set; }

    public virtual DbSet<UserKeyPerson> UserKeyPersons { get; set; }

    public virtual DbSet<UsersBidding> UsersBiddings { get; set; }

    public virtual DbSet<UsersComment> UsersComments { get; set; }

    public virtual DbSet<UsersOffer> UsersOffers { get; set; }

    public virtual DbSet<UsersType> UsersTypes { get; set; }

    public virtual DbSet<VendorBidding> VendorBiddings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=eprocuremntrefactor;user=root;password=Ash47", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.5.27-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<AcceptedOffer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("accepted_offers");

            entity.HasIndex(e => e.PkgHeaderId, "FK_PKG_Header_accepted_Offer");

            entity.HasIndex(e => e.UserId, "FK_user_accepted_Offer");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.AcceptDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("accept_date");
            entity.Property(e => e.PkgHeaderId)
                .HasColumnType("int(11)")
                .HasColumnName("pkg_header_id");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("user_id");

            entity.HasOne(d => d.PkgHeader).WithMany(p => p.AcceptedOffers)
                .HasForeignKey(d => d.PkgHeaderId)
                .HasConstraintName("FK_PKG_Header_accepted_Offer");

            entity.HasOne(d => d.User).WithMany(p => p.AcceptedOffers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_user_accepted_Offer");
        });

        modelBuilder.Entity<ActivitiesDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("activities_details")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.ActivityId, "FK_activity_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.ActivityId)
                .HasColumnType("int(11)")
                .HasColumnName("activity_id");
            entity.Property(e => e.ActivityName)
                .HasMaxLength(255)
                .HasColumnName("activity_name");

            entity.HasOne(d => d.Activity).WithMany(p => p.ActivitiesDetails)
                .HasForeignKey(d => d.ActivityId)
                .HasConstraintName("FK_activity_id");
        });

        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("activities")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.ActivityName)
                .HasMaxLength(255)
                .HasColumnName("activity_name");
        });

        modelBuilder.Entity<AssignPkgManual>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("assign_pkg_manual");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.InsertedDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("inserted_date");
            entity.Property(e => e.PkgManualId)
                .HasColumnType("int(11)")
                .HasColumnName("pkg_manual_id");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<BoqChapter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("boq_chapters")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.BoqId, "FK_BoqID_");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.BoqId)
                .HasColumnType("smallint(6)")
                .HasColumnName("boq_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.Boq).WithMany(p => p.BoqChapters)
                .HasForeignKey(d => d.BoqId)
                .HasConstraintName("FK_BoqID_");
        });

        modelBuilder.Entity<BoqChpPackage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("boq_chp_packages")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.ChpId)
                .HasColumnType("int(11)")
                .HasColumnName("chp_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<BoqStandard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("boq_standard")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("smallint(6)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<CombinedView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("combined_view");

            entity.Property(e => e.Area)
                .HasMaxLength(25)
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Capital)
                .HasMaxLength(25)
                .HasColumnName("CAPITAL")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Category)
                .HasMaxLength(1)
                .HasColumnName("category")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.CombinedUser)
                .HasMaxLength(255)
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.CommercialRegisterDocumentFilePath)
                .HasMaxLength(255)
                .HasColumnName("commercial_register_document_file_path")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Company)
                .HasMaxLength(255)
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.ElectronicInvoiceFilePath)
                .HasMaxLength(255)
                .HasColumnName("electronic_invoice_file_path")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.EngineersNo)
                .HasMaxLength(25)
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.EquipmentNo)
                .HasMaxLength(25)
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Fax)
                .HasMaxLength(255)
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.IncomeTaxFilePath)
                .HasMaxLength(255)
                .HasColumnName("income_tax_file_path")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.IsoDocumentFilePath)
                .HasMaxLength(255)
                .HasColumnName("iso_document_file_path")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.KeyPersonMail)
                .HasMaxLength(255)
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.KeyPersonPhone)
                .HasMaxLength(255)
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.KeypersonName)
                .HasMaxLength(255)
                .HasColumnName("keyperson_name")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Phone)
                .HasMaxLength(25)
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.PrevWorkFilePath)
                .HasMaxLength(255)
                .HasColumnName("prev_work_file_path")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.ProjectValue)
                .HasMaxLength(15)
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.SapCode)
                .HasMaxLength(255)
                .HasColumnName("sap_code")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.TaxId)
                .HasMaxLength(255)
                .HasColumnName("TaxID")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.TaxidDocumentFilePath)
                .HasMaxLength(255)
                .HasColumnName("taxid_document_file_path")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
        });

        modelBuilder.Entity<DownloadedPackage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("downloaded_packages")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.PkgId, "PKGID_");

            entity.HasIndex(e => e.UserId, "USERID_");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DateInserted)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("date_inserted");
            entity.Property(e => e.PkgId)
                .HasColumnType("int(11)")
                .HasColumnName("pkg_id");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("user_id");

            entity.HasOne(d => d.Pkg).WithMany(p => p.DownloadedPackages)
                .HasForeignKey(d => d.PkgId)
                .HasConstraintName("PKGID_");

            entity.HasOne(d => d.User).WithMany(p => p.DownloadedPackages)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("USERID_");
        });

        modelBuilder.Entity<ExclTemp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("excl_temp")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.City)
                .HasMaxLength(255)
                .HasColumnName("city");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(255)
                .HasColumnName("postal_code");
            entity.Property(e => e.SapCode)
                .HasMaxLength(255)
                .HasColumnName("sap_code");
            entity.Property(e => e.Street)
                .HasMaxLength(255)
                .HasColumnName("street");
            entity.Property(e => e.TelephoneOne)
                .HasMaxLength(255)
                .HasColumnName("telephone_one");
            entity.Property(e => e.TelephoneTwo)
                .HasMaxLength(255)
                .HasColumnName("telephone_two");
        });

        modelBuilder.Entity<GetAcceptedOffer>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("get_accepted_offers");

            entity.Property(e => e.AcceptDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("accept_date");
            entity.Property(e => e.Company)
                .HasMaxLength(255)
                .HasColumnName("company")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.PkgName)
                .HasMaxLength(255)
                .HasColumnName("pkg_name")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
        });

        modelBuilder.Entity<GetPackagePrice>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("get_package_price");

            entity.Property(e => e.PkgName)
                .HasMaxLength(255)
                .HasColumnName("pkg_name")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.TotalPrice).HasColumnName("total_Price");
        });

        modelBuilder.Entity<GetSupplierStatus>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("get_supplier_status");

            entity.Property(e => e.Company)
                .HasMaxLength(255)
                .HasColumnName("company")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Refused)
                .HasDefaultValueSql("'0'")
                .HasColumnName("refused");
            entity.Property(e => e.UserDatetime)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("user_datetime");
            entity.Property(e => e.Verifyied)
                .HasDefaultValueSql("'0'")
                .HasColumnName("verifyied");
        });

        modelBuilder.Entity<Getaoffer>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("getaoffers");

            entity.Property(e => e.AcceptDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("accept_date");
            entity.Property(e => e.Company)
                .HasMaxLength(255)
                .HasColumnName("company")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.PkgName)
                .HasMaxLength(255)
                .HasColumnName("pkg_name")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
        });

        modelBuilder.Entity<IndustryMaterialGrp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("industry_material_grp")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.IndustryId, "FK_IndusID");

            entity.HasIndex(e => e.ServiceId, "FK_SERVID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.IndustryId)
                .HasColumnType("int(11)")
                .HasColumnName("industry_id");
            entity.Property(e => e.MtrGrpCode)
                .HasMaxLength(25)
                .HasColumnName("mtr_grp_code");
            entity.Property(e => e.MtrGrpDesc)
                .HasMaxLength(255)
                .HasColumnName("mtr_grp_desc");
            entity.Property(e => e.ServiceId)
                .HasColumnType("int(11)")
                .HasColumnName("service_id");

            entity.HasOne(d => d.Industry).WithMany(p => p.IndustryMaterialGrps)
                .HasForeignKey(d => d.IndustryId)
                .HasConstraintName("FK_IndusID");

            entity.HasOne(d => d.Service).WithMany(p => p.IndustryMaterialGrps)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK_SERVID");
        });

        modelBuilder.Entity<PackageManual>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("package_manual");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.IndustryId)
                .HasColumnType("int(11)")
                .HasColumnName("industry_id");
            entity.Property(e => e.MaterialDescription)
                .HasMaxLength(255)
                .HasColumnName("material_description");
            entity.Property(e => e.PackNo)
                .HasColumnType("int(11)")
                .HasColumnName("pack_no");
            entity.Property(e => e.PackageName)
                .HasMaxLength(255)
                .HasColumnName("package_name");
            entity.Property(e => e.ProjectId)
                .HasColumnType("int(11)")
                .HasColumnName("project_id");
            entity.Property(e => e.Qty)
                .HasMaxLength(25)
                .HasColumnName("qty");
            entity.Property(e => e.Serial)
                .HasMaxLength(255)
                .HasColumnName("serial");
            entity.Property(e => e.Uom)
                .HasMaxLength(255)
                .HasColumnName("uom");
        });

        modelBuilder.Entity<PackagesDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("packages_details")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.PkgId, "FK_PKG_Header");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.InsertedDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("inserted_date");
            entity.Property(e => e.LineItem)
                .HasMaxLength(255)
                .HasColumnName("line_item");
            entity.Property(e => e.MGrp)
                .HasMaxLength(255)
                .HasColumnName("m_grp");
            entity.Property(e => e.MtrBatch)
                .HasMaxLength(255)
                .HasColumnName("mtr_batch");
            entity.Property(e => e.MtrCode)
                .HasMaxLength(255)
                .HasColumnName("mtr_code");
            entity.Property(e => e.MtrDesc)
                .HasMaxLength(255)
                .HasColumnName("mtr_desc");
            entity.Property(e => e.MtrLongDesc)
                .HasMaxLength(255)
                .HasColumnName("mtr_long_desc");
            entity.Property(e => e.MtrQty)
                .HasMaxLength(255)
                .HasColumnName("mtr_qty");
            entity.Property(e => e.MtrUom)
                .HasMaxLength(255)
                .HasColumnName("mtr_uom");
            entity.Property(e => e.PkgId)
                .HasColumnType("int(11)")
                .HasColumnName("pkg_id");
            entity.Property(e => e.PrDate).HasColumnName("pr_date");
            entity.Property(e => e.PrNum)
                .HasMaxLength(255)
                .HasColumnName("pr_num");
            entity.Property(e => e.Serial)
                .HasMaxLength(255)
                .HasColumnName("serial");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("user_id");

            entity.HasOne(d => d.Pkg).WithMany(p => p.PackagesDetails)
                .HasForeignKey(d => d.PkgId)
                .HasConstraintName("FK_PKG_Header");
        });

        modelBuilder.Entity<PackagesHeader>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("packages_header")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.AssignType)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("assign_type");
            entity.Property(e => e.AssignedBy)
                .HasColumnType("int(11)")
                .HasColumnName("assigned_by");
            entity.Property(e => e.Bid)
                .HasDefaultValueSql("'0'")
                .HasColumnName("bid");
            entity.Property(e => e.Cancelled)
                .HasDefaultValueSql("'0'")
                .HasColumnName("cancelled");
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("currency");
            entity.Property(e => e.ExclImport)
                .HasDefaultValueSql("'0'")
                .HasColumnName("excl_import");
            entity.Property(e => e.FilePath)
                .HasMaxLength(255)
                .HasColumnName("file_path");
            entity.Property(e => e.IndustryId)
                .HasColumnType("int(11)")
                .HasColumnName("industry_id");
            entity.Property(e => e.InsertedDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("inserted_date");
            entity.Property(e => e.IsService)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_service");
            entity.Property(e => e.PkgName)
                .HasMaxLength(255)
                .HasColumnName("pkg_name");
            entity.Property(e => e.PkgNum)
                .HasColumnType("int(11)")
                .HasColumnName("pkg_num");
            entity.Property(e => e.ProjectId)
                .HasColumnType("int(11)")
                .HasColumnName("project_id");
        });

        modelBuilder.Entity<PrServDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("pr_serv_details")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.HeaderId)
                .HasColumnType("int(11)")
                .HasColumnName("header_id");
            entity.Property(e => e.IndustryCode)
                .HasMaxLength(255)
                .HasColumnName("industry_code");
            entity.Property(e => e.InudstryDesc)
                .HasMaxLength(255)
                .HasColumnName("inudstry_desc");
            entity.Property(e => e.MtrGrpCode)
                .HasMaxLength(25)
                .HasColumnName("mtr_grp_code");
            entity.Property(e => e.MtrGrpDesc)
                .HasMaxLength(255)
                .HasColumnName("mtr_grp_desc");
        });

        modelBuilder.Entity<PrServHeader>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("pr_serv_header")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Descr)
                .HasMaxLength(255)
                .HasColumnName("descr");
        });

        modelBuilder.Entity<ProjBoq>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("proj_boq")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.BoqId, "FK_BoqID");

            entity.HasIndex(e => e.ProjId, "FK_ProjID");

            entity.Property(e => e.BoqId)
                .HasColumnType("smallint(6)")
                .HasColumnName("boq_id");
            entity.Property(e => e.ProjId)
                .HasColumnType("int(11)")
                .HasColumnName("proj_id");

            entity.HasOne(d => d.Boq).WithMany()
                .HasForeignKey(d => d.BoqId)
                .HasConstraintName("FK_BoqID");

            entity.HasOne(d => d.Proj).WithMany()
                .HasForeignKey(d => d.ProjId)
                .HasConstraintName("FK_ProjID");
        });

        modelBuilder.Entity<ProjPackage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("proj_packages")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.PrjId, "FKPJID");

            entity.HasIndex(e => e.BoqCptId, "FK_BOQ_CHI_ID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.BoqCptId)
                .HasColumnType("int(11)")
                .HasColumnName("boq_cpt_id");
            entity.Property(e => e.Comments)
                .HasMaxLength(255)
                .HasColumnName("comments");
            entity.Property(e => e.DateInserted)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("date_inserted");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.FileName)
                .HasMaxLength(255)
                .HasColumnName("file_name");
            entity.Property(e => e.FilePath)
                .HasMaxLength(5000)
                .HasColumnName("file_path");
            entity.Property(e => e.LinkOfDrive)
                .HasMaxLength(255)
                .HasColumnName("link_of_drive");
            entity.Property(e => e.PrjId)
                .HasColumnType("int(11)")
                .HasColumnName("prj_id");
            entity.Property(e => e.StartDate).HasColumnName("start_date");

            entity.HasOne(d => d.BoqCpt).WithMany(p => p.ProjPackages)
                .HasForeignKey(d => d.BoqCptId)
                .HasConstraintName("FK_BOQ_CHI_ID");

            entity.HasOne(d => d.Prj).WithMany(p => p.ProjPackages)
                .HasForeignKey(d => d.PrjId)
                .HasConstraintName("FKPJID");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("projects")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.AreaId, "FK_area_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.AreaId)
                .HasColumnType("int(11)")
                .HasColumnName("area_id");
            entity.Property(e => e.DeliveryPoint)
                .HasMaxLength(20)
                .HasColumnName("delivery_point");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.InsertedDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("inserted_date");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(50)
                .HasColumnName("project_name");
            entity.Property(e => e.ProjectNumb)
                .HasMaxLength(25)
                .HasColumnName("project_numb");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Area).WithMany(p => p.Projects)
                .HasForeignKey(d => d.AreaId)
                .HasConstraintName("FK_area_id");
        });

        modelBuilder.Entity<ProjectsArea>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("projects_area")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.AreaName)
                .HasMaxLength(25)
                .HasColumnName("area_name");
        });

        modelBuilder.Entity<ProjectsTender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("projects_tenders")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.ProjectId, "FK_PrjtID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.PackageName)
                .HasMaxLength(255)
                .HasColumnName("package_name");
            entity.Property(e => e.PackageNumb)
                .HasMaxLength(255)
                .HasColumnName("package_numb");
            entity.Property(e => e.PackageStatus)
                .HasMaxLength(255)
                .HasColumnName("package_status");
            entity.Property(e => e.ProjectId)
                .HasColumnType("int(11)")
                .HasColumnName("project_id");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectsTenders)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_PrjtID");
        });

        modelBuilder.Entity<ProjectsTenderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("projects_tender_details")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.ProjectId, "FK_ProjectID_");

            entity.HasIndex(e => e.PackageId, "FK_packageid_");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Details)
                .HasMaxLength(255)
                .HasColumnName("details");
            entity.Property(e => e.DocumentfileName)
                .HasMaxLength(255)
                .HasColumnName("documentfile_name");
            entity.Property(e => e.DocumentfilePath)
                .HasMaxLength(255)
                .HasColumnName("documentfile_path");
            entity.Property(e => e.PackageId)
                .HasColumnType("int(11)")
                .HasColumnName("package_id");
            entity.Property(e => e.ProjectId)
                .HasColumnType("int(11)")
                .HasColumnName("project_id");

            entity.HasOne(d => d.Package).WithMany(p => p.ProjectsTenderDetails)
                .HasForeignKey(d => d.PackageId)
                .HasConstraintName("FK_packageid_");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectsTenderDetails)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectID_");
        });

        modelBuilder.Entity<ReleasedPackage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("released_packages")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.IndustryId)
                .HasColumnType("int(11)")
                .HasColumnName("industry_id");
            entity.Property(e => e.InsertedDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("inserted_date");
            entity.Property(e => e.LineItem)
                .HasMaxLength(255)
                .HasColumnName("line_item");
            entity.Property(e => e.MGrp)
                .HasMaxLength(255)
                .HasColumnName("m_grp");
            entity.Property(e => e.MtrBatch)
                .HasMaxLength(255)
                .HasColumnName("mtr_batch");
            entity.Property(e => e.MtrCode)
                .HasMaxLength(255)
                .HasColumnName("mtr_code");
            entity.Property(e => e.MtrDesc)
                .HasMaxLength(255)
                .HasColumnName("mtr_desc");
            entity.Property(e => e.MtrLongDesc)
                .HasMaxLength(255)
                .HasColumnName("mtr_long_desc");
            entity.Property(e => e.MtrQty)
                .HasMaxLength(255)
                .HasColumnName("mtr_qty");
            entity.Property(e => e.MtrUom)
                .HasMaxLength(255)
                .HasColumnName("mtr_uom");
            entity.Property(e => e.PrDate).HasColumnName("pr_date");
            entity.Property(e => e.PrNum)
                .HasMaxLength(255)
                .HasColumnName("pr_num");
            entity.Property(e => e.ProjectId)
                .HasColumnType("int(11)")
                .HasColumnName("project_id");
        });

        modelBuilder.Entity<ResetPassword>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("reset_password")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.UserId, "FK_USRID");

            entity.HasIndex(e => e.Code, "code").HasAnnotation("MySql:FullTextIndex", true);

            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.InsertedTime)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("inserted_time");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_USRID");
        });

        modelBuilder.Entity<RevokedPackage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("revoked_packages")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Cancelled)
                .HasDefaultValueSql("'0'")
                .HasColumnName("cancelled");
            entity.Property(e => e.Cancelledrevoke)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("cancelledrevoke");
            entity.Property(e => e.IndustryId)
                .HasColumnType("int(11)")
                .HasColumnName("industry_id");
            entity.Property(e => e.InsertedDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("inserted_date");
            entity.Property(e => e.LineItem)
                .HasMaxLength(255)
                .HasColumnName("line_item");
            entity.Property(e => e.MGrp)
                .HasMaxLength(255)
                .HasColumnName("m_grp");
            entity.Property(e => e.MtrBatch)
                .HasMaxLength(255)
                .HasColumnName("mtr_batch");
            entity.Property(e => e.MtrCode)
                .HasMaxLength(255)
                .HasColumnName("mtr_code");
            entity.Property(e => e.MtrDesc)
                .HasMaxLength(255)
                .HasColumnName("mtr_desc");
            entity.Property(e => e.MtrLongDesc)
                .HasMaxLength(255)
                .HasColumnName("mtr_long_desc");
            entity.Property(e => e.MtrQty)
                .HasMaxLength(255)
                .HasColumnName("mtr_qty");
            entity.Property(e => e.MtrUom)
                .HasMaxLength(255)
                .HasColumnName("mtr_uom");
            entity.Property(e => e.PrDate).HasColumnName("pr_date");
            entity.Property(e => e.PrNum)
                .HasMaxLength(255)
                .HasColumnName("pr_num");
            entity.Property(e => e.ProjectId)
                .HasColumnType("int(11)")
                .HasColumnName("project_id");
            entity.Property(e => e.Serial)
                .HasMaxLength(255)
                .HasColumnName("serial");
        });

        modelBuilder.Entity<RevokedPkgManual>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("revoked_pkg_manual");

            entity.HasIndex(e => e.PkgId, "FK_PKGID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.InsertedDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("inserted_date");
            entity.Property(e => e.PkgId)
                .HasColumnType("int(11)")
                .HasColumnName("pkg_id");

            entity.HasOne(d => d.Pkg).WithMany(p => p.RevokedPkgManuals)
                .HasForeignKey(d => d.PkgId)
                .HasConstraintName("FK_PKGID");
        });

        modelBuilder.Entity<SapProject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sap_projects")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.AreaId, "FK_AREA");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.AreaId)
                .HasColumnType("int(11)")
                .HasColumnName("area_id");
            entity.Property(e => e.EnglishDesc)
                .HasMaxLength(255)
                .HasColumnName("english_desc");
            entity.Property(e => e.ProjName)
                .HasMaxLength(255)
                .HasColumnName("proj_name");
            entity.Property(e => e.ProjNum)
                .HasMaxLength(25)
                .HasColumnName("proj_num");

            entity.HasOne(d => d.Area).WithMany(p => p.SapProjects)
                .HasForeignKey(d => d.AreaId)
                .HasConstraintName("FK_AREA");
        });

        modelBuilder.Entity<SapProjectsStorloc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sap_projects_storloc")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.ProjectId, "FK_project_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.ProjectId)
                .HasColumnType("int(11)")
                .HasColumnName("project_id");
            entity.Property(e => e.StorageLocation)
                .HasMaxLength(255)
                .HasColumnName("storage_location");

            entity.HasOne(d => d.Project).WithMany(p => p.SapProjectsStorlocs)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_project_id");
        });

        modelBuilder.Entity<SapUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sap_users")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.AreasId, "FK_user_areas");

            entity.HasIndex(e => e.Fname, "idx_fname");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.AreasId)
                .HasColumnType("int(11)")
                .HasColumnName("areas_id");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .HasColumnName("city");
            entity.Property(e => e.CommentsSalesPerson).HasMaxLength(255);
            entity.Property(e => e.CommercialRegisterDocumentFilePath)
                .HasMaxLength(255)
                .HasColumnName("commercial_register_document_file_path");
            entity.Property(e => e.Company)
                .HasMaxLength(255)
                .HasColumnName("company");
            entity.Property(e => e.ElectronicInvoiceDocument)
                .HasMaxLength(255)
                .HasColumnName("electronic_invoice_document");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Engineersno)
                .HasMaxLength(25)
                .HasColumnName("engineersno");
            entity.Property(e => e.Equipment)
                .HasMaxLength(25)
                .HasColumnName("equipment");
            entity.Property(e => e.ExternalAddressNumberSale).HasMaxLength(255);
            entity.Property(e => e.Fax)
                .HasMaxLength(255)
                .HasColumnName("fax");
            entity.Property(e => e.Fname).HasColumnName("fname");
            entity.Property(e => e.IncomeTaxDocument)
                .HasMaxLength(255)
                .HasColumnName("income_tax_document");
            entity.Property(e => e.IsoDocumentFilePath)
                .HasMaxLength(255)
                .HasColumnName("iso_document_file_path");
            entity.Property(e => e.IsoVerifyed).HasColumnName("iso_verifyed");
            entity.Property(e => e.KeypersonMail)
                .HasMaxLength(255)
                .HasColumnName("keyperson_mail");
            entity.Property(e => e.KeypersonName)
                .HasMaxLength(255)
                .HasColumnName("keyperson_name");
            entity.Property(e => e.KeypersonPhone)
                .HasMaxLength(255)
                .HasColumnName("keyperson_phone");
            entity.Property(e => e.Lname)
                .HasMaxLength(25)
                .HasColumnName("lname");
            entity.Property(e => e.Moneybudget)
                .HasMaxLength(25)
                .HasColumnName("moneybudget");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(25)
                .HasColumnName("phone");
            entity.Property(e => e.PhoneTwo)
                .HasMaxLength(255)
                .HasColumnName("phone_two");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(255)
                .HasColumnName("postal_code");
            entity.Property(e => e.PrevWorkDocumentFilePath)
                .HasMaxLength(255)
                .HasColumnName("prev_work_document_file_path");
            entity.Property(e => e.Projectno)
                .HasMaxLength(15)
                .HasColumnName("projectno");
            entity.Property(e => e.Refused).HasColumnName("refused");
            entity.Property(e => e.SalesPersonEmail).HasMaxLength(255);
            entity.Property(e => e.SapCode)
                .HasMaxLength(255)
                .HasColumnName("sap_code");
            entity.Property(e => e.TaxId)
                .HasMaxLength(255)
                .HasColumnName("tax_id");
            entity.Property(e => e.TaxidDocumentFilePath)
                .HasMaxLength(255)
                .HasColumnName("taxid_document_file_path");
            entity.Property(e => e.UploadedData).HasColumnName("uploaded_data");
            entity.Property(e => e.UserDatetime)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("user_datetime");
            entity.Property(e => e.Username)
                .HasMaxLength(25)
                .HasColumnName("username");
            entity.Property(e => e.Verifyied).HasColumnName("verifyied");
        });

        modelBuilder.Entity<ServiceHeader>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("service_header")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.EnglishDesc)
                .HasMaxLength(255)
                .HasColumnName("english_desc");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ServiceMtrGrp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("service_mtr_grp")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.MtrSrvId, "FK_Srv_Mtr_ID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.MtrSrvGrpCode)
                .HasMaxLength(50)
                .HasColumnName("mtr_srv_grp_code");
            entity.Property(e => e.MtrSrvGrpDesc)
                .HasMaxLength(50)
                .HasColumnName("mtr_srv_grp_desc");
            entity.Property(e => e.MtrSrvId)
                .HasColumnType("int(11)")
                .HasColumnName("mtr_srv_id");

            entity.HasOne(d => d.MtrSrv).WithMany(p => p.ServiceMtrGrps)
                .HasForeignKey(d => d.MtrSrvId)
                .HasConstraintName("FK_Srv_Mtr_ID");
        });

        modelBuilder.Entity<ServicesIndustry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("services_industries")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.HeaderId, "FK_Service_Header");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Descr)
                .HasMaxLength(255)
                .HasColumnName("descr");
            entity.Property(e => e.EnglishDesc)
                .HasMaxLength(255)
                .HasColumnName("english_desc");
            entity.Property(e => e.HeaderId)
                .HasColumnType("int(11)")
                .HasColumnName("header_id");
            entity.Property(e => e.IndustryCode)
                .HasMaxLength(15)
                .HasColumnName("industry_code");

            entity.HasOne(d => d.Header).WithMany(p => p.ServicesIndustries)
                .HasForeignKey(d => d.HeaderId)
                .HasConstraintName("FK_Service_Header");
        });

        modelBuilder.Entity<SiacAdmin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("siac_admin")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");
        });

        modelBuilder.Entity<SrvMtr>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("srv_mtr")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.MtrCode)
                .HasMaxLength(50)
                .HasColumnName("mtr_code");
            entity.Property(e => e.MtrDesc)
                .HasMaxLength(50)
                .HasColumnName("mtr_desc");
            entity.Property(e => e.ServCode)
                .HasMaxLength(50)
                .HasColumnName("serv_code");
            entity.Property(e => e.ServDesc)
                .HasMaxLength(50)
                .HasColumnName("serv_desc");
        });

        modelBuilder.Entity<SupportedArea>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("supported_areas")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.AreaName)
                .HasMaxLength(25)
                .HasColumnName("area_name");
        });

        modelBuilder.Entity<TempTaxId>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("temp_tax_id")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.SapCode)
                .HasMaxLength(255)
                .HasColumnName("sap_code");
            entity.Property(e => e.TaxId)
                .HasMaxLength(255)
                .HasColumnName("tax_id");
        });

        modelBuilder.Entity<UserActivity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("user_activities")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.UserId, "FK_USerID");

            entity.HasIndex(e => e.AcitivityDetailsId, "FK_activity_details_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.AcitivityDetailsId)
                .HasColumnType("int(11)")
                .HasColumnName("acitivity_details_id");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("user_id");

            entity.HasOne(d => d.AcitivityDetails).WithMany(p => p.UserActivities)
                .HasForeignKey(d => d.AcitivityDetailsId)
                .HasConstraintName("FK_activity_details_id");

            entity.HasOne(d => d.User).WithMany(p => p.UserActivities)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_USerID");
        });

        modelBuilder.Entity<UserDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("user_detail")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.IndustriesDetails, "FK_Activities");

            entity.HasIndex(e => e.TypeId, "FK_typeid");

            entity.HasIndex(e => e.UserId, "FK_userid_");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CurrentDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("current_date");
            entity.Property(e => e.IndustriesDetails)
                .HasColumnType("int(11)")
                .HasColumnName("industries_details");
            entity.Property(e => e.TypeId)
                .HasColumnType("int(11)")
                .HasColumnName("type_id");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("user_id");

            entity.HasOne(d => d.IndustriesDetailsNavigation).WithMany(p => p.UserDetails)
                .HasForeignKey(d => d.IndustriesDetails)
                .HasConstraintName("FK_Industries");

            entity.HasOne(d => d.Type).WithMany(p => p.UserDetails)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("FK_typeid");

            entity.HasOne(d => d.User).WithMany(p => p.UserDetails)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_userid_");
        });

        modelBuilder.Entity<UserHeader>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("user_header")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.AreasId, "FK_user_areas");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.AreasId)
                .HasColumnType("int(11)")
                .HasColumnName("areas_id");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .HasColumnName("city");
            entity.Property(e => e.CommentsSalesPerson).HasMaxLength(255);
            entity.Property(e => e.CommercialRegisterDocumentFilePath)
                .HasMaxLength(255)
                .HasColumnName("commercial_register_document_file_path");
            entity.Property(e => e.CommercialRegisterExpiration).HasColumnName("commercial_register_expiration");
            entity.Property(e => e.Company)
                .HasMaxLength(255)
                .HasColumnName("company");
            entity.Property(e => e.CompanyAddress)
                .HasMaxLength(25)
                .HasColumnName("company_address");
            entity.Property(e => e.CompanyPhone)
                .HasMaxLength(25)
                .HasColumnName("company_phone");
            entity.Property(e => e.ElectronicInvoiceDocument)
                .HasMaxLength(255)
                .HasColumnName("electronic_invoice_document");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Engineersno)
                .HasMaxLength(25)
                .HasColumnName("engineersno");
            entity.Property(e => e.Equipment)
                .HasMaxLength(25)
                .HasColumnName("equipment");
            entity.Property(e => e.ExternalAddressNumberSale).HasMaxLength(255);
            entity.Property(e => e.Fax)
                .HasMaxLength(255)
                .HasColumnName("fax");
            entity.Property(e => e.Fname)
                .HasMaxLength(255)
                .HasColumnName("fname");
            entity.Property(e => e.IdNumDocumentFilePath)
                .HasMaxLength(255)
                .HasColumnName("id_num_document_file_path");
            entity.Property(e => e.IdcardDocument)
                .HasMaxLength(255)
                .HasColumnName("idcard_document");
            entity.Property(e => e.IncomeTaxDocument)
                .HasMaxLength(255)
                .HasColumnName("income_tax_document");
            entity.Property(e => e.IncomeTaxExpiration).HasColumnName("income_tax_expiration");
            entity.Property(e => e.IsoDocumentFilePath)
                .HasMaxLength(255)
                .HasColumnName("iso_document_file_path");
            entity.Property(e => e.IsoVerifyed)
                .HasDefaultValueSql("'0'")
                .HasColumnName("iso_verifyed");
            entity.Property(e => e.KeypersonMail)
                .HasMaxLength(255)
                .HasColumnName("keyperson_mail");
            entity.Property(e => e.KeypersonName)
                .HasMaxLength(255)
                .HasColumnName("keyperson_name");
            entity.Property(e => e.KeypersonPhone)
                .HasMaxLength(255)
                .HasColumnName("keyperson_phone");
            entity.Property(e => e.Lname)
                .HasMaxLength(25)
                .HasColumnName("lname");
            entity.Property(e => e.Moneybudget)
                .HasMaxLength(25)
                .HasColumnName("moneybudget");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(25)
                .HasColumnName("phone");
            entity.Property(e => e.PhoneTwo)
                .HasMaxLength(255)
                .HasColumnName("phone_two");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(255)
                .HasColumnName("postal_code");
            entity.Property(e => e.PrevWorkDocumentFilePath)
                .HasMaxLength(255)
                .HasColumnName("prev_work_document_file_path");
            entity.Property(e => e.Projectno)
                .HasMaxLength(15)
                .HasColumnName("projectno");
            entity.Property(e => e.Refused)
                .HasDefaultValueSql("'0'")
                .HasColumnName("refused");
            entity.Property(e => e.SalesPersonEmail).HasMaxLength(255);
            entity.Property(e => e.SapCode)
                .HasMaxLength(255)
                .HasColumnName("sap_code");
            entity.Property(e => e.TaxId)
                .HasMaxLength(255)
                .HasColumnName("tax_id");
            entity.Property(e => e.TaxIdExpiration).HasColumnName("tax_id_expiration");
            entity.Property(e => e.TaxidDocumentFilePath)
                .HasMaxLength(255)
                .HasColumnName("taxid_document_file_path");
            entity.Property(e => e.UploadedData)
                .HasDefaultValueSql("'0'")
                .HasColumnName("uploaded_data");
            entity.Property(e => e.UserDatetime)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("user_datetime");
            entity.Property(e => e.Username)
                .HasMaxLength(25)
                .HasColumnName("username");
            entity.Property(e => e.Verifyied)
                .HasDefaultValueSql("'0'")
                .HasColumnName("verifyied");

            entity.HasOne(d => d.Areas).WithMany(p => p.UserHeaders)
                .HasForeignKey(d => d.AreasId)
                .HasConstraintName("FK_user_areas");
        });

        modelBuilder.Entity<UserKeyPerson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("user_key_persons")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .HasColumnName("phone");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<UsersBidding>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("users_bidding")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.PkgId, "PKGID");

            entity.HasIndex(e => e.UserId, "USRID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DateInserted)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("date_inserted");
            entity.Property(e => e.FilePath)
                .HasMaxLength(255)
                .HasColumnName("file_path");
            entity.Property(e => e.PkgId)
                .HasColumnType("int(11)")
                .HasColumnName("pkg_id");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("user_id");

            entity.HasOne(d => d.Pkg).WithMany(p => p.UsersBiddings)
                .HasForeignKey(d => d.PkgId)
                .HasConstraintName("PKGID");

            entity.HasOne(d => d.User).WithMany(p => p.UsersBiddings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("USRID");
        });

        modelBuilder.Entity<UsersComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("users_comments")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Comment)
                .HasMaxLength(255)
                .HasColumnName("comment");
            entity.Property(e => e.DateInserted)
                .HasMaxLength(255)
                .HasColumnName("date_inserted");
            entity.Property(e => e.PkgId)
                .HasColumnType("int(11)")
                .HasColumnName("pkg_id");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<UsersOffer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("users_offers")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.PackageId, "PKG_ID__");

            entity.HasIndex(e => e.UserId, "USRID_");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.FileName)
                .HasMaxLength(255)
                .HasColumnName("file_name");
            entity.Property(e => e.FilePath)
                .HasMaxLength(2555)
                .HasColumnName("file_path");
            entity.Property(e => e.OfferDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("offer_date");
            entity.Property(e => e.PackageId)
                .HasColumnType("int(11)")
                .HasColumnName("package_id");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("user_id");

            entity.HasOne(d => d.Package).WithMany(p => p.UsersOffers)
                .HasForeignKey(d => d.PackageId)
                .HasConstraintName("PKG_ID_");

            entity.HasOne(d => d.User).WithMany(p => p.UsersOffers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("USRID_");
        });

        modelBuilder.Entity<UsersType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("users_types")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<VendorBidding>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("vendor_biddings")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.AdvancedPayment)
                .HasMaxLength(255)
                .HasColumnName("advanced_payment");
            entity.Property(e => e.Comment)
                .HasMaxLength(255)
                .HasColumnName("comment");
            entity.Property(e => e.DeliveryDate).HasColumnName("delivery_date");
            entity.Property(e => e.DurationDays)
                .HasMaxLength(15)
                .HasColumnName("duration_days");
            entity.Property(e => e.FilePath)
                .HasMaxLength(255)
                .HasColumnName("file_path");
            entity.Property(e => e.InsertedDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("inserted_date");
            entity.Property(e => e.MaterialPayment)
                .HasMaxLength(20)
                .HasColumnName("material_payment");
            entity.Property(e => e.PkgDetailsId)
                .HasColumnType("int(11)")
                .HasColumnName("pkg_details_id");
            entity.Property(e => e.Price)
                .HasMaxLength(255)
                .HasColumnName("price");
            entity.Property(e => e.Rejected)
                .HasDefaultValueSql("'0'")
                .HasColumnName("rejected");
            entity.Property(e => e.TechnicalApproval)
                .HasMaxLength(25)
                .HasColumnName("technical_approval");
            entity.Property(e => e.Transportation)
                .HasMaxLength(15)
                .HasColumnName("transportation");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("user_id");
            entity.Property(e => e.WorksPayment)
                .HasMaxLength(20)
                .HasColumnName("works_payment");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

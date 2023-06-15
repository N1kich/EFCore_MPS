using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFCore_MPS.Models;

public partial class MpsContext : DbContext
{
    public MpsContext()
    {
    }

    public MpsContext(DbContextOptions<MpsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DefectCorrection> DefectCorrections { get; set; }

    public virtual DbSet<DefectList> DefectLists { get; set; }

    public virtual DbSet<DefectListView> DefectListViews { get; set; }

    public virtual DbSet<DisposalList> DisposalLists { get; set; }

    public virtual DbSet<DisposalListView> DisposalListViews { get; set; }

    public virtual DbSet<DisposalReason> DisposalReasons { get; set; }

    public virtual DbSet<InventoryReport> InventoryReports { get; set; }

    public virtual DbSet<Mp> Mps { get; set; }

    public virtual DbSet<NotificationList> NotificationLists { get; set; }

    public virtual DbSet<NotificationListView> NotificationListViews { get; set; }

    public virtual DbSet<PlaceStorage> PlaceStorages { get; set; }

    public virtual DbSet<RegistrationMpsView> RegistrationMpsViews { get; set; }

    public virtual DbSet<StatusMp> StatusMps { get; set; }

    public virtual DbSet<SupplierMp> SupplierMps { get; set; }

    public virtual DbSet<TypeDefect> TypeDefects { get; set; }

    public virtual DbSet<TypeMp> TypeMps { get; set; }

    public virtual DbSet<UnitMeasurementsMp> UnitMeasurementsMps { get; set; }

    public virtual DbSet<View2> View2s { get; set; }

    public virtual DbSet<View3> View3s { get; set; }

    public virtual DbSet<View4> View4s { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-Q7UDDS1\\SQLEXPRESS;Initial Catalog=mps;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DefectCorrection>(entity =>
        {
            entity.HasKey(e => e.IdCorrection);

            entity.ToTable("defect_correction");

            entity.Property(e => e.IdCorrection)
                .ValueGeneratedNever()
                .HasColumnName("id_correction");
            entity.Property(e => e.TypeCorrection)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type_correction");
        });

        modelBuilder.Entity<DefectList>(entity =>
        {
            entity.HasKey(e => e.IdDefectList);

            entity.ToTable("defect_list");

            entity.Property(e => e.IdDefectList)
                .ValueGeneratedNever()
                .HasColumnName("id_defect_list");
            entity.Property(e => e.AmountDefectMps).HasColumnName("amount_defect_mps");
            entity.Property(e => e.DateDefect)
                .HasColumnType("date")
                .HasColumnName("date_defect");
            entity.Property(e => e.DescriptionDefect)
                .HasColumnType("text")
                .HasColumnName("description_defect");
            entity.Property(e => e.IdCorrection).HasColumnName("id_correction");
            entity.Property(e => e.IdDefect).HasColumnName("id_defect");
            entity.Property(e => e.IdMps).HasColumnName("id_mps");

            entity.HasOne(d => d.IdCorrectionNavigation).WithMany(p => p.DefectLists)
                .HasForeignKey(d => d.IdCorrection)
                .HasConstraintName("FK_defect_list_defect_correction");

            entity.HasOne(d => d.IdDefectNavigation).WithMany(p => p.DefectLists)
                .HasForeignKey(d => d.IdDefect)
                .HasConstraintName("FK_defect_list_defect_type");

            entity.HasOne(d => d.IdMpsNavigation).WithMany(p => p.DefectLists)
                .HasForeignKey(d => d.IdMps)
                .HasConstraintName("FK_defect_list_mps");
        });

        modelBuilder.Entity<DefectListView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("DefectListView");

            entity.Property(e => e.ДатаОбнаруженияДефетка)
                .HasColumnType("date")
                .HasColumnName("Дата обнаружения дефетка");
            entity.Property(e => e.КодМпз)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Код МПЗ");
            entity.Property(e => e.НаименованиеМпз)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Наименование МПЗ");
            entity.Property(e => e.ОписаниеБрака)
                .HasColumnType("text")
                .HasColumnName("Описание брака");
            entity.Property(e => e.ТипБрака)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Тип брака");
            entity.Property(e => e.ТипИсправленияДефекта)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Тип исправления дефекта");
        });

        modelBuilder.Entity<DisposalList>(entity =>
        {
            entity.HasKey(e => e.IdDisposal);

            entity.ToTable("disposal_list");

            entity.Property(e => e.IdDisposal)
                .ValueGeneratedNever()
                .HasColumnName("id_disposal");
            entity.Property(e => e.AmountDisposal).HasColumnName("amount_disposal");
            entity.Property(e => e.DescriptionDisposal)
                .HasColumnType("text")
                .HasColumnName("description_disposal");
            entity.Property(e => e.DisposalDate)
                .HasColumnType("date")
                .HasColumnName("disposal_date");
            entity.Property(e => e.IdDisposalReason).HasColumnName("id_disposal_reason");
            entity.Property(e => e.IdMps).HasColumnName("id_mps");
            entity.Property(e => e.IdStatusMps).HasColumnName("id_status_mps");
            entity.Property(e => e.IdWorker).HasColumnName("id_worker");

            entity.HasOne(d => d.IdDisposalReasonNavigation).WithMany(p => p.DisposalLists)
                .HasForeignKey(d => d.IdDisposalReason)
                .HasConstraintName("FK_disposal_list_disposal_reason");

            entity.HasOne(d => d.IdMpsNavigation).WithMany(p => p.DisposalLists)
                .HasForeignKey(d => d.IdMps)
                .HasConstraintName("FK_disposal_list_mps");

            entity.HasOne(d => d.IdStatusMpsNavigation).WithMany(p => p.DisposalLists)
                .HasForeignKey(d => d.IdStatusMps)
                .HasConstraintName("FK_disposal_list_status_mps");

            entity.HasOne(d => d.IdWorkerNavigation).WithMany(p => p.DisposalLists)
                .HasForeignKey(d => d.IdWorker)
                .HasConstraintName("FK_disposal_list_worker");
        });

        modelBuilder.Entity<DisposalListView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("DisposalListView");

            entity.Property(e => e.ДатаСписания)
                .HasColumnType("date")
                .HasColumnName("Дата списания");
            entity.Property(e => e.КодМпз)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Код МПЗ");
            entity.Property(e => e.КоличествоНаСписание).HasColumnName("Количество на списание");
            entity.Property(e => e.Наименование)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Описание).HasColumnType("text");
            entity.Property(e => e.Ответственный)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ПричинаСписания)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Причина списания");
            entity.Property(e => e.СтатусМпз)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Статус МПЗ");
        });

        modelBuilder.Entity<DisposalReason>(entity =>
        {
            entity.HasKey(e => e.IdDisposalReason);

            entity.ToTable("disposal_reason");

            entity.Property(e => e.IdDisposalReason)
                .ValueGeneratedNever()
                .HasColumnName("id_disposal_reason");
            entity.Property(e => e.DisposalReason1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("disposal_reason");
        });

        modelBuilder.Entity<InventoryReport>(entity =>
        {
            entity.HasKey(e => e.IdReportInventorisation);

            entity.ToTable("inventory_report");

            entity.Property(e => e.IdReportInventorisation)
                .ValueGeneratedNever()
                .HasColumnName("id_report_inventorisation");
            entity.Property(e => e.AmountReport).HasColumnName("amount_report");
            entity.Property(e => e.DateReportInventorisation)
                .HasColumnType("date")
                .HasColumnName("date_report_inventorisation");
            entity.Property(e => e.DiscrepancyReason)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("discrepancy_reason");
            entity.Property(e => e.IdMps).HasColumnName("id_mps");
            entity.Property(e => e.IdPlaceStorage).HasColumnName("id_place_storage");
            entity.Property(e => e.IdWorker).HasColumnName("id_worker");

            entity.HasOne(d => d.IdMpsNavigation).WithMany(p => p.InventoryReports)
                .HasForeignKey(d => d.IdMps)
                .HasConstraintName("FK_inventory_report_mps");

            entity.HasOne(d => d.IdPlaceStorageNavigation).WithMany(p => p.InventoryReports)
                .HasForeignKey(d => d.IdPlaceStorage)
                .HasConstraintName("FK_inventory_report_place_storage");

            entity.HasOne(d => d.IdWorkerNavigation).WithMany(p => p.InventoryReports)
                .HasForeignKey(d => d.IdWorker)
                .HasConstraintName("FK_inventory_report_worker");
        });

        modelBuilder.Entity<Mp>(entity =>
        {
            entity.HasKey(e => e.IdMps);

            entity.ToTable("mps");

            entity.Property(e => e.IdMps)
                .ValueGeneratedNever()
                .HasColumnName("id_mps");
            entity.Property(e => e.AmountMps).HasColumnName("amount_mps");
            entity.Property(e => e.ArrivalDateMps)
                .HasColumnType("date")
                .HasColumnName("arrival_date_mps");
            entity.Property(e => e.CodeMps)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("code_mps");
            entity.Property(e => e.ExpireDateMps)
                .HasColumnType("date")
                .HasColumnName("expire_date_mps");
            entity.Property(e => e.IdMeasurements).HasColumnName("id_measurements");
            entity.Property(e => e.IdSupplier).HasColumnName("id_supplier");
            entity.Property(e => e.IdTypeMps).HasColumnName("id_type_mps");
            entity.Property(e => e.NameMps)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name_mps");
            entity.Property(e => e.PricePerUnitMps)
                .HasColumnType("money")
                .HasColumnName("price_per_unit_mps");
            entity.Property(e => e.TotalCostMps)
                .HasColumnType("money")
                .HasColumnName("total_cost_mps");

            entity.HasOne(d => d.IdMeasurementsNavigation).WithMany(p => p.Mps)
                .HasForeignKey(d => d.IdMeasurements)
                .HasConstraintName("FK_mps_unit_measurements");

            entity.HasOne(d => d.IdSupplierNavigation).WithMany(p => p.Mps)
                .HasForeignKey(d => d.IdSupplier)
                .HasConstraintName("FK_mps_supplier");

            entity.HasOne(d => d.IdTypeMpsNavigation).WithMany(p => p.Mps)
                .HasForeignKey(d => d.IdTypeMps)
                .HasConstraintName("FK_mps_type_mps");
        });

        modelBuilder.Entity<NotificationList>(entity =>
        {
            entity.HasKey(e => e.IdNotification);

            entity.ToTable("notification_list");

            entity.Property(e => e.IdNotification)
                .ValueGeneratedNever()
                .HasColumnName("id_notification");
            entity.Property(e => e.DateNotification)
                .HasColumnType("date")
                .HasColumnName("date_notification");
            entity.Property(e => e.DescriptionNotification)
                .HasColumnType("text")
                .HasColumnName("description_notification");
            entity.Property(e => e.IdWorker).HasColumnName("id_worker");

            entity.HasOne(d => d.IdWorkerNavigation).WithMany(p => p.NotificationLists)
                .HasForeignKey(d => d.IdWorker)
                .HasConstraintName("FK_notification_list_worker");
        });

        modelBuilder.Entity<NotificationListView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("NotificationListView");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ДатаУведомления)
                .HasColumnType("date")
                .HasColumnName("Дата уведомления");
            entity.Property(e => e.Сообщение).HasColumnType("text");
            entity.Property(e => e.Сотрудник)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PlaceStorage>(entity =>
        {
            entity.HasKey(e => e.IdPlaceStorage);

            entity.ToTable("place_storage");

            entity.Property(e => e.IdPlaceStorage)
                .ValueGeneratedNever()
                .HasColumnName("id_place_storage");
            entity.Property(e => e.PlaceStorage1)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("place_storage");
        });

        modelBuilder.Entity<RegistrationMpsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("RegistrationMpsView");

            entity.Property(e => e.ArrivalDate).HasColumnType("date");
            entity.Property(e => e.CodeMps)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.ExpireDate).HasColumnType("date");
            entity.Property(e => e.IdMps).HasColumnName("id_mps");
            entity.Property(e => e.MeasureType)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.MpsType)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PricePerUnit).HasColumnType("money");
            entity.Property(e => e.Supplier)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.TotalCost).HasColumnType("money");
        });

        modelBuilder.Entity<StatusMp>(entity =>
        {
            entity.HasKey(e => e.IdStatusMps);

            entity.ToTable("status_mps");

            entity.Property(e => e.IdStatusMps)
                .ValueGeneratedNever()
                .HasColumnName("id_status_mps");
            entity.Property(e => e.NameStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name_status");
        });

        modelBuilder.Entity<SupplierMp>(entity =>
        {
            entity.HasKey(e => e.IdSupplier);

            entity.ToTable("supplier_mps");

            entity.Property(e => e.IdSupplier)
                .ValueGeneratedNever()
                .HasColumnName("id_supplier");
            entity.Property(e => e.AddressCompany)
                .HasColumnType("text")
                .HasColumnName("address_company");
            entity.Property(e => e.EmailCompany)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("email_company");
            entity.Property(e => e.NameCompany)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("name_company");
            entity.Property(e => e.PhoneNumberCompany)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("phone_number_company");
        });

        modelBuilder.Entity<TypeDefect>(entity =>
        {
            entity.HasKey(e => e.IdDefect);

            entity.ToTable("type_defect");

            entity.Property(e => e.IdDefect)
                .ValueGeneratedNever()
                .HasColumnName("id_defect");
            entity.Property(e => e.TypeDefect1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type_defect");
        });

        modelBuilder.Entity<TypeMp>(entity =>
        {
            entity.HasKey(e => e.IdTypeMps);

            entity.ToTable("type_mps");

            entity.Property(e => e.IdTypeMps)
                .ValueGeneratedNever()
                .HasColumnName("id_type_mps");
            entity.Property(e => e.TypeMps)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("type_mps");
        });

        modelBuilder.Entity<UnitMeasurementsMp>(entity =>
        {
            entity.HasKey(e => e.IdMeasurements);

            entity.ToTable("unit_measurements_mps");

            entity.Property(e => e.IdMeasurements)
                .ValueGeneratedNever()
                .HasColumnName("id_measurements");
            entity.Property(e => e.NameMeasurements)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("name_measurements");
        });

        modelBuilder.Entity<View2>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_2");

            entity.Property(e => e.CodeMps)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.CorrectionDefectType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateDefect).HasColumnType("date");
            entity.Property(e => e.DefectDesription).HasColumnType("text");
            entity.Property(e => e.DefectType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NameMps)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<View3>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_3");

            entity.Property(e => e.CodeMps)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.DisposalDate).HasColumnType("date");
            entity.Property(e => e.DisposalDescription).HasColumnType("text");
            entity.Property(e => e.DisposalReason)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NameMps)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StatusMps)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Worker)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<View4>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_4");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Message).HasColumnType("text");
            entity.Property(e => e.NotificationDate).HasColumnType("date");
            entity.Property(e => e.Worker)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.IdWorker);

            entity.ToTable("worker");

            entity.Property(e => e.IdWorker)
                .ValueGeneratedNever()
                .HasColumnName("id_worker");
            entity.Property(e => e.AddressWorker)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("address_worker");
            entity.Property(e => e.AgeWorker).HasColumnName("age_worker");
            entity.Property(e => e.EmailWorker)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email_worker");
            entity.Property(e => e.FullnameWorker)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fullname_worker");
            entity.Property(e => e.GenderWorker)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("gender_worker");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

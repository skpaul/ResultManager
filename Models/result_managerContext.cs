﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ResultManager.Models
{
    public partial class result_managerContext : DbContext
    {
        public result_managerContext()
        {
        }

        public result_managerContext(DbContextOptions<result_managerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Applicants> Applicants { get; set; }
        public virtual DbSet<DistrictDistribution> DistrictDistribution { get; set; }
        public virtual DbSet<Districts> Districts { get; set; }
        public virtual DbSet<DivisionDistribution> DivisionDistribution { get; set; }
        public virtual DbSet<Divisions> Divisions { get; set; }
        public virtual DbSet<Marks> Marks { get; set; }
        public virtual DbSet<PostDistribution> PostDistribution { get; set; }
        public virtual DbSet<PostQuotaDivision> PostQuotaDivision { get; set; }
        public virtual DbSet<PostQuotaDivisionDistrict> PostQuotaDivisionDistrict { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<Quotas> Quotas { get; set; }
        public virtual DbSet<SelectedApplicants> SelectedApplicants { get; set; }
        public virtual DbSet<View1> View1 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;userid=root;password=;database=result_manager;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Applicants>(entity =>
            {
                entity.HasKey(e => e.ApplicantId)
                    .HasName("PRIMARY");

                entity.ToTable("applicants");

                entity.Property(e => e.ApplicantId)
                    .HasColumnName("applicantId")
                    .HasColumnType("int(3)");

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Ffq)
                    .HasColumnName("ffq")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IsSelected).HasColumnName("isSelected");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(27)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PermanentDistrict)
                    .HasColumnName("permanentDistrict")
                    .HasMaxLength(200)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PostCode)
                    .HasColumnName("postCode")
                    .HasColumnType("int(3)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PostName)
                    .HasColumnName("postName")
                    .HasMaxLength(200)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PresentDistrict)
                    .HasColumnName("presentDistrict")
                    .HasMaxLength(200)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.RejectedCriteria)
                    .HasColumnName("rejectedCriteria")
                    .HasMaxLength(150)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Religion)
                    .HasColumnName("religion")
                    .HasMaxLength(9)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Roll)
                    .HasColumnName("roll")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SelectionCriteria)
                    .IsRequired()
                    .HasColumnName("selectionCriteria")
                    .HasMaxLength(150);

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasMaxLength(6)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<DistrictDistribution>(entity =>
            {
                entity.ToTable("district_distribution");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DecimalQuantity)
                    .HasColumnName("decimalQuantity")
                    .HasColumnType("double(12,10)");

                entity.Property(e => e.DistrictId)
                    .HasColumnName("districtId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DistrictName)
                    .IsRequired()
                    .HasColumnName("districtName")
                    .HasMaxLength(200);

                entity.Property(e => e.DistrictPercentage)
                    .HasColumnName("districtPercentage")
                    .HasColumnType("double(5,3)");

                entity.Property(e => e.DivisionId)
                    .HasColumnName("divisionId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DivisionName)
                    .IsRequired()
                    .HasColumnName("divisionName")
                    .HasMaxLength(100);

                entity.Property(e => e.DivisionalQuantity)
                    .HasColumnName("divisionalQuantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FoundQuantity)
                    .HasColumnName("foundQuantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RoundedQuantity)
                    .HasColumnName("roundedQuantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TotalVacancy)
                    .HasColumnName("totalVacancy")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Districts>(entity =>
            {
                entity.HasKey(e => e.DistrictId)
                    .HasName("PRIMARY");

                entity.ToTable("districts");

                entity.Property(e => e.DistrictId)
                    .HasColumnName("districtId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DistrictName)
                    .IsRequired()
                    .HasColumnName("districtName")
                    .HasMaxLength(200);

                entity.Property(e => e.DivisionName)
                    .IsRequired()
                    .HasColumnName("divisionName")
                    .HasMaxLength(200);

                entity.Property(e => e.Percentage)
                    .HasColumnName("percentage")
                    .HasColumnType("double(12,10)");
            });

            modelBuilder.Entity<DivisionDistribution>(entity =>
            {
                entity.ToTable("division_distribution");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DecimalQuantity)
                    .HasColumnName("decimalQuantity")
                    .HasColumnType("double(12,10)");

                entity.Property(e => e.DivisionId)
                    .HasColumnName("divisionId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DivisionName)
                    .IsRequired()
                    .HasColumnName("divisionName")
                    .HasMaxLength(200);

                entity.Property(e => e.FoundQuantity)
                    .HasColumnName("foundQuantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Percentage)
                    .HasColumnName("percentage")
                    .HasColumnType("double(5,3)");

                entity.Property(e => e.RoundedQuantity)
                    .HasColumnName("roundedQuantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TotalVacancy)
                    .HasColumnName("totalVacancy")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Divisions>(entity =>
            {
                entity.HasKey(e => e.DivisionId)
                    .HasName("PRIMARY");

                entity.ToTable("divisions");

                entity.Property(e => e.DivisionId)
                    .HasColumnName("divisionId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DivisionName)
                    .IsRequired()
                    .HasColumnName("divisionName")
                    .HasMaxLength(200);

                entity.Property(e => e.Percentage)
                    .HasColumnName("percentage")
                    .HasColumnType("double(12,10)");
            });

            modelBuilder.Entity<Marks>(entity =>
            {
                entity.ToTable("marks");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Roll)
                    .HasColumnName("roll")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("double(5,2)");

                entity.Property(e => e.Viva)
                    .HasColumnName("viva")
                    .HasColumnType("double(4,2)");

                entity.Property(e => e.Written)
                    .HasColumnName("written")
                    .HasColumnType("double(4,2)");
            });

            modelBuilder.Entity<PostDistribution>(entity =>
            {
                entity.ToTable("post_distribution");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ApplicantFound)
                    .HasColumnName("applicantFound")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ApplicantTransferredToGeneral)
                    .HasColumnName("applicantTransferredToGeneral")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DecimalQuantity)
                    .HasColumnName("decimalQuantity")
                    .HasColumnType("double(12,10)");

                entity.Property(e => e.PostId)
                    .HasColumnName("postId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PostName)
                    .IsRequired()
                    .HasColumnName("postName")
                    .HasMaxLength(200);

                entity.Property(e => e.QuotaName)
                    .IsRequired()
                    .HasColumnName("quotaName")
                    .HasMaxLength(200);

                entity.Property(e => e.QuotaPercentage)
                    .HasColumnName("quotaPercentage")
                    .HasColumnType("double(5,3)");

                entity.Property(e => e.RoundedQuantity)
                    .HasColumnName("roundedQuantity")
                    .HasColumnType("double(5,2)");

                entity.Property(e => e.Vacancies)
                    .HasColumnName("vacancies")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<PostQuotaDivision>(entity =>
            {
                entity.ToTable("post_quota_division");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DecimalQuantity)
                    .HasColumnName("decimalQuantity")
                    .HasColumnType("double(12,10)");

                entity.Property(e => e.DivisionName)
                    .IsRequired()
                    .HasColumnName("divisionName")
                    .HasMaxLength(200);

                entity.Property(e => e.FoundQuantity)
                    .HasColumnName("foundQuantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PostName)
                    .IsRequired()
                    .HasColumnName("postName")
                    .HasMaxLength(200);

                entity.Property(e => e.QuotaName)
                    .IsRequired()
                    .HasColumnName("quotaName")
                    .HasMaxLength(200);

                entity.Property(e => e.RoundedQuantiy)
                    .HasColumnName("roundedQuantiy")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<PostQuotaDivisionDistrict>(entity =>
            {
                entity.ToTable("post_quota_division_district");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DecimalQuantity)
                    .HasColumnName("decimalQuantity")
                    .HasColumnType("double(12,10)");

                entity.Property(e => e.DistrictName)
                    .IsRequired()
                    .HasColumnName("districtName")
                    .HasMaxLength(200);

                entity.Property(e => e.DivisionName)
                    .IsRequired()
                    .HasColumnName("divisionName")
                    .HasMaxLength(200);

                entity.Property(e => e.FoundQuantity)
                    .HasColumnName("foundQuantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PostName)
                    .IsRequired()
                    .HasColumnName("postName")
                    .HasMaxLength(200);

                entity.Property(e => e.QuotaName)
                    .IsRequired()
                    .HasColumnName("quotaName")
                    .HasMaxLength(200);

                entity.Property(e => e.RoundedQuantiy)
                    .HasColumnName("roundedQuantiy")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.HasKey(e => e.PostId)
                    .HasName("PRIMARY");

                entity.ToTable("posts");

                entity.Property(e => e.PostId)
                    .HasColumnName("postId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GeneralFoundQuantity)
                    .HasColumnName("generalFoundQuantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GeneralQuantity)
                    .HasColumnName("generalQuantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsEligibleForQuota).HasColumnName("isEligibleForQuota");

                entity.Property(e => e.MaximumQuotaQuantity)
                    .HasColumnName("maximumQuotaQuantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PostName)
                    .IsRequired()
                    .HasColumnName("postName")
                    .HasMaxLength(200);

                entity.Property(e => e.QuotaFoundQuantity)
                    .HasColumnName("quotaFoundQuantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TotalQuotaPercentage)
                    .HasColumnName("totalQuotaPercentage")
                    .HasColumnType("double(4,2)");

                entity.Property(e => e.Vacancies)
                    .HasColumnName("vacancies")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Quotas>(entity =>
            {
                entity.ToTable("quotas");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Percentage)
                    .HasColumnName("percentage")
                    .HasColumnType("double(5,2)");

                entity.Property(e => e.Priority)
                    .HasColumnName("priority")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<SelectedApplicants>(entity =>
            {
                entity.HasKey(e => e.SelectionId)
                    .HasName("PRIMARY");

                entity.ToTable("selected_applicants");

                entity.Property(e => e.SelectionId)
                    .HasColumnName("selectionId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ApplicantId)
                    .HasColumnName("applicantId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DistrictQuantityAfterSelect)
                    .HasColumnName("districtQuantityAfterSelect")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DistrictQuantityBeforeSelect)
                    .HasColumnName("districtQuantityBeforeSelect")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DivisionQuantityAfterSelect)
                    .HasColumnName("divisionQuantityAfterSelect")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DivisionQuantityBeforeSelect)
                    .HasColumnName("divisionQuantityBeforeSelect")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PermanentDistrict)
                    .IsRequired()
                    .HasColumnName("permanentDistrict")
                    .HasMaxLength(100);

                entity.Property(e => e.PermanentDivision)
                    .IsRequired()
                    .HasColumnName("permanentDivision")
                    .HasMaxLength(100);

                entity.Property(e => e.PostName)
                    .IsRequired()
                    .HasColumnName("postName")
                    .HasMaxLength(50);

                entity.Property(e => e.PostWiseRank)
                    .HasColumnName("postWiseRank")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.QuotaQuantityAfterSelect)
                    .HasColumnName("quotaQuantityAfterSelect")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.QuotaQuantityBeforeSelect)
                    .HasColumnName("quotaQuantityBeforeSelect")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.QuotaWiseRank)
                    .HasColumnName("quotaWiseRank")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Roll)
                    .HasColumnName("roll")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SelectionCriteria)
                    .IsRequired()
                    .HasColumnName("selectionCriteria")
                    .HasMaxLength(50);

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("double(5,2)");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("userId")
                    .HasMaxLength(20);

                entity.Property(e => e.Viva)
                    .HasColumnName("viva")
                    .HasColumnType("double(4,2)");

                entity.Property(e => e.Written)
                    .HasColumnName("written")
                    .HasColumnType("double(4,2)");
            });

            modelBuilder.Entity<View1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("view1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

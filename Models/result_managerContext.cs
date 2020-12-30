using System;
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
        public virtual DbSet<DistrictQuota> DistrictQuota { get; set; }
        public virtual DbSet<Districts> Districts { get; set; }
        public virtual DbSet<DivisionQuota> DivisionQuota { get; set; }
        public virtual DbSet<Divisions> Divisions { get; set; }
        public virtual DbSet<Marks> Marks { get; set; }
        public virtual DbSet<PostQuota> PostQuota { get; set; }
        public virtual DbSet<PostQuotaDivision> PostQuotaDivision { get; set; }
        public virtual DbSet<PostQuotaDivisionDistrict> PostQuotaDivisionDistrict { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<Quotas> Quotas { get; set; }

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
                entity.ToTable("applicants");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
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

                entity.Property(e => e.Religion)
                    .HasColumnName("religion")
                    .HasMaxLength(9)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Roll)
                    .HasColumnName("roll")
                    .HasMaxLength(200)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SelectionRank)
                    .HasColumnName("selectionRank")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasMaxLength(6)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<DistrictQuota>(entity =>
            {
                entity.ToTable("district_quota");

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

                entity.Property(e => e.FoundQuantity)
                    .HasColumnName("foundQuantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NotFoundQuantity)
                    .HasColumnName("notFoundQuantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RoundedQuantity)
                    .HasColumnName("roundedQuantity")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Districts>(entity =>
            {
                entity.ToTable("districts");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Division)
                    .IsRequired()
                    .HasColumnName("division")
                    .HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200);

                entity.Property(e => e.Percentage)
                    .HasColumnName("percentage")
                    .HasColumnType("double(12,10)");
            });

            modelBuilder.Entity<DivisionQuota>(entity =>
            {
                entity.ToTable("division_quota");

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

                entity.Property(e => e.NotFoundQuantity)
                    .HasColumnName("notFoundQuantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RoundedQuantity)
                    .HasColumnName("roundedQuantity")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Divisions>(entity =>
            {
                entity.ToTable("divisions");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
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
                    .IsRequired()
                    .HasColumnName("roll")
                    .HasMaxLength(200);

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("double(4,2)");

                entity.Property(e => e.Viva)
                    .HasColumnName("viva")
                    .HasColumnType("double(4,2)");

                entity.Property(e => e.Written)
                    .HasColumnName("written")
                    .HasColumnType("double(4,2)");
            });

            modelBuilder.Entity<PostQuota>(entity =>
            {
                entity.ToTable("post_quota");

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

                entity.Property(e => e.PostName)
                    .IsRequired()
                    .HasColumnName("postName")
                    .HasMaxLength(200);

                entity.Property(e => e.QuotaName)
                    .IsRequired()
                    .HasColumnName("quotaName")
                    .HasMaxLength(200);

                entity.Property(e => e.RoundedQuantity)
                    .HasColumnName("roundedQuantity")
                    .HasColumnType("double(5,2)");
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
                    .HasColumnType("double(12,10)");

                entity.Property(e => e.PostName)
                    .IsRequired()
                    .HasColumnName("postName")
                    .HasMaxLength(200);

                entity.Property(e => e.QuotaFoundQuantity)
                    .HasColumnName("quotaFoundQuantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TotalQuotaPercentage)
                    .HasColumnName("totalQuotaPercentage")
                    .HasColumnType("double(12,10)");

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

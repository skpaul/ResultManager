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
        public virtual DbSet<Districts> Districts { get; set; }
        public virtual DbSet<Divisions> Divisions { get; set; }
        public virtual DbSet<PostCalculation> PostCalculation { get; set; }
        public virtual DbSet<PostQuotaDistribution> PostQuotaDistribution { get; set; }
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
                entity.HasKey(e => e.ApplicantId)
                    .HasName("PRIMARY");

                entity.ToTable("applicants");

                entity.Property(e => e.ApplicantId)
                    .HasColumnName("applicantId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PostId)
                    .HasColumnName("postId")
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
                    .HasColumnType("double(5,2)");
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
                    .HasColumnType("double(5,2)");
            });

            modelBuilder.Entity<PostCalculation>(entity =>
            {
                entity.ToTable("post_calculation");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DistFound)
                    .HasColumnName("distFound")
                    .HasColumnType("int(11)")
                    .HasComment("district quota claimed by applicants");

                entity.Property(e => e.DistQuantity)
                    .HasColumnName("distQuantity")
                    .HasColumnType("int(11)")
                    .HasComment("declared by ministry");

                entity.Property(e => e.DistTransferred)
                    .HasColumnName("distTransferred")
                    .HasColumnType("int(11)")
                    .HasComment("if enough applicant not found, then transfer this quantity to general");

                entity.Property(e => e.FemaleFound)
                    .HasColumnName("femaleFound")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FemaleQuantity)
                    .HasColumnName("femaleQuantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FemaleTransferred)
                    .HasColumnName("femaleTransferred")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FreedomFighterFound)
                    .HasColumnName("freedomFighterFound")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FreedomFighterQuantity)
                    .HasColumnName("freedomFighterQuantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FreedomFighterTransferred)
                    .HasColumnName("freedomFighterTransferred")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GeneralQuota)
                    .HasColumnName("generalQuota")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PostId)
                    .HasColumnName("postId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TribalFound)
                    .HasColumnName("tribalFound")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TribalQuantity)
                    .HasColumnName("tribalQuantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TribalTransferred)
                    .HasColumnName("tribalTransferred")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<PostQuotaDistribution>(entity =>
            {
                entity.ToTable("post_quota_distribution");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ApplicantFound)
                    .HasColumnName("applicantFound")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DecimalQuantity)
                    .HasColumnName("decimalQuantity")
                    .HasColumnType("double(5,2)");

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
                    .HasColumnType("double(5,2)");

                entity.Property(e => e.DivisionName)
                    .IsRequired()
                    .HasColumnName("divisionName")
                    .HasMaxLength(200);

                entity.Property(e => e.PostName)
                    .IsRequired()
                    .HasColumnName("postName")
                    .HasMaxLength(200);

                entity.Property(e => e.QuotaName)
                    .IsRequired()
                    .HasColumnName("quotaName")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<PostQuotaDivisionDistrict>(entity =>
            {
                entity.ToTable("post_quota_division_district");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DecimalQuantity)
                    .HasColumnName("decimalQuantity")
                    .HasColumnType("double(5,2)");

                entity.Property(e => e.DistrictName)
                    .IsRequired()
                    .HasColumnName("districtName")
                    .HasMaxLength(200);

                entity.Property(e => e.DivisionName)
                    .IsRequired()
                    .HasColumnName("divisionName")
                    .HasMaxLength(200);

                entity.Property(e => e.PostName)
                    .IsRequired()
                    .HasColumnName("postName")
                    .HasMaxLength(200);

                entity.Property(e => e.QuotaName)
                    .IsRequired()
                    .HasColumnName("quotaName")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.HasKey(e => e.PostId)
                    .HasName("PRIMARY");

                entity.ToTable("posts");

                entity.Property(e => e.PostId)
                    .HasColumnName("postId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PostName)
                    .IsRequired()
                    .HasColumnName("postName")
                    .HasMaxLength(200);

                entity.Property(e => e.TotalQuotaPercentage)
                    .HasColumnName("totalQuotaPercentage")
                    .HasColumnType("double(5,2)");

                entity.Property(e => e.TotalQuotaQuantity)
                    .HasColumnName("totalQuotaQuantity")
                    .HasColumnType("double(5,2)");

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

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
        public virtual DbSet<DistInfo> DistInfo { get; set; }
        public virtual DbSet<PostCalculation> PostCalculation { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
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

            modelBuilder.Entity<DistInfo>(entity =>
            {
                entity.HasKey(e => e.Sl)
                    .HasName("PRIMARY");

                entity.ToTable("dist_info");

                entity.Property(e => e.Sl)
                    .HasColumnName("sl")
                    .HasColumnType("int(3) unsigned zerofill");

                entity.Property(e => e.Dist01)
                    .HasColumnName("dist_01")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist02)
                    .HasColumnName("dist_02")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist03)
                    .HasColumnName("dist_03")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'00'");

                entity.Property(e => e.Dist04)
                    .HasColumnName("dist_04")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist05)
                    .HasColumnName("dist_05")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist06)
                    .HasColumnName("dist_06")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist07)
                    .HasColumnName("dist_07")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist08)
                    .HasColumnName("dist_08")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist09)
                    .HasColumnName("dist_09")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist10)
                    .HasColumnName("dist_10")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist11)
                    .HasColumnName("dist_11")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist12)
                    .HasColumnName("dist_12")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist13)
                    .HasColumnName("dist_13")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist14)
                    .HasColumnName("dist_14")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist15)
                    .HasColumnName("dist_15")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist16)
                    .HasColumnName("dist_16")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist17)
                    .HasColumnName("dist_17")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist18)
                    .HasColumnName("dist_18")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist19)
                    .HasColumnName("dist_19")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist20)
                    .HasColumnName("dist_20")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist21)
                    .HasColumnName("dist_21")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist22)
                    .HasColumnName("dist_22")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist23)
                    .HasColumnName("dist_23")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist24)
                    .HasColumnName("dist_24")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist25)
                    .HasColumnName("dist_25")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist26)
                    .HasColumnName("dist_26")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist27)
                    .HasColumnName("dist_27")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist28)
                    .HasColumnName("dist_28")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist29)
                    .HasColumnName("dist_29")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist30)
                    .HasColumnName("dist_30")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist31)
                    .HasColumnName("dist_31")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist32)
                    .HasColumnName("dist_32")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist33)
                    .HasColumnName("dist_33")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist34)
                    .HasColumnName("dist_34")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist35)
                    .HasColumnName("dist_35")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist36)
                    .HasColumnName("dist_36")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist37)
                    .HasColumnName("dist_37")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist38)
                    .HasColumnName("dist_38")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist39)
                    .HasColumnName("dist_39")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist40)
                    .HasColumnName("dist_40")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist41)
                    .HasColumnName("dist_41")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist42)
                    .HasColumnName("dist_42")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist43)
                    .HasColumnName("dist_43")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist44)
                    .HasColumnName("dist_44")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist45)
                    .HasColumnName("dist_45")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist46)
                    .HasColumnName("dist_46")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist47)
                    .HasColumnName("dist_47")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist48)
                    .HasColumnName("dist_48")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist49)
                    .HasColumnName("dist_49")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist50)
                    .HasColumnName("dist_50")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist51)
                    .HasColumnName("dist_51")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist52)
                    .HasColumnName("dist_52")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist53)
                    .HasColumnName("dist_53")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist54)
                    .HasColumnName("dist_54")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist55)
                    .HasColumnName("dist_55")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist56)
                    .HasColumnName("dist_56")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist57)
                    .HasColumnName("dist_57")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist58)
                    .HasColumnName("dist_58")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist59)
                    .HasColumnName("dist_59")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist60)
                    .HasColumnName("dist_60")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist61)
                    .HasColumnName("dist_61")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist62)
                    .HasColumnName("dist_62")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist63)
                    .HasColumnName("dist_63")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dist64)
                    .HasColumnName("dist_64")
                    .HasColumnType("int(2) unsigned zerofill")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PostCode)
                    .HasColumnName("post_code")
                    .HasColumnType("int(5) unsigned")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.PostName)
                    .IsRequired()
                    .HasColumnName("post_name")
                    .HasMaxLength(100);
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

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.HasKey(e => e.PostId)
                    .HasName("PRIMARY");

                entity.ToTable("posts");

                entity.Property(e => e.PostId)
                    .HasColumnName("postId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DistrictQuota)
                    .HasColumnName("districtQuota")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FemaleQuota)
                    .HasColumnName("femaleQuota")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FreedomFighterQuota)
                    .HasColumnName("freedomFighterQuota")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PostName)
                    .IsRequired()
                    .HasColumnName("postName")
                    .HasMaxLength(200);

                entity.Property(e => e.TribalQuota)
                    .HasColumnName("tribalQuota")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Vacancies)
                    .HasColumnName("vacancies")
                    .HasColumnType("int(11)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

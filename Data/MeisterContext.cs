using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GCommon.Data;

public partial class MeisterContext : DbContext
{
    public MeisterContext()
    {
    }

    public MeisterContext(DbContextOptions<MeisterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<DeclareWorkerFree> DeclareWorkerFrees { get; set; }

    public virtual DbSet<TaxWage> TaxWages { get; set; }

    public virtual DbSet<WorkCategory> WorkCategories { get; set; }

    public virtual DbSet<WorkStartHour> WorkStartHours { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    public virtual DbSet<WorkerCapability> WorkerCapabilities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 

        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<DeclareWorkerFree>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DECLARE___3214EC2725F4E915");

            entity.ToTable("DECLARE_WORKER_FREE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AdText).HasColumnName("AD_TEXT");
            entity.Property(e => e.AdTitle)
                .HasMaxLength(500)
                .HasColumnName("AD_TITLE");
            entity.Property(e => e.HourId).HasColumnName("HOUR_ID");
            entity.Property(e => e.WatchDate)
                .HasColumnType("datetime")
                .HasColumnName("WATCH_DATE");
            entity.Property(e => e.WorkerCapabilityId).HasColumnName("WORKER_CAPABILITY_ID");

            entity.HasOne(d => d.Hour).WithMany(p => p.DeclareWorkerFrees)
                .HasForeignKey(d => d.HourId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__DECLARE_W__HOUR___68487DD7");

            entity.HasOne(d => d.WorkerCapability).WithMany(p => p.DeclareWorkerFrees)
                .HasForeignKey(d => d.WorkerCapabilityId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__DECLARE_W__WORKE__693CA210");
        });

        modelBuilder.Entity<TaxWage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TAX_WAGE__3214EC2748F3A252");

            entity.ToTable("TAX_WAGE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Caption)
                .HasMaxLength(50)
                .HasColumnName("CAPTION");
        });

        modelBuilder.Entity<WorkCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WORK_CAT__3214EC27DB29D146");

            entity.ToTable("WORK_CATEGORY");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Caption)
                .HasMaxLength(50)
                .HasColumnName("CAPTION");
        });

        modelBuilder.Entity<WorkStartHour>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WORK_STA__3214EC2798897BAE");

            entity.ToTable("WORK_START_HOURS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Shour).HasColumnName("SHOUR");
            entity.Property(e => e.Sminute).HasColumnName("SMINUTE");
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WORKER__3214EC2753C67F3D");

            entity.ToTable("WORKER");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Fname)
                .HasMaxLength(50)
                .HasColumnName("FNAME");
            entity.Property(e => e.Lname)
                .HasMaxLength(50)
                .HasColumnName("LNAME");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("PHONE");
            entity.Property(e => e.Photo)
                .HasMaxLength(100)
                .HasColumnName("PHOTO");
        });

        modelBuilder.Entity<WorkerCapability>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WORKER_C__3214EC27C0245004");

            entity.ToTable("WORKER_CAPABILITY");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PRICE");
            entity.Property(e => e.TaxWageId).HasColumnName("TAX_WAGE_ID");
            entity.Property(e => e.WorkCategoryId).HasColumnName("WORK_CATEGORY_ID");
            entity.Property(e => e.WorkerId).HasColumnName("WORKER_ID");

            entity.HasOne(d => d.TaxWage).WithMany(p => p.WorkerCapabilities)
                .HasForeignKey(d => d.TaxWageId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__WORKER_CA__TAX_W__6A30C649");

            entity.HasOne(d => d.WorkCategory).WithMany(p => p.WorkerCapabilities)
                .HasForeignKey(d => d.WorkCategoryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__WORKER_CA__WORK___6B24EA82");

            entity.HasOne(d => d.Worker).WithMany(p => p.WorkerCapabilities)
                .HasForeignKey(d => d.WorkerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__WORKER_CA__WORKE__6C190EBB");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

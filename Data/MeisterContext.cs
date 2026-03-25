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

    public virtual DbSet<AspnetuserOrder> AspnetuserOrders { get; set; }

    public virtual DbSet<DeclareWorkerFree> DeclareWorkerFrees { get; set; }

    public virtual DbSet<ItemsInOrder> ItemsInOrders { get; set; }

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

        modelBuilder.Entity<AspnetuserOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__ASPNETUS__460A9464614C9C78");

            entity.ToTable("ASPNETUSER_ORDERS");

            entity.Property(e => e.OrderId).HasColumnName("ORDER_ID");
            entity.Property(e => e.AspnetusersId)
                .HasMaxLength(450)
                .HasColumnName("ASPNETUSERS_ID");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("ORDER_DATE");
            entity.Property(e => e.OrderDetails).HasColumnName("ORDER_DETAILS");
            entity.Property(e => e.Phone)
                .HasMaxLength(100)
                .HasColumnName("PHONE");

            entity.HasOne(d => d.Aspnetusers).WithMany(p => p.AspnetuserOrders)
                .HasForeignKey(d => d.AspnetusersId)
                .HasConstraintName("FK__ASPNETUSE__ASPNE__5441852A");
        });

        modelBuilder.Entity<DeclareWorkerFree>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DECLARE___3214EC27427B64E4");

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
                .HasConstraintName("FK__DECLARE_W__HOUR___59FA5E80");

            entity.HasOne(d => d.WorkerCapability).WithMany(p => p.DeclareWorkerFrees)
                .HasForeignKey(d => d.WorkerCapabilityId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__DECLARE_W__WORKE__5AEE82B9");
        });

        modelBuilder.Entity<ItemsInOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ITEMS_IN__3214EC273C992B6E");

            entity.ToTable("ITEMS_IN_ORDER");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DeclareWorkerFreeId).HasColumnName("DECLARE_WORKER_FREE_ID");
            entity.Property(e => e.OrderId).HasColumnName("ORDER_ID");

            entity.HasOne(d => d.DeclareWorkerFree).WithMany(p => p.ItemsInOrders)
                .HasForeignKey(d => d.DeclareWorkerFreeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__ITEMS_IN___DECLA__5BE2A6F2");

            entity.HasOne(d => d.Order).WithMany(p => p.ItemsInOrders)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__ITEMS_IN___ORDER__5CD6CB2B");
        });

        modelBuilder.Entity<TaxWage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TAX_WAGE__3214EC27CC8B343C");

            entity.ToTable("TAX_WAGE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Caption)
                .HasMaxLength(50)
                .HasColumnName("CAPTION");
        });

        modelBuilder.Entity<WorkCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WORK_CAT__3214EC278FA9E74B");

            entity.ToTable("WORK_CATEGORY");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Caption)
                .HasMaxLength(50)
                .HasColumnName("CAPTION");
        });

        modelBuilder.Entity<WorkStartHour>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WORK_STA__3214EC27C07F0013");

            entity.ToTable("WORK_START_HOURS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Shour).HasColumnName("SHOUR");
            entity.Property(e => e.Sminute).HasColumnName("SMINUTE");
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WORKER__3214EC27ECB03D14");

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
            entity.HasKey(e => e.Id).HasName("PK__WORKER_C__3214EC27FE28748C");

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
                .HasConstraintName("FK__WORKER_CA__TAX_W__5DCAEF64");

            entity.HasOne(d => d.WorkCategory).WithMany(p => p.WorkerCapabilities)
                .HasForeignKey(d => d.WorkCategoryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__WORKER_CA__WORK___5EBF139D");

            entity.HasOne(d => d.Worker).WithMany(p => p.WorkerCapabilities)
                .HasForeignKey(d => d.WorkerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__WORKER_CA__WORKE__5FB337D6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

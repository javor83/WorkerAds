using Microsoft.EntityFrameworkCore;


namespace GCommon.Data
{
    public partial class MeisterContext : DbContext
    {
        public MeisterContext()
        {
        }

        public MeisterContext(DbContextOptions<MeisterContext> options)
            : base(options)
        {
        }

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
            modelBuilder.Entity<DeclareWorkerFree>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__DECLARE___3214EC27947C8091");

                entity.ToTable("DECLARE_WORKER_FREE");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.AdText).HasColumnName("AD_TEXT");
                entity.Property(e => e.HourId).HasColumnName("HOUR_ID");
                entity.Property(e => e.WatchDate)
                    .HasColumnType("datetime")
                    .HasColumnName("WATCH_DATE");
                entity.Property(e => e.WorkerCapabilityId).HasColumnName("WORKER_CAPABILITY_ID");

                entity.HasOne(d => d.Hour).WithMany(p => p.DeclareWorkerFrees)
                    .HasForeignKey(d => d.HourId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__DECLARE_W__HOUR___5812160E");

                entity.HasOne(d => d.WorkerCapability).WithMany(p => p.DeclareWorkerFrees)
                    .HasForeignKey(d => d.WorkerCapabilityId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__DECLARE_W__WORKE__59063A47");
            });

            modelBuilder.Entity<TaxWage>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__TAX_WAGE__3214EC27293A2DF4");

                entity.ToTable("TAX_WAGE");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Caption)
                    .HasMaxLength(50)
                    .HasColumnName("CAPTION");
            });

            modelBuilder.Entity<WorkCategory>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__WORK_CAT__3214EC279E9422C5");

                entity.ToTable("WORK_CATEGORY");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Caption)
                    .HasMaxLength(50)
                    .HasColumnName("CAPTION");
            });

            modelBuilder.Entity<WorkStartHour>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__WORK_STA__3214EC27A3C695CB");

                entity.ToTable("WORK_START_HOURS");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Shour).HasColumnName("SHOUR");
                entity.Property(e => e.Sminute).HasColumnName("SMINUTE");
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__WORKER__3214EC274CD80226");

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
                entity.HasKey(e => e.Id).HasName("PK__WORKER_C__3214EC27575A96C5");

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
                    .HasConstraintName("FK__WORKER_CA__TAX_W__59FA5E80");

                entity.HasOne(d => d.WorkCategory).WithMany(p => p.WorkerCapabilities)
                    .HasForeignKey(d => d.WorkCategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__WORKER_CA__WORK___5AEE82B9");

                entity.HasOne(d => d.Worker).WithMany(p => p.WorkerCapabilities)
                    .HasForeignKey(d => d.WorkerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__WORKER_CA__WORKE__5BE2A6F2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EYBadges
{
    public partial class EYBadgeMetricsContext : DbContext
    {
        public EYBadgeMetricsContext()
        {
        }

        public EYBadgeMetricsContext(DbContextOptions<EYBadgeMetricsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BadgesList> BadgesList { get; set; }
        public virtual DbSet<ClientSatisfactionReview> ClientSatisfactionReview { get; set; }
        public virtual DbSet<DeveloperKpi> DeveloperKpi { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeBadges> EmployeeBadges { get; set; }
        public virtual DbSet<Modules> Modules { get; set; }
        public virtual DbSet<OutOfTheBox> OutOfTheBox { get; set; }
        public virtual DbSet<TeamDetails> TeamDetails { get; set; }
        public virtual DbSet<TesterKpi> TesterKpi { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=NDUGGIRALA-LT;initial catalog=EYBadgeMetrics;Integrated security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BadgesList>(entity =>
            {
                entity.HasKey(e => e.BadgeId);

                entity.Property(e => e.BadgeId).ValueGeneratedNever();

                entity.Property(e => e.BadgeName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.LevelOfBadge)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClientSatisfactionReview>(entity =>
            {
                entity.HasKey(e => e.RecordNumber);

                entity.Property(e => e.Accountability).IsUnicode(false);

                entity.Property(e => e.ActionItems).IsUnicode(false);

                entity.Property(e => e.Communication).IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Disappointment).IsUnicode(false);

                entity.Property(e => e.Likes).IsUnicode(false);

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.ClientSatisfactionReview)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_ClientSatisfactionReview_TeamDetails");
            });

            modelBuilder.Entity<DeveloperKpi>(entity =>
            {
                entity.HasKey(e => e.RecordNumber);

                entity.ToTable("DeveloperKPI");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Kloc).HasColumnName("KLoc");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.Property(e => e.EmployeeName).IsUnicode(false);

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_Employee_TeamDetails");
            });

            modelBuilder.Entity<EmployeeBadges>(entity =>
            {
                entity.HasKey(e => e.RecordNumber);

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.ExternalCourse).HasDefaultValueSql("((0))");

                entity.Property(e => e.ExternalCourseComments).IsUnicode(false);

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.HasOne(d => d.Badge)
                    .WithMany(p => p.EmployeeBadges)
                    .HasForeignKey(d => d.BadgeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeBadges_BadgesList");
            });

            modelBuilder.Entity<Modules>(entity =>
            {
                entity.HasKey(e => e.RecordNumber);

                entity.Property(e => e.ComercialAwareness).IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RemarksFromSelf).IsUnicode(false);

                entity.Property(e => e.RemarksFromTeam).IsUnicode(false);
            });

            modelBuilder.Entity<OutOfTheBox>(entity =>
            {
                entity.HasKey(e => e.RecordNumber);

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdeasToEnhanceTheCompany).IsUnicode(false);

                entity.Property(e => e.IdeasToEnhanceTheProject).IsUnicode(false);
            });

            modelBuilder.Entity<TeamDetails>(entity =>
            {
                entity.HasKey(e => e.TeamId);

                entity.Property(e => e.TeamId).ValueGeneratedNever();

                entity.Property(e => e.TeamName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TesterKpi>(entity =>
            {
                entity.HasKey(e => e.RecordNumber);

                entity.ToTable("TesterKPI");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });
        }
    }
}

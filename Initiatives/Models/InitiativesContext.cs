using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Initiatives.Models
{
    public partial class InitiativesContext : DbContext
    {
        public virtual DbSet<Business> Businesses { get; set; }
        public virtual DbSet<Facility> Facility { get; set; }
        public virtual DbSet<Location> DeploymentLocation { get; set; }
        public virtual DbSet<EngagementType> EngagementType { get; set; }
        public virtual DbSet<Initiative> Initiative { get; set; }
        public virtual DbSet<InitiativeMetaTag> InitiativeMetaTag { get; set; }
        public virtual DbSet<InitiativeBusiness> InitiativeBusiness { get; set; }
        public virtual DbSet<InitiativeFacility> InitiativeFacility { get; set; }
        public virtual DbSet<MetaTag> MetaTag { get; set; }
        public virtual DbSet<Resource> Resource { get; set; }
        public virtual DbSet<SolutionType> SolutionType { get; set; }
        public virtual DbSet<Note> Note { get; set; }
        public InitiativesContext(DbContextOptions<InitiativesContext> options)
                : base(options)
        {
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // Soft-Delete Task<int>async Task<int>
            foreach (var item in ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Deleted &&
                            e.Metadata.GetProperties().Any(x => x.Name == "IsActive")))
            {
                item.State = EntityState.Unchanged;
                item.CurrentValues["IsActive"] = false;
            }
            return  await base.SaveChangesAsync();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Business>(entity =>
            {
                entity.Property(e => e.BusinessShortDescription)
                    .IsRequired()
                    .HasColumnType("nchar(15)");

                entity.Property(e => e.BusinessDescription)
                    .IsRequired()
                    .HasColumnType("nchar(25)");
            });

            modelBuilder.Entity<Facility>(entity =>
            {
                entity.Property(e => e.FacilityShortDescription)
                    .IsRequired()
                    .HasColumnType("nchar(15)");

                entity.Property(e => e.FacilityDescription)
                    .IsRequired()
                    .HasColumnType("nchar(25)");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.LocationShortDescription)
                    .IsRequired()
                    .HasColumnType("nchar(15)");

                entity.Property(e => e.LocationDescription)
                    .IsRequired()
                    .HasColumnType("nchar(25)");
            });

            modelBuilder.Entity<EngagementType>(entity =>
            {
                entity.Property(e => e.EngagementTypeShortDescription)
                    .IsRequired()
                    .HasColumnType("nchar(15)");

                entity.Property(e => e.EngagementTypeDescription)
                    .IsRequired()
                    .HasColumnType("nchar(25)");
            });

            modelBuilder.Entity<Initiative>(entity =>
            {
                entity.Property(e => e.ARBdate)
                    .HasColumnName("ARBDate")
                    .HasColumnType("date");
                entity.Property(e => e.CompleteDate)
                    .HasColumnType("date");
                entity.Property(e => e.DownStreamSystem)
                    .HasColumnType("nchar(25)");
                entity.Property(e => e.PHI)
                    .HasColumnType("bit");
                entity.Property(e => e.PCI)
                    .HasColumnType("bit");
                entity.Property(e => e.EngagementIdentifier)
                    .HasColumnType("nchar(15)");
                entity.Property(e => e.EngagementName)
                    .HasColumnType("nchar(15)");
                entity.Property(e => e.ProjectStartDate)
                    .HasColumnType("date");
                entity.Property(e => e.ReceiveDate)
                    .HasColumnType("date");
                entity.Property(e => e.StartDate)
                    .HasColumnType("date");
                entity.Property(e => e.UpStreamSystem)
                    .HasColumnType("nchar(25)");
                // Foreign Keys
                entity.HasOne(d => d.BusinessNavigation)
                    .WithMany(p => p.Initiative)
                    .HasForeignKey(d => d.Business)
                    .HasConstraintName("FK_Initiative_Business");

                entity.HasOne(d => d.FacilityNavigation)
                    .WithMany(p => p.Initiative)
                    .HasForeignKey(d => d.Facility)
                    .HasConstraintName("FK_Initiative_Facility");

                entity.HasOne(d => d.LocationNavigation)
                    .WithMany(p => p.Initiative)
                    .HasForeignKey(d => d.DeploymentLocation)
                    .HasConstraintName("FK_Initiative_DeploymentLocation");

                entity.HasOne(d => d.EngagementTypeNavigation)
                    .WithMany(p => p.Initiative)
                    .HasForeignKey(d => d.EngagementType)
                    .HasConstraintName("FK_Initiative_EngagementType");

                entity.HasOne(d => d.ResourceNavigation)
                    .WithMany(p => p.Initiative)
                    .HasForeignKey(d => d.Resource)
                    .HasConstraintName("FK_Initiative_Resource");

                entity.HasOne(d => d.SolutionTypeNavigation)
                    .WithMany(p => p.Initiative)
                    .HasForeignKey(d => d.SolutionType)
                    .HasConstraintName("FK_Initiative_SolutionType");
            });

            modelBuilder.Entity<InitiativeMetaTag>(entity =>
            {

                entity.HasKey(bc => new { bc.InitiativeId, bc.MetaTagId });

                entity.HasOne(d => d.Initiative)
                    .WithMany(p => p.InitiativeMetaTag)
                    .HasForeignKey(d => d.InitiativeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InitiativeMetaTag_Initiative");

                entity.HasOne(d => d.MetaTag)
                    .WithMany(p => p.InitiativeMetaTag)
                    .HasForeignKey(d => d.MetaTagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InitiativeMetaTag_MetaTags");
            });

            modelBuilder.Entity<MetaTag>(entity =>
            {
               

                entity.Property(e => e.MetaTagShortDescription)
                    .IsRequired()
                   .HasColumnType("nchar(15)");

                entity.Property(e => e.MetaTagDescription)
                    .IsRequired()
                    .HasColumnType("nchar(25)");
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("nchar(15)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("nchar(15)");
            });

            modelBuilder.Entity<SolutionType>(entity =>
            {
                entity.Property(e => e.SolutionTypeShortDescription)
                    .IsRequired()
                    .HasColumnType("nchar(15)");

                entity.Property(e => e.SolutionTypeDescription)
                    .IsRequired()
                    .HasColumnType("nchar(25)");
            });
            modelBuilder.Entity<Note>(entity =>
            {
                entity.Property(e => e.NoteId).ValueGeneratedOnAdd();

                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Initiative)
                    .WithOne(p => p.Note)
                    .HasForeignKey<Note>(d => d.NoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Note_Initiative");
            });
        }

    }
}

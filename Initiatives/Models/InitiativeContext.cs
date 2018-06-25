using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Initiatives.Models
{
    /// <summary>
    /// This creates all the data sets used in the project.
    /// </summary>
    public partial class InitiativeContext : DbContext
    {
        /// <summary>
        /// This is list of COEs
        /// </summary>
        public virtual DbSet<Business> Business { get; set; }
        public virtual DbSet<CurrentStatus> CurrentStatus { get; set; }
        public virtual DbSet<Facility> Facility { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<EngagementType> EngagementType { get; set; }
        public virtual DbSet<Initiative> Initiative { get; set; }
        public virtual DbSet<InitiativeMetaTag> InitiativeMetaTag { get; set; }
        public virtual DbSet<InitiativeBusiness> InitiativeBusiness { get; set; }
        public virtual DbSet<InitiativeFacility> InitiativeFacility { get; set; }
        public virtual DbSet<MetaTag> MetaTag { get; set; }
        public virtual DbSet<Resource> Resource { get; set; }
        public virtual DbSet<SolutionType> SolutionType { get; set; }
        public virtual DbSet<EAInvolvement> EAInvolvement { get; set; }
        public virtual DbSet<Note> Note { get; set; }
        
        public InitiativeContext(DbContextOptions<InitiativeContext> options)
                : base(options)
        {
        }
        /// <summary>
        /// This function overrides the Save changes to add logic to 
        /// allow "soft delete" (inactive flag) and logic to allow audting
        /// (insert the logged in user Name making modifications and date).
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
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
            //Add last Mod User and Last change Date
            foreach (var item in ChangeTracker.Entries()
                .Where(e => e.State != EntityState.Unchanged &&
                            e.Metadata.GetProperties().Any(x => x.Name == "ModifiedUserName") && e.Metadata.GetProperties().Any(x => x.Name == "LastModifiedDate")))
            {
                item.CurrentValues["ModifiedUserName"] = WindowsIdentity.GetCurrent().Name;
                item.CurrentValues["LastModifiedDate"] = DateTime.Now;
            }
            //Set new items to active
            foreach (var item in ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added &&
                            e.Metadata.GetProperties().Any(x => x.Name == "IsActive")))
            {
                item.CurrentValues["IsActive"] = true;
            }
            return  await base.SaveChangesAsync();
        }
      

        /// <summary>
        /// THis function creates the models used in the "pages"
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Business>(entity =>
            {
                entity.Property(e => e.BusinessShortDescription)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.BusinessDescription)
                    .IsRequired()
                    .HasColumnType("varchar(max)");
                entity.Property(e => e.IsActive)
                    .HasColumnType("bit");

            });

            modelBuilder.Entity<Facility>(entity =>
            {
                entity.Property(e => e.FacilityShortDescription)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.FacilityDescription)
                    .IsRequired()
                    .HasColumnType("varchar(max)");
                entity.Property(e => e.IsActive)
                    .HasColumnType("bit");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.LocationShortDescription)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.LocationDescription)
                    .IsRequired()
                    .HasColumnType("varchar(max)");
                entity.Property(e => e.IsActive)
                    .HasColumnType("bit");

            });

            modelBuilder.Entity<EngagementType>(entity =>
            {
                entity.Property(e => e.EngagementTypeShortDescription)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.EngagementTypeDescription)
                    .IsRequired()
                    .HasColumnType("varchar(max)");
                entity.Property(e => e.IsActive)
                    .HasColumnType("bit");
            });

            modelBuilder.Entity<Initiative>(entity =>
            {
                entity.Property(e => e.IsActive)
                    .HasColumnType("bit");

                entity.Property(e => e.ARBDate)
                    .HasColumnName("ARBDate")
                    .HasColumnType("date");
                entity.Property(e => e.CompleteDate)
                    .HasColumnType("date");
                entity.Property(e => e.DownStreamSystem)
                    .HasColumnType("varchar(max)");
                entity.Property(e => e.PHI)
                    .HasColumnType("bit");
                entity.Property(e => e.PCI)
                    .HasColumnType("bit");
                entity.Property(e => e.EngagementIdentifier)
                    .HasColumnType("varchar(max)");
                entity.Property(e => e.EngagementName)
                    .HasColumnType("varchar(max)");
                entity.Property(e => e.ProjectStartDate)
                    .HasColumnType("date");
                entity.Property(e => e.ReceiveDate)
                    .HasColumnType("date");
                entity.Property(e => e.StartDate)
                    .HasColumnType("date");
                entity.Property(e => e.UpStreamSystem)
                    .HasColumnType("varchar(max)");
               entity.HasOne(d => d.LocationNavigation)
                    .WithMany(p => p.Initiative)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_Initiative_Location");
                entity.HasOne(d => d.CurrentStatusNavigation)
                    .WithMany(p => p.Initiative)
                    .HasForeignKey(d => d.CurrentStatusId)
                    .HasConstraintName("FK_Initiative_CurrentStatus");
                entity.HasOne(d => d.EngagementTypeNavigation)
                    .WithMany(p => p.Initiative)
                    .HasForeignKey(d => d.EngagementTypeId)
                    .HasConstraintName("FK_Initiative_EngagementType");
                //EAInvolvementId
                entity.HasOne(d => d.EAInvolvementNavigation)
                    .WithMany(p => p.Initiative)
                    .HasForeignKey(d => d.EAInvolvementId)
                    .HasConstraintName("FK_Initiative_EAInvolvement");
                entity.HasOne(d => d.ResourceNavigation)
                    .WithMany(p => p.Initiative)
                    .HasForeignKey(d => d.Resource)
                    .HasConstraintName("FK_Initiative_Resource");

                entity.HasOne(d => d.SolutionTypeNavigation)
                    .WithMany(p => p.Initiative)
                    .HasForeignKey(d => d.SolutionTypeId)
                    .HasConstraintName("FK_Initiative_SolutionType");
            });

            modelBuilder.Entity<InitiativeBusiness>(entity =>
            {

                entity.HasKey(bc => new { bc.InitiativeId, bc.BusinessId });

                entity.HasOne(d => d.Initiative)
                    .WithMany(p => p.InitiativeBusiness)
                    .HasForeignKey(d => d.InitiativeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InitiativeBusiness_Initiative");

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.InitiativeBusiness)
                    .HasForeignKey(d => d.BusinessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InitiativeBusiness_Business");
                //entity.HasQueryFilter(p => p.Business.IsActive); can do on an entity level but not a good idea since may hyave realtionshops
            });

            modelBuilder.Entity<InitiativeFacility>(entity =>
            {

                entity.HasKey(bc => new { bc.InitiativeId, bc.FacilityId });

                entity.HasOne(d => d.Initiative)
                    .WithMany(p => p.InitiativeFacility)
                    .HasForeignKey(d => d.InitiativeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InitiativeFacility_Initiative");

                entity.HasOne(d => d.Facility)
                    .WithMany(p => p.InitiativeFacility)
                    .HasForeignKey(d => d.FacilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InitiativeFacility_Facility");
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
                   .HasColumnType("varchar(max)");

                entity.Property(e => e.MetaTagDescription)
                    .IsRequired()
                    .HasColumnType("varchar(max)");
                entity.Property(e => e.IsActive)
                    .HasColumnType("bit");
            });
          
            modelBuilder.Entity<EAInvolvement>(entity =>
            {
                entity.Property(e => e.EAInvolvementShortDescription)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.EAInvolvementDescription)
                    .IsRequired()
                    .HasColumnType("varchar(max)");
                entity.Property(e => e.IsActive)
                    .HasColumnType("bit");
            });


            modelBuilder.Entity<Resource>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("varchar(max)");
                entity.Property(e => e.IsActive)
                    .HasColumnType("bit");
            });

            modelBuilder.Entity<SolutionType>(entity =>
            {
                entity.Property(e => e.SolutionTypeShortDescription)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.SolutionTypeDescription)
                    .IsRequired()
                    .HasColumnType("varchar(max)");
                entity.Property(e => e.IsActive)
                    .HasColumnType("bit");
            });
            modelBuilder.Entity<CurrentStatus>(entity =>
            {
                entity.Property(e => e.CurrentStatusDescription)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.CurrentStatusShortDescription)
                    .IsRequired()
                    .HasColumnType("varchar(max)");
                entity.Property(e => e.IsActive)
                    .HasColumnType("bit");
            });
            modelBuilder.Entity<Note>(entity =>
            {
                entity.Property(e => e.NoteId).ValueGeneratedOnAdd();

                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
                

                entity.HasOne(d => d.InitiativeNavigation)
                    .WithMany(p => p.Note)
                    .HasForeignKey(d => d.NoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Note_Initiative");

                entity.Property(e => e.IsActive)
                    .HasColumnType("bit");
            });
        }

    }
}

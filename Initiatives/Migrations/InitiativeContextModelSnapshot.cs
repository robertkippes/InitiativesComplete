﻿// <auto-generated />
using Initiatives.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Initiatives.Migrations
{
    [DbContext(typeof(InitiativeContext))]
    partial class InitiativeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Initiatives.Models.Business", b =>
                {
                    b.Property<int>("BusinessId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BusinessDescription")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasMaxLength(200);

                    b.Property<string>("BusinessShortDescription")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasMaxLength(50);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<string>("ModifiedUserName")
                        .HasColumnType("varchar(150)");

                    b.HasKey("BusinessId");

                    b.ToTable("Business");
                });

            modelBuilder.Entity("Initiatives.Models.CurrentStatus", b =>
                {
                    b.Property<int>("CurrentStatusId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CurrentStatusDescription")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasMaxLength(200);

                    b.Property<string>("CurrentStatusShortDescription")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasMaxLength(50);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<string>("ModifiedUserName")
                        .HasColumnType("varchar(150)");

                    b.HasKey("CurrentStatusId");

                    b.ToTable("CurrentStatus");
                });

            modelBuilder.Entity("Initiatives.Models.EAInvolvement", b =>
                {
                    b.Property<int>("EAInvolvementId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EAInvolvementDescription")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasMaxLength(200);

                    b.Property<string>("EAInvolvementShortDescription")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasMaxLength(50);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<string>("ModifiedUserName")
                        .HasColumnType("varchar(150)");

                    b.HasKey("EAInvolvementId");

                    b.ToTable("EAInvolvement");
                });

            modelBuilder.Entity("Initiatives.Models.EngagementType", b =>
                {
                    b.Property<int>("EngagementTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EngagementTypeDescription")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasMaxLength(200);

                    b.Property<string>("EngagementTypeShortDescription")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasMaxLength(50);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<string>("ModifiedUserName")
                        .HasColumnType("varchar(150)");

                    b.HasKey("EngagementTypeId");

                    b.ToTable("EngagementType");
                });

            modelBuilder.Entity("Initiatives.Models.Facility", b =>
                {
                    b.Property<int>("FacilityId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FacilityDescription")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasMaxLength(200);

                    b.Property<string>("FacilityShortDescription")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasMaxLength(50);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<string>("ModifiedUserName")
                        .HasColumnType("varchar(150)");

                    b.HasKey("FacilityId");

                    b.ToTable("Facility");
                });

            modelBuilder.Entity("Initiatives.Models.Initiative", b =>
                {
                    b.Property<int>("InitiativeId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("ARBDate")
                        .HasColumnName("ARBDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("CompleteDate")
                        .HasColumnType("date");

                    b.Property<int?>("CurrentStatusId");

                    b.Property<string>("DownStreamSystem")
                        .HasColumnType("varchar(max)")
                        .HasMaxLength(200);

                    b.Property<int?>("EAInvolvementId");

                    b.Property<string>("EngagementIdentifier")
                        .HasColumnType("varchar(max)")
                        .HasMaxLength(200);

                    b.Property<string>("EngagementName")
                        .HasColumnType("varchar(max)")
                        .HasMaxLength(200);

                    b.Property<int?>("EngagementTypeId");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<int?>("LocationId");

                    b.Property<string>("ModifiedUserName")
                        .HasColumnType("varchar(150)");

                    b.Property<bool>("PCI")
                        .HasColumnType("bit");

                    b.Property<bool>("PHI")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ProjectStartDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("ReceiveDate")
                        .HasColumnType("date");

                    b.Property<int?>("Resource");

                    b.Property<int?>("SolutionTypeId");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("date");

                    b.Property<string>("UpStreamSystem")
                        .HasColumnType("varchar(max)")
                        .HasMaxLength(200);

                    b.HasKey("InitiativeId");

                    b.HasIndex("CurrentStatusId");

                    b.HasIndex("EAInvolvementId");

                    b.HasIndex("EngagementTypeId");

                    b.HasIndex("LocationId");

                    b.HasIndex("Resource");

                    b.HasIndex("SolutionTypeId");

                    b.ToTable("Initiative");
                });

            modelBuilder.Entity("Initiatives.Models.InitiativeBusiness", b =>
                {
                    b.Property<int>("InitiativeId");

                    b.Property<int>("BusinessId");

                    b.HasKey("InitiativeId", "BusinessId");

                    b.HasIndex("BusinessId");

                    b.ToTable("InitiativeBusiness");
                });

            modelBuilder.Entity("Initiatives.Models.InitiativeFacility", b =>
                {
                    b.Property<int>("InitiativeId");

                    b.Property<int>("FacilityId");

                    b.HasKey("InitiativeId", "FacilityId");

                    b.HasIndex("FacilityId");

                    b.ToTable("InitiativeFacility");
                });

            modelBuilder.Entity("Initiatives.Models.InitiativeMetaTag", b =>
                {
                    b.Property<int>("InitiativeId");

                    b.Property<int>("MetaTagId");

                    b.HasKey("InitiativeId", "MetaTagId");

                    b.HasIndex("MetaTagId");

                    b.ToTable("InitiativeMetaTag");
                });

            modelBuilder.Entity("Initiatives.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<string>("LocationDescription")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasMaxLength(200);

                    b.Property<string>("LocationShortDescription")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasMaxLength(50);

                    b.Property<string>("ModifiedUserName")
                        .HasColumnType("varchar(150)");

                    b.HasKey("LocationId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("Initiatives.Models.MetaTag", b =>
                {
                    b.Property<int>("MetaTagId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<string>("MetaTagDescription")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasMaxLength(200);

                    b.Property<string>("MetaTagShortDescription")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasMaxLength(50);

                    b.Property<string>("ModifiedUserName")
                        .HasColumnType("varchar(150)");

                    b.HasKey("MetaTagId");

                    b.ToTable("MetaTag");
                });

            modelBuilder.Entity("Initiatives.Models.Note", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("InitiativeId");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<string>("ModifiedUserName")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Note1")
                        .IsRequired()
                        .HasColumnName("Note");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("NoteId");

                    b.ToTable("Note");
                });

            modelBuilder.Entity("Initiatives.Models.Resource", b =>
                {
                    b.Property<int>("ResourceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasMaxLength(50);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasMaxLength(50);

                    b.Property<string>("ModifiedUserName")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("PrincipalUserName");

                    b.HasKey("ResourceId");

                    b.ToTable("Resource");
                });

            modelBuilder.Entity("Initiatives.Models.SolutionType", b =>
                {
                    b.Property<int>("SolutionTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<string>("ModifiedUserName")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("SolutionTypeDescription")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasMaxLength(200);

                    b.Property<string>("SolutionTypeShortDescription")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasMaxLength(50);

                    b.HasKey("SolutionTypeId");

                    b.ToTable("SolutionType");
                });

            modelBuilder.Entity("Initiatives.Models.Initiative", b =>
                {
                    b.HasOne("Initiatives.Models.CurrentStatus", "CurrentStatusNavigation")
                        .WithMany("Initiative")
                        .HasForeignKey("CurrentStatusId")
                        .HasConstraintName("FK_Initiative_CurrentStatus");

                    b.HasOne("Initiatives.Models.EAInvolvement", "EAInvolvementNavigation")
                        .WithMany("Initiative")
                        .HasForeignKey("EAInvolvementId")
                        .HasConstraintName("FK_Initiative_EAInvolvement");

                    b.HasOne("Initiatives.Models.EngagementType", "EngagementTypeNavigation")
                        .WithMany("Initiative")
                        .HasForeignKey("EngagementTypeId")
                        .HasConstraintName("FK_Initiative_EngagementType");

                    b.HasOne("Initiatives.Models.Location", "LocationNavigation")
                        .WithMany("Initiative")
                        .HasForeignKey("LocationId")
                        .HasConstraintName("FK_Initiative_Location");

                    b.HasOne("Initiatives.Models.Resource", "ResourceNavigation")
                        .WithMany("Initiative")
                        .HasForeignKey("Resource")
                        .HasConstraintName("FK_Initiative_Resource");

                    b.HasOne("Initiatives.Models.SolutionType", "SolutionTypeNavigation")
                        .WithMany("Initiative")
                        .HasForeignKey("SolutionTypeId")
                        .HasConstraintName("FK_Initiative_SolutionType");
                });

            modelBuilder.Entity("Initiatives.Models.InitiativeBusiness", b =>
                {
                    b.HasOne("Initiatives.Models.Business", "Business")
                        .WithMany("InitiativeBusiness")
                        .HasForeignKey("BusinessId")
                        .HasConstraintName("FK_InitiativeBusiness_Business");

                    b.HasOne("Initiatives.Models.Initiative", "Initiative")
                        .WithMany("InitiativeBusiness")
                        .HasForeignKey("InitiativeId")
                        .HasConstraintName("FK_InitiativeBusiness_Initiative");
                });

            modelBuilder.Entity("Initiatives.Models.InitiativeFacility", b =>
                {
                    b.HasOne("Initiatives.Models.Facility", "Facility")
                        .WithMany("InitiativeFacility")
                        .HasForeignKey("FacilityId")
                        .HasConstraintName("FK_InitiativeFacility_Facility");

                    b.HasOne("Initiatives.Models.Initiative", "Initiative")
                        .WithMany("InitiativeFacility")
                        .HasForeignKey("InitiativeId")
                        .HasConstraintName("FK_InitiativeFacility_Initiative");
                });

            modelBuilder.Entity("Initiatives.Models.InitiativeMetaTag", b =>
                {
                    b.HasOne("Initiatives.Models.Initiative", "Initiative")
                        .WithMany("InitiativeMetaTag")
                        .HasForeignKey("InitiativeId")
                        .HasConstraintName("FK_InitiativeMetaTag_Initiative");

                    b.HasOne("Initiatives.Models.MetaTag", "MetaTag")
                        .WithMany("InitiativeMetaTag")
                        .HasForeignKey("MetaTagId")
                        .HasConstraintName("FK_InitiativeMetaTag_MetaTags");
                });

            modelBuilder.Entity("Initiatives.Models.Note", b =>
                {
                    b.HasOne("Initiatives.Models.Initiative", "InitiativeNavigation")
                        .WithMany("Note")
                        .HasForeignKey("NoteId")
                        .HasConstraintName("FK_Note_Initiative");
                });
#pragma warning restore 612, 618
        }
    }
}

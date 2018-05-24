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
    [Migration("20180524131636_inheritedClass")]
    partial class inheritedClass
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Initiatives.Models.Business", b =>
                {
                    b.Property<int>("BusinessId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BusinessDescription")
                        .IsRequired()
                        .HasColumnType("nchar(25)");

                    b.Property<string>("BusinessShortDescription")
                        .IsRequired()
                        .HasColumnType("nchar(15)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<string>("ModifiedUserName")
                        .IsRequired()
                        .HasColumnType("nchar(150)");

                    b.HasKey("BusinessId");

                    b.ToTable("Businesses");
                });

            modelBuilder.Entity("Initiatives.Models.EngagementType", b =>
                {
                    b.Property<int>("EngagementTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EngagementTypeDescription")
                        .IsRequired()
                        .HasColumnType("nchar(25)");

                    b.Property<string>("EngagementTypeShortDescription")
                        .IsRequired()
                        .HasColumnType("nchar(15)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<string>("ModifiedUserName")
                        .IsRequired()
                        .HasColumnType("nchar(150)");

                    b.HasKey("EngagementTypeId");

                    b.ToTable("EngagementType");
                });

            modelBuilder.Entity("Initiatives.Models.Facility", b =>
                {
                    b.Property<int>("FacilityId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FacilityDescription")
                        .IsRequired()
                        .HasColumnType("nchar(25)");

                    b.Property<string>("FacilityShortDescription")
                        .IsRequired()
                        .HasColumnType("nchar(15)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<string>("ModifiedUserName")
                        .IsRequired()
                        .HasColumnType("nchar(150)");

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

                    b.Property<int?>("DeploymentLocation");

                    b.Property<string>("DownStreamSystem")
                        .HasColumnType("nchar(25)");

                    b.Property<string>("EngagementIdentifier")
                        .HasColumnType("nchar(15)");

                    b.Property<string>("EngagementName")
                        .HasColumnType("nchar(15)");

                    b.Property<int?>("EngagementType");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<string>("ModifiedUserName")
                        .IsRequired()
                        .HasColumnType("nchar(150)");

                    b.Property<bool>("PCI")
                        .HasColumnType("bit");

                    b.Property<bool>("PHI")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ProjectStartDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("ReceiveDate")
                        .HasColumnType("date");

                    b.Property<int?>("Resource");

                    b.Property<int?>("SolutionType");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("date");

                    b.Property<string>("UpStreamSystem")
                        .HasColumnType("nchar(25)");

                    b.HasKey("InitiativeId");

                    b.HasIndex("DeploymentLocation");

                    b.HasIndex("EngagementType");

                    b.HasIndex("Resource");

                    b.HasIndex("SolutionType");

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
                        .HasColumnType("nchar(25)");

                    b.Property<string>("LocationShortDescription")
                        .IsRequired()
                        .HasColumnType("nchar(15)");

                    b.Property<string>("ModifiedUserName")
                        .IsRequired()
                        .HasColumnType("nchar(150)");

                    b.HasKey("LocationId");

                    b.ToTable("DeploymentLocation");
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
                        .HasColumnType("nchar(25)");

                    b.Property<string>("MetaTagShortDescription")
                        .IsRequired()
                        .HasColumnType("nchar(15)");

                    b.Property<string>("ModifiedUserName")
                        .IsRequired()
                        .HasColumnType("nchar(150)");

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
                        .IsRequired()
                        .HasColumnType("nchar(150)");

                    b.Property<string>("Note1")
                        .IsRequired()
                        .HasColumnName("Note");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nchar(150)");

                    b.HasKey("NoteId");

                    b.ToTable("Note");
                });

            modelBuilder.Entity("Initiatives.Models.Resource", b =>
                {
                    b.Property<int>("ResourceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nchar(15)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nchar(15)");

                    b.Property<string>("ModifiedUserName")
                        .IsRequired()
                        .HasColumnType("nchar(150)");

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
                        .IsRequired()
                        .HasColumnType("nchar(150)");

                    b.Property<string>("SolutionTypeDescription")
                        .IsRequired()
                        .HasColumnType("nchar(25)");

                    b.Property<string>("SolutionTypeShortDescription")
                        .IsRequired()
                        .HasColumnType("nchar(15)");

                    b.HasKey("SolutionTypeId");

                    b.ToTable("SolutionType");
                });

            modelBuilder.Entity("Initiatives.Models.Initiative", b =>
                {
                    b.HasOne("Initiatives.Models.Location", "LocationNavigation")
                        .WithMany("Initiative")
                        .HasForeignKey("DeploymentLocation")
                        .HasConstraintName("FK_Initiative_DeploymentLocation");

                    b.HasOne("Initiatives.Models.EngagementType", "EngagementTypeNavigation")
                        .WithMany("Initiative")
                        .HasForeignKey("EngagementType")
                        .HasConstraintName("FK_Initiative_EngagementType");

                    b.HasOne("Initiatives.Models.Resource", "ResourceNavigation")
                        .WithMany("Initiative")
                        .HasForeignKey("Resource")
                        .HasConstraintName("FK_Initiative_Resource");

                    b.HasOne("Initiatives.Models.SolutionType", "SolutionTypeNavigation")
                        .WithMany("Initiative")
                        .HasForeignKey("SolutionType")
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
                    b.HasOne("Initiatives.Models.Initiative", "Initiative")
                        .WithOne("Note")
                        .HasForeignKey("Initiatives.Models.Note", "NoteId")
                        .HasConstraintName("FK_Note_Initiative");
                });
#pragma warning restore 612, 618
        }
    }
}

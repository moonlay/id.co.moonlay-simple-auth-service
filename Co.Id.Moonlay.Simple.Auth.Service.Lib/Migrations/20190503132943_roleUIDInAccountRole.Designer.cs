﻿// <auto-generated />
using System;
using Co.Id.Moonlay.Simple.Auth.Service.Lib;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.Migrations
{
    [DbContext(typeof(AuthDbContext))]
    [Migration("20190503132943_roleUIDInAccountRole")]
    partial class roleUIDInAccountRole
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Co.Id.Moonlay.Simple.Auth.Service.Lib.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("CreatedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreatedUtc");

                    b.Property<string>("DeletedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("DeletedUtc");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsLocked");

                    b.Property<string>("LastModifiedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("LastModifiedUtc");

                    b.Property<string>("Password")
                        .HasMaxLength(255);

                    b.Property<string>("UId")
                        .HasMaxLength(255);

                    b.Property<string>("Username")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Co.Id.Moonlay.Simple.Auth.Service.Lib.Models.AccountProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId");

                    b.Property<bool>("Active");

                    b.Property<string>("CreatedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreatedUtc");

                    b.Property<string>("DeletedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("DeletedUtc");

                    b.Property<DateTimeOffset?>("Dob");

                    b.Property<string>("Email");

                    b.Property<string>("Firstname")
                        .HasMaxLength(255);

                    b.Property<string>("Gender")
                        .HasMaxLength(6);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastModifiedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("LastModifiedUtc");

                    b.Property<string>("Lastname")
                        .HasMaxLength(255);

                    b.Property<string>("UId")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("AccountProfiles");
                });

            modelBuilder.Entity("Co.Id.Moonlay.Simple.Auth.Service.Lib.Models.AccountRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId");

                    b.Property<bool>("Active");

                    b.Property<string>("CreatedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreatedUtc");

                    b.Property<string>("DeletedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("DeletedUtc");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastModifiedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("LastModifiedUtc");

                    b.Property<int>("RoleId");

                    b.Property<string>("RoleUId");

                    b.Property<string>("UId");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("RoleId");

                    b.ToTable("AccountRoles");
                });

            modelBuilder.Entity("Co.Id.Moonlay.Simple.Auth.Service.Lib.Models.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("CreatedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreatedUtc");

                    b.Property<string>("DeletedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("DeletedUtc");

                    b.Property<string>("Division")
                        .HasMaxLength(255);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastModifiedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("LastModifiedUtc");

                    b.Property<int>("RoleId");

                    b.Property<string>("UId")
                        .HasMaxLength(255);

                    b.Property<string>("Unit")
                        .HasMaxLength(255);

                    b.Property<string>("UnitCode")
                        .HasMaxLength(255);

                    b.Property<int>("UnitId");

                    b.Property<int>("permission");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("Co.Id.Moonlay.Simple.Auth.Service.Lib.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Code")
                        .HasMaxLength(255);

                    b.Property<string>("CreatedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreatedUtc");

                    b.Property<string>("DeletedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("DeletedUtc");

                    b.Property<string>("Description")
                        .HasMaxLength(3000);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastModifiedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("LastModifiedUtc");

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.Property<string>("UId")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Co.Id.Moonlay.Simple.Auth.Service.Lib.Models.AccountProfile", b =>
                {
                    b.HasOne("Co.Id.Moonlay.Simple.Auth.Service.Lib.Models.Account", "Account")
                        .WithOne("AccountProfile")
                        .HasForeignKey("Co.Id.Moonlay.Simple.Auth.Service.Lib.Models.AccountProfile", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Co.Id.Moonlay.Simple.Auth.Service.Lib.Models.AccountRole", b =>
                {
                    b.HasOne("Co.Id.Moonlay.Simple.Auth.Service.Lib.Models.Account", "Account")
                        .WithMany("AccountRoles")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Co.Id.Moonlay.Simple.Auth.Service.Lib.Models.Role", "Role")
                        .WithMany("AccountRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Co.Id.Moonlay.Simple.Auth.Service.Lib.Models.Permission", b =>
                {
                    b.HasOne("Co.Id.Moonlay.Simple.Auth.Service.Lib.Models.Role", "Role")
                        .WithMany("Permissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

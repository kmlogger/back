﻿// <auto-generated />
using System;
using Infrastructure.Data.Hot;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(HotDbContext))]
    partial class HotDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.2");

            modelBuilder.Entity("Domain.Entities.App", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UUID")
                        .HasColumnName("Id");

                    b.Property<bool?>("Active")
                        .HasColumnType("UInt8")
                        .HasColumnName("Active");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("UUID");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DateTime")
                        .HasColumnName("CreatedDate")
                        .HasDefaultValueSql("now()");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("DateTime")
                        .HasColumnName("DeletedDate");

                    b.Property<int?>("Environment")
                        .HasColumnType("String")
                        .HasColumnName("Environment");

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DateTime")
                        .HasColumnName("UpdatedDate")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Apps", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UUID")
                        .HasColumnName("Id");

                    b.Property<bool?>("Active")
                        .HasColumnType("UInt8")
                        .HasColumnName("Active");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DateTime")
                        .HasColumnName("CreatedDate")
                        .HasDefaultValueSql("now()");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("DateTime")
                        .HasColumnName("DeletedDate");

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DateTime")
                        .HasColumnName("UpdatedDate")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.LogApp", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UUID")
                        .HasColumnName("Id");

                    b.Property<Guid>("AppId")
                        .HasColumnType("UUID");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DateTime")
                        .HasColumnName("CreatedDate")
                        .HasDefaultValueSql("now()");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("DateTime")
                        .HasColumnName("DeletedDate");

                    b.Property<string>("Environment")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Environment");

                    b.Property<string>("Level")
                        .HasColumnType("TEXT")
                        .HasColumnName("Level");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("DateTime")
                        .HasColumnName("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("AppId");

                    b.ToTable("LogApps", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UUID")
                        .HasColumnName("Id");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DateTime")
                        .HasColumnName("CreatedDate")
                        .HasDefaultValueSql("now()");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("DateTime")
                        .HasColumnName("DeletedDate");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("String")
                        .HasColumnName("Slug");

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DateTime")
                        .HasColumnName("UpdatedDate")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UUID")
                        .HasColumnName("Id");

                    b.Property<bool>("Active")
                        .HasColumnType("UInt8")
                        .HasColumnName("Active");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DateTime")
                        .HasColumnName("CreatedDate")
                        .HasDefaultValueSql("now()");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("DateTime")
                        .HasColumnName("DeletedDate");

                    b.Property<long?>("TokenActivate")
                        .HasColumnType("String")
                        .HasColumnName("TokenActivate");

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DateTime")
                        .HasColumnName("UpdatedDate")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("UserRole", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("UUID");

                    b.Property<Guid>("UserId")
                        .HasColumnType("UUID");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Domain.Entities.App", b =>
                {
                    b.HasOne("Domain.Entities.Category", "Category")
                        .WithMany("Apps")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("Domain.ValueObjects.UniqueName", "Name", b1 =>
                        {
                            b1.Property<Guid>("AppId")
                                .HasColumnType("UUID");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("String")
                                .HasColumnName("Name");

                            b1.HasKey("AppId");

                            b1.ToTable("Apps");

                            b1.WithOwner()
                                .HasForeignKey("AppId");
                        });

                    b.Navigation("Category");

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.OwnsOne("Domain.ValueObjects.UniqueName", "Name", b1 =>
                        {
                            b1.Property<Guid>("CategoryId")
                                .HasColumnType("UUID");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("String")
                                .HasColumnName("Name");

                            b1.HasKey("CategoryId");

                            b1.ToTable("Categories");

                            b1.WithOwner()
                                .HasForeignKey("CategoryId");
                        });

                    b.Navigation("Name");
                });

            modelBuilder.Entity("Domain.Entities.LogApp", b =>
                {
                    b.HasOne("Domain.Entities.App", "App")
                        .WithMany("Logs")
                        .HasForeignKey("AppId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("Domain.ValueObjects.Description", "Message", b1 =>
                        {
                            b1.Property<Guid>("LogAppId")
                                .HasColumnType("UUID");

                            b1.Property<string>("Text")
                                .IsRequired()
                                .HasColumnType("String")
                                .HasColumnName("Message");

                            b1.HasKey("LogAppId");

                            b1.ToTable("LogApps");

                            b1.WithOwner()
                                .HasForeignKey("LogAppId");
                        });

                    b.OwnsOne("Domain.ValueObjects.StackTrace", "StackTrace", b1 =>
                        {
                            b1.Property<Guid>("LogAppId")
                                .HasColumnType("UUID");

                            b1.Property<string>("Body")
                                .HasColumnType("String")
                                .HasColumnName("StackTrace");

                            b1.HasKey("LogAppId");

                            b1.ToTable("LogApps");

                            b1.WithOwner()
                                .HasForeignKey("LogAppId");
                        });

                    b.Navigation("App");

                    b.Navigation("Message");

                    b.Navigation("StackTrace");
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.OwnsOne("Domain.ValueObjects.UniqueName", "Name", b1 =>
                        {
                            b1.Property<Guid>("RoleId")
                                .HasColumnType("UUID");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("String")
                                .HasColumnName("Name");

                            b1.HasKey("RoleId");

                            b1.ToTable("Roles");

                            b1.WithOwner()
                                .HasForeignKey("RoleId");
                        });

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.OwnsOne("Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("UUID");

                            b1.Property<string>("Complement")
                                .HasMaxLength(100)
                                .HasColumnType("String")
                                .HasColumnName("Complement");

                            b1.Property<string>("NeighBordHood")
                                .HasColumnType("String")
                                .HasColumnName("NeighborHood");

                            b1.Property<long?>("Number")
                                .HasColumnType("Int64")
                                .HasColumnName("Number");

                            b1.Property<string>("Road")
                                .HasMaxLength(100)
                                .HasColumnType("String")
                                .HasColumnName("Road");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("UUID");

                            b1.Property<string>("Address")
                                .HasMaxLength(50)
                                .HasColumnType("String")
                                .HasColumnName("Email");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Domain.ValueObjects.FullName", "FullName", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("UUID");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("String")
                                .HasColumnName("FirstName");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("String")
                                .HasColumnName("LastName");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Domain.ValueObjects.Password", "Password", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("UUID");

                            b1.Property<string>("Hash")
                                .HasColumnType("String")
                                .HasColumnName("Hash");

                            b1.Property<string>("Salt")
                                .HasColumnType("String")
                                .HasColumnName("Salt");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("FullName")
                        .IsRequired();

                    b.Navigation("Password")
                        .IsRequired();
                });

            modelBuilder.Entity("UserRole", b =>
                {
                    b.HasOne("Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.App", b =>
                {
                    b.Navigation("Logs");
                });

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.Navigation("Apps");
                });
#pragma warning restore 612, 618
        }
    }
}

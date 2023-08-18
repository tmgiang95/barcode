﻿// <auto-generated />
using System;
using Clean.WinF.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Clean.WinF.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20230815042036_UpgradeNet7AndAddUserTables")]
    partial class UpgradeNet7AndAddUserTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("Clean.WinF.Domain.Entities.Article", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Article", (string)null);
                });

            modelBuilder.Entity("Clean.WinF.Domain.Entities.Bobbin", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BobbinLabel")
                        .HasColumnType("TEXT");

                    b.Property<int>("BobbinNo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MachineNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StitchesOnBobbin")
                        .HasColumnType("TEXT");

                    b.Property<string>("ThreadLabel")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Bobbin", (string)null);
                });

            modelBuilder.Entity("Clean.WinF.Domain.Entities.Computer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MachineNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Computer");
                });

            modelBuilder.Entity("Clean.WinF.Domain.Entities.Languages.AppCodeGUIDefinition", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AppID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CodeGUI")
                        .HasColumnType("TEXT");

                    b.Property<string>("CodeGroupGUI")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Languages")
                        .HasColumnType("TEXT");

                    b.Property<string>("ObjectType")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("AppCodeGUIDefinition", (string)null);
                });

            modelBuilder.Entity("Clean.WinF.Domain.Entities.Languages.AppGroupGUIDefinition", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AppID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CodeGroup")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("AppGroupGUIDefinition", (string)null);
                });

            modelBuilder.Entity("Clean.WinF.Domain.Entities.Languages.ApplicationDefinition", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AppID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("AppDefinition", (string)null);
                });

            modelBuilder.Entity("Clean.WinF.Domain.Entities.Languages.Language", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<string>("Lang")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Language", (string)null);
                });

            modelBuilder.Entity("Clean.WinF.Domain.Entities.Menus.Menu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Desciption")
                        .HasColumnType("TEXT");

                    b.Property<string>("IconUrl")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ParentID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Menu", (string)null);
                });

            modelBuilder.Entity("Clean.WinF.Domain.Entities.Order", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ActualQuantity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ArticleCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("ArticleName")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OrderNo")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderQuantity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SABLabel")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("Clean.WinF.Domain.Entities.Part", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Part", (string)null);
                });

            modelBuilder.Entity("Clean.WinF.Domain.Entities.Protocol", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("EndLabe2Seamed")
                        .HasColumnType("TEXT");

                    b.Property<string>("EndLabel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EndLabelSeamed1")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("SeamDetailStatus")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SeamOK")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SerialNo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StitchesCrit1")
                        .HasColumnType("TEXT");

                    b.Property<string>("StitchesCrit2")
                        .HasColumnType("TEXT");

                    b.Property<string>("StitchesCrit3")
                        .HasColumnType("TEXT");

                    b.Property<string>("StitchesNotCrit1")
                        .HasColumnType("TEXT");

                    b.Property<string>("StitchesNotCrit2")
                        .HasColumnType("TEXT");

                    b.Property<string>("StitchesNotCrit4")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Protocol", (string)null);
                });

            modelBuilder.Entity("Clean.WinF.Domain.Entities.Report", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Path")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Report", (string)null);
                });

            modelBuilder.Entity("Clean.WinF.Domain.Entities.Setting", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ComputerID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ComputerName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LanguageBiasysControl")
                        .HasColumnType("TEXT");

                    b.Property<string>("LanguageBiasysDB")
                        .HasColumnType("TEXT");

                    b.Property<string>("PathOfBiasysControl")
                        .HasColumnType("TEXT");

                    b.Property<string>("PathOfProtocolDB")
                        .HasColumnType("TEXT");

                    b.Property<string>("Port")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("ComputerID")
                        .IsUnique();

                    b.ToTable("Setting");
                });

            modelBuilder.Entity("Clean.WinF.Domain.Entities.Supplier", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Fax")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Remark")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telephone")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Supplier", (string)null);
                });

            modelBuilder.Entity("Clean.WinF.Domain.Entities.Thread", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BatchNr")
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Locked")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("SABLabel")
                        .HasColumnType("TEXT");

                    b.Property<string>("SuppCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("SuppName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Thread", (string)null);
                });

            modelBuilder.Entity("Clean.WinF.Domain.Entities.Users.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsExecuted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsInserted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsRead")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserGroupID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserGroupID");

                    b.ToTable("Permission", (string)null);
                });

            modelBuilder.Entity("Clean.WinF.Domain.Entities.Users.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("ComputerNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ExpiredDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstFinger")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("SecondFinger")
                        .HasColumnType("TEXT");

                    b.Property<string>("ThirdFinger")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserGroupID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserImage")
                        .HasColumnType("TEXT");

                    b.Property<string>("WinAccount")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("ZKFingerReader")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("UserGroupID");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Clean.WinF.Domain.Entities.Users.UserGroup", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("UserGroup", (string)null);
                });

            modelBuilder.Entity("Clean.WinF.Domain.Entities.Setting", b =>
                {
                    b.HasOne("Clean.WinF.Domain.Entities.Computer", "Computers")
                        .WithOne("Settings")
                        .HasForeignKey("Clean.WinF.Domain.Entities.Setting", "ComputerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Computers");
                });

            modelBuilder.Entity("Clean.WinF.Domain.Entities.Users.Permission", b =>
                {
                    b.HasOne("Clean.WinF.Domain.Entities.Users.UserGroup", "UserGroups")
                        .WithMany("Permissions")
                        .HasForeignKey("UserGroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserGroups");
                });

            modelBuilder.Entity("Clean.WinF.Domain.Entities.Users.User", b =>
                {
                    b.HasOne("Clean.WinF.Domain.Entities.Users.UserGroup", "UserGroups")
                        .WithMany("Users")
                        .HasForeignKey("UserGroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserGroups");
                });

            modelBuilder.Entity("Clean.WinF.Domain.Entities.Computer", b =>
                {
                    b.Navigation("Settings");
                });

            modelBuilder.Entity("Clean.WinF.Domain.Entities.Users.UserGroup", b =>
                {
                    b.Navigation("Permissions");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}

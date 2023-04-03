﻿/*// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web_MVC.Data;

#nullable disable

namespace Web_MVC.Migrations
{
    [DbContext(typeof(Web_MVCContext))]
    [Migration("20230310234802_InitialCreate2")]
    partial class InitialCreate2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("baza.Models.Category", b =>
                {
                    b.Property<long>("IdCategory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdCategory"));

                    b.Property<long>("IdUser")
                        .HasColumnType("bigint");

                    b.Property<long>("IdUserNavigationIdUsr")
                        .HasColumnType("bigint");

                    b.Property<string>("NameCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UsedCountCategory")
                        .HasColumnType("bigint");

                    b.HasKey("IdCategory");

                    b.HasIndex("IdUserNavigationIdUsr");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("baza.Models.Day", b =>
                {
                    b.Property<long>("IdDay")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdDay"));

                    b.Property<DateTime>("DayDate")
                        .HasColumnType("datetime2");

                    b.Property<double?>("DayEnabledValue")
                        .HasColumnType("float");

                    b.Property<double?>("DayFactValue")
                        .HasColumnType("float");

                    b.HasKey("IdDay");

                    b.ToTable("Day");
                });

            modelBuilder.Entity("baza.Models.Month", b =>
                {
                    b.Property<long>("IdMonth")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdMonth"));

                    b.Property<long>("IdUser")
                        .HasColumnType("bigint");

                    b.Property<long>("IdUserNavigationIdUsr")
                        .HasColumnType("bigint");

                    b.Property<long>("Month1")
                        .HasColumnType("bigint");

                    b.Property<double>("MonyLimit")
                        .HasColumnType("float");

                    b.Property<long>("Year")
                        .HasColumnType("bigint");

                    b.HasKey("IdMonth");

                    b.HasIndex("IdUserNavigationIdUsr");

                    b.ToTable("Month");
                });

            modelBuilder.Entity("baza.Models.Usr", b =>
                {
                    b.Property<long>("IdUsr")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdUsr"));

                    b.Property<string>("LoginUsr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordUsr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsr");

                    b.ToTable("Usr");
                });

            modelBuilder.Entity("baza.Models.Waste", b =>
                {
                    b.Property<long>("IdWaste")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdWaste"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("IdCategory")
                        .HasColumnType("bigint");

                    b.Property<long>("IdCategoryNavigationIdCategory")
                        .HasColumnType("bigint");

                    b.Property<long>("IdDay")
                        .HasColumnType("bigint");

                    b.Property<long>("IdDayNavigationIdDay")
                        .HasColumnType("bigint");

                    b.Property<long>("IdUser")
                        .HasColumnType("bigint");

                    b.Property<long>("IdUserNavigationIdUsr")
                        .HasColumnType("bigint");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("IdWaste");

                    b.HasIndex("IdCategoryNavigationIdCategory");

                    b.HasIndex("IdDayNavigationIdDay");

                    b.HasIndex("IdUserNavigationIdUsr");

                    b.ToTable("Waste");
                });

            modelBuilder.Entity("baza.Models.Category", b =>
                {
                    b.HasOne("baza.Models.Usr", "IdUserNavigation")
                        .WithMany("Categories")
                        .HasForeignKey("IdUserNavigationIdUsr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("baza.Models.Month", b =>
                {
                    b.HasOne("baza.Models.Usr", "IdUserNavigation")
                        .WithMany("Months")
                        .HasForeignKey("IdUserNavigationIdUsr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("baza.Models.Waste", b =>
                {
                    b.HasOne("baza.Models.Category", "IdCategoryNavigation")
                        .WithMany("Wastes")
                        .HasForeignKey("IdCategoryNavigationIdCategory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("baza.Models.Day", "IdDayNavigation")
                        .WithMany("Wastes")
                        .HasForeignKey("IdDayNavigationIdDay")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("baza.Models.Usr", "IdUserNavigation")
                        .WithMany("Wastes")
                        .HasForeignKey("IdUserNavigationIdUsr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdCategoryNavigation");

                    b.Navigation("IdDayNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("baza.Models.Category", b =>
                {
                    b.Navigation("Wastes");
                });

            modelBuilder.Entity("baza.Models.Day", b =>
                {
                    b.Navigation("Wastes");
                });

            modelBuilder.Entity("baza.Models.Usr", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Months");

                    b.Navigation("Wastes");
                });
#pragma warning restore 612, 618
        }
    }
}
*/
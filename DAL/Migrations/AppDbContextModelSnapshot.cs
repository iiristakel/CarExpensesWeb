﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity("Domain.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CarBrand")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("CarModel")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Owner");

                    b.Property<string>("ReleaseDate")
                        .IsRequired();

                    b.HasKey("CarId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Domain.CarExpensesInCategory", b =>
                {
                    b.Property<int>("CarExpensesInCategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CarId");

                    b.Property<string>("Comments");

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("Expense")
                        .IsRequired();

                    b.Property<int>("ExpenseCategoryId");

                    b.HasKey("CarExpensesInCategoryId");

                    b.HasIndex("CarId");

                    b.HasIndex("ExpenseCategoryId");

                    b.ToTable("CarsExpensesInCategories");
                });

            modelBuilder.Entity("Domain.ExpenseCategory", b =>
                {
                    b.Property<int>("ExpenseCategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("ExpenseCategoryId");

                    b.ToTable("ExpenseCategories");
                });

            modelBuilder.Entity("Domain.CarExpensesInCategory", b =>
                {
                    b.HasOne("Domain.Car", "Car")
                        .WithMany("CarExpensesInCategories")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.ExpenseCategory", "ExpenseCategory")
                        .WithMany("CarsExpensesInCategory")
                        .HasForeignKey("ExpenseCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

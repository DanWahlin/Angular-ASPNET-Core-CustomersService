using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Angular_ASPNETCore_CustomersService.Repository;

namespace Angular_ASPNETCore_CustomersService.Migrations
{
    [DbContext(typeof(CustomersDbContext))]
    partial class CustomersDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("Angular_ASPNETCore_CustomersService.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<string>("LastName");

                    b.Property<int>("OrderCount");

                    b.Property<int>("StateId");

                    b.Property<int>("Zip");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Angular_ASPNETCore_CustomersService.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CustomerId");

                    b.Property<decimal>("Price");

                    b.Property<string>("Product");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Angular_ASPNETCore_CustomersService.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abbreviation");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("States");
                });

            modelBuilder.Entity("Angular_ASPNETCore_CustomersService.Models.Customer", b =>
                {
                    b.HasOne("Angular_ASPNETCore_CustomersService.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Angular_ASPNETCore_CustomersService.Models.Order", b =>
                {
                    b.HasOne("Angular_ASPNETCore_CustomersService.Models.Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId");
                });
        }
    }
}

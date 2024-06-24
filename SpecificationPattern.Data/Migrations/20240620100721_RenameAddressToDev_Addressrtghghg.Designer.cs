﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpecificationPattern.Data;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240620100721_RenameAddressToDev_Addressrtghghg")]
    partial class RenameAddressToDev_Addressrtghghg
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SpecificationPattern.Core.Entities.Dev_Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Dev_Address");
                });

            modelBuilder.Entity("SpecificationPattern.Core.Entities.Developer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Dev_AddressId")
                        .HasColumnType("int");

                    b.Property<decimal>("Income")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Dev_AddressId");

                    b.ToTable("Developers");
                });

            modelBuilder.Entity("SpecificationPattern.Core.Entities.Developer", b =>
                {
                    b.HasOne("SpecificationPattern.Core.Entities.Dev_Address", "Dev_Address")
                        .WithMany()
                        .HasForeignKey("Dev_AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dev_Address");
                });
#pragma warning restore 612, 618
        }
    }
}

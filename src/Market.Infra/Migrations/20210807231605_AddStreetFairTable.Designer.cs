﻿// <auto-generated />
using System;
using Market.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Market.Infra.Migrations
{
    [DbContext(typeof(EntityContext))]
    [Migration("20210807231605_AddStreetFairTable")]
    partial class AddStreetFairTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Market.Domain.Entities.StreetFair", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("address");

                    b.Property<string>("AddressDetails")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("address_details");

                    b.Property<string>("AddressNumber")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("address_number");

                    b.Property<int>("CensusGrouping")
                        .HasColumnType("integer")
                        .HasColumnName("census_grouping");

                    b.Property<int>("CensusSector")
                        .HasColumnType("integer")
                        .HasColumnName("census_sector");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("district");

                    b.Property<int>("DistrictCode")
                        .HasColumnType("integer")
                        .HasColumnName("district_code");

                    b.Property<int>("Latitude")
                        .HasColumnType("integer")
                        .HasColumnName("latitude");

                    b.Property<int>("Longitude")
                        .HasColumnType("integer")
                        .HasColumnName("longitude");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("neighborhood");

                    b.Property<string>("Region5")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("varchar(6)")
                        .HasColumnName("region5");

                    b.Property<string>("Region8")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("varchar(7)")
                        .HasColumnName("region8");

                    b.Property<string>("Register")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("varchar(6)")
                        .HasColumnName("register");

                    b.Property<string>("SubCityHall")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("sub_city_hall");

                    b.Property<int>("SubCityHallCode")
                        .HasColumnType("integer")
                        .HasColumnName("sub_city_hall_code");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_date");

                    b.HasKey("Id")
                        .HasName("pk_street_fairs");

                    b.HasIndex("DistrictCode")
                        .IsUnique()
                        .HasDatabaseName("ix_street_fairs_district_code");

                    b.ToTable("street_fairs");
                });
#pragma warning restore 612, 618
        }
    }
}

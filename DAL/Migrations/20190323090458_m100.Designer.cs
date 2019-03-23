﻿// <auto-generated />
using GeoAPI.Geometries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mycity.DAL.Models;

namespace DAL.Migrations
{
    [DbContext(typeof(mycityDbContext))]
    [Migration("20190323090458_m100")]
    partial class m100
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("mycity.DAL.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("personID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Department")
                        .HasColumnName("department")
                        .HasMaxLength(50);

                    b.Property<string>("Lname")
                        .HasColumnName("lname")
                        .HasMaxLength(50);

                    b.Property<IGeometry>("Location")
                        .HasColumnName("location");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasMaxLength(50);

                    b.Property<string>("Tel")
                        .HasColumnName("tel")
                        .HasMaxLength(50);

                    b.HasKey("PersonId");

                    b.ToTable("person");
                });

            modelBuilder.Entity("mycity.DAL.Models.Places", b =>
                {
                    b.Property<int>("PlacesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("placesID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnName("address")
                        .HasMaxLength(50);

                    b.Property<IGeometry>("Location")
                        .HasColumnName("location");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasMaxLength(50);

                    b.Property<string>("Pic1Url")
                        .HasColumnName("pic_1_url")
                        .HasMaxLength(500);

                    b.Property<string>("Pic2Url")
                        .HasColumnName("pic_2_url")
                        .HasMaxLength(500);

                    b.Property<string>("Tel")
                        .HasColumnName("tel")
                        .HasMaxLength(50);

                    b.Property<string>("Type")
                        .HasColumnName("type")
                        .HasMaxLength(50);

                    b.Property<string>("Url")
                        .HasColumnName("url")
                        .HasMaxLength(50);

                    b.Property<string>("geo_type");

                    b.HasKey("PlacesId");

                    b.ToTable("places");
                });
#pragma warning restore 612, 618
        }
    }
}

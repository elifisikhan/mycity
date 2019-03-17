﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace mycity.DAL.Models
{
    public partial class mycityDbContext : DbContext
    {
        public mycityDbContext()
        {
        }

        public mycityDbContext(DbContextOptions<mycityDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Places> Places { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=SQL6006.site4now.net;Initial Catalog=DB_A468C5_mycityoftroia;User Id=DB_A468C5_mycityoftroia_admin;Password=2F5Xn5zM2THAGvP;", x => x.UseNetTopologySuite());
                //optionsBuilder.UseSqlServer(@"Server=sql6006.site4now.net; Database=DB_A468C5_mycityoftroia;;", x => x.UseNetTopologySuite());
                //"Data Source=SQL6006.site4now.net;Initial Catalog=DB_A468C5_mycityoftroia;User Id=DB_A468C5_mycityoftroia_admin;Password=2F5Xn5zM2THAGvP;"


            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.Property(e => e.PersonId).HasColumnName("personID");

                entity.Property(e => e.Department)
                    .HasColumnName("department")
                    .HasMaxLength(50);

                entity.Property(e => e.Lname)
                    .HasColumnName("lname")
                    .HasMaxLength(50);

                entity.Property(e => e.Location).HasColumnName("location");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Tel)
                    .HasColumnName("tel")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Places>(entity =>
            {
                entity.ToTable("places");

                entity.Property(e => e.PlacesId).HasColumnName("placesID");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(50);

                entity.Property(e => e.Location).HasColumnName("location");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Pic1Url)
                    .HasColumnName("pic_1_url")
                    .HasMaxLength(500);

                entity.Property(e => e.Pic2Url)
                    .HasColumnName("pic_2_url")
                    .HasMaxLength(500);

                entity.Property(e => e.Tel)
                    .HasColumnName("tel")
                    .HasMaxLength(50);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50);

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(50);
            });
        }
    }
}

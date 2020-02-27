﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Plants;

namespace Plants.Migrations
{
    [DbContext(typeof(PlantDatabaseContext))]
    [Migration("20200227011000_CreatedGardenTable2")]
    partial class CreatedGardenTable2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Plants.Garden", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("LastWateredDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("LightNeeded")
                        .HasColumnType("integer");

                    b.Property<DateTime>("PlantedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Species")
                        .HasColumnType("text");

                    b.Property<int>("WaterFrequency")
                        .HasColumnType("integer");

                    b.Property<int>("WaterNeeded")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Gardens");
                });

            modelBuilder.Entity("Plants.Plant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Garden_id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastWateredDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("LightNeeded")
                        .HasColumnType("integer");

                    b.Property<string>("LocatedPlanted")
                        .HasColumnType("text");

                    b.Property<DateTime>("PlantedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Species")
                        .HasColumnType("text");

                    b.Property<int>("WaterFrequency")
                        .HasColumnType("integer");

                    b.Property<int>("WaterNeeded")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Plants");
                });
#pragma warning restore 612, 618
        }
    }
}

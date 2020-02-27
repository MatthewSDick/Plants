﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Plants.Migrations
{
    public partial class CreatedGardenTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Garden_id",
                table: "Plants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Gardens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Species = table.Column<string>(nullable: true),
                    PlantedDate = table.Column<DateTime>(nullable: false),
                    LastWateredDate = table.Column<DateTime>(nullable: false),
                    LightNeeded = table.Column<int>(nullable: false),
                    WaterNeeded = table.Column<int>(nullable: false),
                    WaterFrequency = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gardens", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gardens");

            migrationBuilder.DropColumn(
                name: "Garden_id",
                table: "Plants");
        }
    }
}
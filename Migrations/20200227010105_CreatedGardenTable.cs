using Microsoft.EntityFrameworkCore.Migrations;

namespace Plants.Migrations
{
    public partial class CreatedGardenTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WaterFrequency",
                table: "Plants",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WaterFrequency",
                table: "Plants");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace TCC.Candle.Data.Migrations
{
    public partial class AddLibraryImageUrlproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Libraries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Libraries");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace TCC.Candle.Data.Migrations
{
    public partial class RemovedVolumeModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Volumes_VolumeId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Volumes");

            migrationBuilder.DropIndex(
                name: "IX_Books_VolumeId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "VolumeId",
                table: "Books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "VolumeId",
                table: "Books",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Volumes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    Description = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    ShelfId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volumes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Volumes_Shelves_ShelfId",
                        column: x => x.ShelfId,
                        principalTable: "Shelves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_VolumeId",
                table: "Books",
                column: "VolumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Volumes_ShelfId",
                table: "Volumes",
                column: "ShelfId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Volumes_VolumeId",
                table: "Books",
                column: "VolumeId",
                principalTable: "Volumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

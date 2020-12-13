using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hostel.Persistance.Migrations
{
    public partial class HostelTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "HostelId",
                table: "Rooms",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Hostels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hostels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HostelId",
                table: "Rooms",
                column: "HostelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Hostels_HostelId",
                table: "Rooms",
                column: "HostelId",
                principalTable: "Hostels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Hostels_HostelId",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "Hostels");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_HostelId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "HostelId",
                table: "Rooms");
        }
    }
}

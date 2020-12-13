using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hostel.Persistance.Migrations
{
    public partial class AlterUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "HostelId",
                table: "Users",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HostelId",
                table: "Users");
        }
    }
}

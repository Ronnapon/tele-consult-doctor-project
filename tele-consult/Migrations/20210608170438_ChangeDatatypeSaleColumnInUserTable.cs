using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tele_consult.Migrations
{
    public partial class ChangeDatatypeSaleColumnInUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "Salt",
               table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Users");
        }
    }
}

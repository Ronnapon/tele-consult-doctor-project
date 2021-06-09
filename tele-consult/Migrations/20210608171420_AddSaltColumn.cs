using Microsoft.EntityFrameworkCore.Migrations;

namespace tele_consult.Migrations
{
    public partial class AddSaltColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
               name: "Salt",
               table: "Users",
               type: "varbinary(max)",
               nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

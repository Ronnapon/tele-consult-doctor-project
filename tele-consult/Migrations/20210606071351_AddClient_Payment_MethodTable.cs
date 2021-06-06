using Microsoft.EntityFrameworkCore.Migrations;

namespace tele_consult.Migrations
{
    public partial class AddClient_Payment_MethodTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Client_Payment_MethodId",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Client_Payment_Methods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client_Payment_Methods", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Client_Payment_MethodId",
                table: "Clients",
                column: "Client_Payment_MethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Client_Payment_Methods_Client_Payment_MethodId",
                table: "Clients",
                column: "Client_Payment_MethodId",
                principalTable: "Client_Payment_Methods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Client_Payment_Methods_Client_Payment_MethodId",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "Client_Payment_Methods");

            migrationBuilder.DropIndex(
                name: "IX_Clients_Client_Payment_MethodId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Client_Payment_MethodId",
                table: "Clients");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace tele_consult.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Client_Payment_Methods_Client_Payment_MethodId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_Client_Payment_MethodId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Client_Payment_MethodId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Payment_Method_Id",
                table: "Clients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Client_Payment_MethodId",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Payment_Method_Id",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketApp.Persistance.EF.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "EmployeeTickets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTickets_EmployeeId",
                table: "EmployeeTickets",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTickets_Calisanlar_EmployeeId",
                table: "EmployeeTickets",
                column: "EmployeeId",
                principalTable: "Calisanlar",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTickets_Calisanlar_EmployeeId",
                table: "EmployeeTickets");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTickets_EmployeeId",
                table: "EmployeeTickets");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "EmployeeTickets");
        }
    }
}

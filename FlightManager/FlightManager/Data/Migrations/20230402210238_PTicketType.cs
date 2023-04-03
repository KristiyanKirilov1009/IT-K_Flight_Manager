using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightManager.Data.Migrations
{
    public partial class PTicketType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketType",
                table: "Passengers");

            migrationBuilder.AddColumn<string>(
                name: "TicketTypeId",
                table: "Passengers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_TicketTypeId",
                table: "Passengers",
                column: "TicketTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_TicketTypes_TicketTypeId",
                table: "Passengers",
                column: "TicketTypeId",
                principalTable: "TicketTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_TicketTypes_TicketTypeId",
                table: "Passengers");

            migrationBuilder.DropIndex(
                name: "IX_Passengers_TicketTypeId",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "TicketTypeId",
                table: "Passengers");

            migrationBuilder.AddColumn<string>(
                name: "TicketType",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

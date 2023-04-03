using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightManager.Data.Migrations
{
    public partial class RemoveTT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_TicketTypes_TicketTypeId",
                table: "Passengers");

            migrationBuilder.DropTable(
                name: "TicketTypes");

            migrationBuilder.DropIndex(
                name: "IX_Passengers_TicketTypeId",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "TicketTypeId",
                table: "Passengers");

            migrationBuilder.AddColumn<int>(
                name: "TicketType",
                table: "Passengers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketType",
                table: "Passengers");

            migrationBuilder.AddColumn<string>(
                name: "TicketTypeId",
                table: "Passengers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TicketTypes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketTypes", x => x.Id);
                });

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
    }
}

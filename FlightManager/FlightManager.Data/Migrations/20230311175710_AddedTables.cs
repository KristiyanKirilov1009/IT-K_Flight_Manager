using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightManager.Data.Migrations
{
    public partial class AddedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passangers_Reservations_ReservationID",
                table: "Passangers");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Reservations",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "EGN",
                table: "Reservations",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<int>(
                name: "ReservationID",
                table: "Passangers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Passangers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "EGN",
                table: "Passangers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyLocation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyID);
                });

            migrationBuilder.CreateTable(
                name: "ReservationsPassangers",
                columns: table => new
                {
                    ReservationID = table.Column<int>(type: "int", nullable: false),
                    PassangerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationsPassangers", x => new { x.ReservationID, x.PassangerID });
                    table.ForeignKey(
                        name: "FK_ReservationsPassangers_Passangers_PassangerID",
                        column: x => x.PassangerID,
                        principalTable: "Passangers",
                        principalColumn: "PassangerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReservationsPassangers_Reservations_ReservationID",
                        column: x => x.ReservationID,
                        principalTable: "Reservations",
                        principalColumn: "ReservationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyID",
                table: "Users",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_CompanyID",
                table: "Flights",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationsPassangers_PassangerID",
                table: "ReservationsPassangers",
                column: "PassangerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Companies_CompanyID",
                table: "Flights",
                column: "CompanyID",
                principalTable: "Companies",
                principalColumn: "CompanyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Passangers_Reservations_ReservationID",
                table: "Passangers",
                column: "ReservationID",
                principalTable: "Reservations",
                principalColumn: "ReservationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Companies_CompanyID",
                table: "Users",
                column: "CompanyID",
                principalTable: "Companies",
                principalColumn: "CompanyID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Companies_CompanyID",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Passangers_Reservations_ReservationID",
                table: "Passangers");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Companies_CompanyID",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "ReservationsPassangers");

            migrationBuilder.DropIndex(
                name: "IX_Users_CompanyID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Flights_CompanyID",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "Flights");

            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "Users",
                type: "int",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "Reservations",
                type: "int",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<int>(
                name: "EGN",
                table: "Reservations",
                type: "int",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<int>(
                name: "ReservationID",
                table: "Passangers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "Passangers",
                type: "int",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<int>(
                name: "EGN",
                table: "Passangers",
                type: "int",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddForeignKey(
                name: "FK_Passangers_Reservations_ReservationID",
                table: "Passangers",
                column: "ReservationID",
                principalTable: "Reservations",
                principalColumn: "ReservationID");
        }
    }
}

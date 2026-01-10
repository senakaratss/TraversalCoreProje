using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_remove_destination_from_reservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "DestinationID",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_DestinationID",
                table: "Reservations",
                column: "DestinationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Destinations_DestinationID",
                table: "Reservations",
                column: "DestinationID",
                principalTable: "Destinations",
                principalColumn: "DestinationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Destinations_DestinationID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_DestinationID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "DestinationID",
                table: "Reservations");

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

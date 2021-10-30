using Microsoft.EntityFrameworkCore.Migrations;

namespace BookReservation.Repository.Migrations
{
    public partial class AddRelationshipRecourcesBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResouceId",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "ResourceId",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ResourceId",
                table: "Bookings",
                column: "ResourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Resources_ResourceId",
                table: "Bookings",
                column: "ResourceId",
                principalTable: "Resources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Resources_ResourceId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ResourceId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ResourceId",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "ResouceId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

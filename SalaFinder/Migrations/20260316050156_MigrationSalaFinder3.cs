using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalaFinder.Migrations
{
    /// <inheritdoc />
    public partial class MigrationSalaFinder3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_spaceId",
                table: "Reservations",
                column: "spaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_userId",
                table: "Reservations",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_userId",
                table: "Reservations",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Spaces_spaceId",
                table: "Reservations",
                column: "spaceId",
                principalTable: "Spaces",
                principalColumn: "id_space",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_userId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Spaces_spaceId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_spaceId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_userId",
                table: "Reservations");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}

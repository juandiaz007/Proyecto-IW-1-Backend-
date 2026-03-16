using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalaFinder.Migrations
{
    /// <inheritdoc />
    public partial class MigrationSalaFinder4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "NoShows",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "AuditLogs",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_NoShows_userId",
                table: "NoShows",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_userId",
                table: "AuditLogs",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditLogs_AspNetUsers_userId",
                table: "AuditLogs",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NoShows_AspNetUsers_userId",
                table: "NoShows",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditLogs_AspNetUsers_userId",
                table: "AuditLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_NoShows_AspNetUsers_userId",
                table: "NoShows");

            migrationBuilder.DropIndex(
                name: "IX_NoShows_userId",
                table: "NoShows");

            migrationBuilder.DropIndex(
                name: "IX_AuditLogs_userId",
                table: "AuditLogs");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "NoShows",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "AuditLogs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}

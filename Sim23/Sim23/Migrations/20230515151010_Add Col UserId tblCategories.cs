using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sim23.Migrations
{
    /// <inheritdoc />
    public partial class AddColUserIdtblCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "tblCategories",
                type: "integer",
                nullable: true);
            
            migrationBuilder.CreateIndex(
                name: "IX_tblCategories_UserId",
                table: "tblCategories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblCategories_AspNetUsers_UserId",
                table: "tblCategories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblCategories_AspNetUsers_UserId",
                table: "tblCategories");

            migrationBuilder.DropIndex(
                name: "IX_tblCategories_UserId",
                table: "tblCategories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "tblCategories");
        }
    }
}

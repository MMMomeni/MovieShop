using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieShopMVC.Infrastructure.Migrations
{
    public partial class modified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MovieCast_CastId",
                table: "MovieCast");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCast_CastId",
                table: "MovieCast",
                column: "CastId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MovieCast_CastId",
                table: "MovieCast");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCast_CastId",
                table: "MovieCast",
                column: "CastId",
                unique: true);
        }
    }
}

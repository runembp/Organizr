using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Organizr.Infrastructure.Migrations
{
    public partial class AddedDbSetToContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsPost_AspNetUsers_MemberId",
                table: "NewsPost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NewsPost",
                table: "NewsPost");

            migrationBuilder.RenameTable(
                name: "NewsPost",
                newName: "NewsPosts");

            migrationBuilder.RenameIndex(
                name: "IX_NewsPost_MemberId",
                table: "NewsPosts",
                newName: "IX_NewsPosts_MemberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewsPosts",
                table: "NewsPosts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsPosts_AspNetUsers_MemberId",
                table: "NewsPosts",
                column: "MemberId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsPosts_AspNetUsers_MemberId",
                table: "NewsPosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NewsPosts",
                table: "NewsPosts");

            migrationBuilder.RenameTable(
                name: "NewsPosts",
                newName: "NewsPost");

            migrationBuilder.RenameIndex(
                name: "IX_NewsPosts_MemberId",
                table: "NewsPost",
                newName: "IX_NewsPost_MemberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewsPost",
                table: "NewsPost",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsPost_AspNetUsers_MemberId",
                table: "NewsPost",
                column: "MemberId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

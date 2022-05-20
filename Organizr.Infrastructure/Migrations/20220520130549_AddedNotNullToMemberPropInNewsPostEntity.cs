using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Organizr.Infrastructure.Migrations
{
    public partial class AddedNotNullToMemberPropInNewsPostEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsPosts_AspNetUsers_MemberId",
                table: "NewsPosts");

            migrationBuilder.AlterColumn<int>(
                name: "MemberId",
                table: "NewsPosts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NewsPosts_AspNetUsers_MemberId",
                table: "NewsPosts",
                column: "MemberId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsPosts_AspNetUsers_MemberId",
                table: "NewsPosts");

            migrationBuilder.AlterColumn<int>(
                name: "MemberId",
                table: "NewsPosts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsPosts_AspNetUsers_MemberId",
                table: "NewsPosts",
                column: "MemberId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

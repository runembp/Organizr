using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Organizr.Infrastructure.Migrations
{
    public partial class AddOneToManyRelationMemberGroupNewsPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MemberGroupId",
                table: "NewsPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NewsPosts_MemberGroupId",
                table: "NewsPosts",
                column: "MemberGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsPosts_MemberGroups_MemberGroupId",
                table: "NewsPosts",
                column: "MemberGroupId",
                principalTable: "MemberGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsPosts_MemberGroups_MemberGroupId",
                table: "NewsPosts");

            migrationBuilder.DropIndex(
                name: "IX_NewsPosts_MemberGroupId",
                table: "NewsPosts");

            migrationBuilder.DropColumn(
                name: "MemberGroupId",
                table: "NewsPosts");
        }
    }
}

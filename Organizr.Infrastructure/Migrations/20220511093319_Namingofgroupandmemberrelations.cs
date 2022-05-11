using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Organizr.Infrastructure.Migrations
{
    public partial class Namingofgroupandmemberrelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberMemberGroup_AspNetUsers_MemberId",
                table: "MemberMemberGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberMemberGroup_MemberGroups_GroupId",
                table: "MemberMemberGroup");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "MemberMemberGroup",
                newName: "MemberId");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "MemberMemberGroup",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_MemberMemberGroup_MemberId",
                table: "MemberMemberGroup",
                newName: "IX_MemberMemberGroup_MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberMemberGroup_AspNetUsers_MemberId",
                table: "MemberMemberGroup",
                column: "MemberId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberMemberGroup_MemberGroups_GroupId",
                table: "MemberMemberGroup",
                column: "GroupId",
                principalTable: "MemberGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberMemberGroup_AspNetUsers_MemberId",
                table: "MemberMemberGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberMemberGroup_MemberGroups_GroupId",
                table: "MemberMemberGroup");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "MemberMemberGroup",
                newName: "MemberId");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "MemberMemberGroup",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_MemberMemberGroup_MemberId",
                table: "MemberMemberGroup",
                newName: "IX_MemberMemberGroup_MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberMemberGroup_AspNetUsers_MemberId",
                table: "MemberMemberGroup",
                column: "MemberId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberMemberGroup_MemberGroups_GroupId",
                table: "MemberMemberGroup",
                column: "GroupId",
                principalTable: "MemberGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

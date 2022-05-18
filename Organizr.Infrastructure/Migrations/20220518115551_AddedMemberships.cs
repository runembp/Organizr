using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Organizr.Infrastructure.Migrations
{
    public partial class AddedMemberships : Migration
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
                newName: "MembersId");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "MemberMemberGroup",
                newName: "GroupsId");

            migrationBuilder.RenameIndex(
                name: "IX_MemberMemberGroup_MemberId",
                table: "MemberMemberGroup",
                newName: "IX_MemberMemberGroup_MembersId");

            migrationBuilder.CreateTable(
                name: "GroupRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberGroupId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    GroupRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Memberships_AspNetUsers_MemberId",
                        column: x => x.MemberId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Memberships_GroupRoles_GroupRoleId",
                        column: x => x.GroupRoleId,
                        principalTable: "GroupRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Memberships_MemberGroups_MemberGroupId",
                        column: x => x.MemberGroupId,
                        principalTable: "MemberGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_GroupRoleId",
                table: "Memberships",
                column: "GroupRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_MemberGroupId",
                table: "Memberships",
                column: "MemberGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_MemberId",
                table: "Memberships",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberMemberGroup_AspNetUsers_MembersId",
                table: "MemberMemberGroup",
                column: "MembersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberMemberGroup_MemberGroups_GroupsId",
                table: "MemberMemberGroup",
                column: "GroupsId",
                principalTable: "MemberGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberMemberGroup_AspNetUsers_MembersId",
                table: "MemberMemberGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberMemberGroup_MemberGroups_GroupsId",
                table: "MemberMemberGroup");

            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropTable(
                name: "GroupRoles");

            migrationBuilder.RenameColumn(
                name: "MembersId",
                table: "MemberMemberGroup",
                newName: "MemberId");

            migrationBuilder.RenameColumn(
                name: "GroupsId",
                table: "MemberMemberGroup",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_MemberMemberGroup_MembersId",
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

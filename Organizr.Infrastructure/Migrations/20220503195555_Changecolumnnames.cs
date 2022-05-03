using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Organizr.Infrastructure.Migrations
{
    public partial class Changecolumnnames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserGroupId",
                table: "UserGroups",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserGroups",
                newName: "UserGroupId");
        }
    }
}

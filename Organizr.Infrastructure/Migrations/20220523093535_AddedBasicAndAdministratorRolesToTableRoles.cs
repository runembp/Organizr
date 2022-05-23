using Microsoft.EntityFrameworkCore.Migrations;
using Organizr.Domain.Enums;

#nullable disable

namespace Organizr.Infrastructure.Migrations
{
    public partial class AddedBasicAndAdministratorRolesToTableRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description" },
                values: new object[]
                {
                    (int) GroupRole.Administrator,
                    "Administrator"
                });
            
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description" },
                values: new object[]
                {
                    (int) GroupRole.Basic,
                    "Basic"
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

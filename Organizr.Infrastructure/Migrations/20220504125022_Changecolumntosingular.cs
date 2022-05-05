using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Organizr.Infrastructure.Migrations
{
    public partial class Changecolumntosingular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdValues",
                table: "Configurations",
                newName: "IdValue");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdValue",
                table: "Configurations",
                newName: "IdValues");
        }
    }
}



#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;
using Organizr.Core.Enums;

namespace Organizr.Infrastructure.Migrations
{
    public partial class Addconfigurationstodatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Configurations
            
            migrationBuilder.InsertData(
                table: "Configurations", 
                columns: new[] {"ConfigType", "Description", "StringValue", "BoolValue", "IdValue"}, 
                values: new object[]
                {
                    (int) ConfigType.Configuration,
                    "Organization phone number",
                    null,
                    null,
                    null
                });
            
            migrationBuilder.InsertData(
                table: "Configurations", 
                columns: new[] {"ConfigType", "Description", "StringValue", "BoolValue", "IdValue"}, 
                values: new object[]
                {
                    (int) ConfigType.Configuration,
                    "Organization email address",
                    null,
                    null,
                    null
                });
            
            migrationBuilder.InsertData(
                table: "Configurations", 
                columns: new[] {"ConfigType", "Description", "StringValue", "BoolValue", "IdValue"}, 
                values: new object[]
                {
                    (int) ConfigType.Configuration,
                    "Predetermined Group to assign new Members",
                    null,
                    null,
                    null
                });
            
            migrationBuilder.InsertData(
                table: "Configurations", 
                columns: new[] {"ConfigType", "Description", "StringValue", "BoolValue", "IdValue"}, 
                values: new object[]
                {
                    (int) ConfigType.Configuration,
                    "Activate Comments on News",
                    null,
                    null,
                    null
                });
            
            migrationBuilder.InsertData(
                table: "Configurations", 
                columns: new[] {"ConfigType", "Description", "StringValue", "BoolValue", "IdValue"}, 
                values: new object[]
                {
                    (int) ConfigType.Configuration,
                    "Activate Administrator member ability to comment on News",
                    null,
                    null,
                    null
                });
            
            migrationBuilder.InsertData(
                table: "Configurations", 
                columns: new[] {"ConfigType", "Description", "StringValue", "BoolValue", "IdValue"}, 
                values: new object[]
                {
                    (int) ConfigType.Configuration,
                    "Activate Basic member ability to comment on News",
                    null,
                    null,
                    null
                });
            
            migrationBuilder.InsertData(
                table: "Configurations", 
                columns: new[] {"ConfigType", "Description", "StringValue", "BoolValue", "IdValue"}, 
                values: new object[]
                {
                    (int) ConfigType.Configuration,
                    "Activate ability for all members to create News",
                    null,
                    null,
                    null
                });

            // Page Setup
            
            migrationBuilder.InsertData(
                table: "Configurations", 
                columns: new[] {"ConfigType", "Description", "StringValue", "BoolValue", "IdValue"}, 
                values: new object[]
                {
                    (int) ConfigType.PageSetup,
                    "Frontpage",
                    null,
                    null,
                    null
                });
            
            migrationBuilder.InsertData(
                table: "Configurations", 
                columns: new[] {"ConfigType", "Description", "StringValue", "BoolValue", "IdValue"}, 
                values: new object[]
                {
                    (int) ConfigType.PageSetup,
                    "About Us",
                    null,
                    null,
                    null
                });
            
            migrationBuilder.InsertData(
                table: "Configurations", 
                columns: new[] {"ConfigType", "Description", "StringValue", "BoolValue", "IdValue"}, 
                values: new object[]
                {
                    (int) ConfigType.PageSetup,
                    "Contact",
                    null,
                    null,
                    null
                });
            
            migrationBuilder.InsertData(
                table: "Configurations", 
                columns: new[] {"ConfigType", "Description", "StringValue", "BoolValue", "IdValue"}, 
                values: new object[]
                {
                    (int) ConfigType.PageSetup,
                    "Create Membership",
                    null,
                    null,
                    null
                });
            
            // Css Setup
            
            migrationBuilder.InsertData(
                table: "Configurations", 
                columns: new[] {"ConfigType", "Description", "StringValue", "BoolValue", "IdValue"}, 
                values: new object[]
                {
                    (int) ConfigType.CssSetup,
                    "Member Application CSS",
                    null,
                    null,
                    null
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

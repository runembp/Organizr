

#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;
using Organizr.Domain.Enums;

namespace Organizr.Infrastructure.Migrations
{
    public partial class Addconfigurationstoconfigurationstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "ConfigType", "Description", "StringValue", "BoolValue", "IdValue" },
                values: new object[]
                {
                    (int) ConfigType.Configuration,
                    "Organization address",
                    null,
                    null,
                    null
                });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "ConfigType", "Description", "StringValue", "BoolValue", "IdValue" },
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
                columns: new[] { "ConfigType", "Description", "StringValue", "BoolValue", "IdValue" },
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
                columns: new[] { "ConfigType", "Description", "StringValue", "BoolValue", "IdValue" },
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
                columns: new[] { "ConfigType", "Description", "StringValue", "BoolValue", "IdValue" },
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
                columns: new[] { "ConfigType", "Description", "StringValue", "BoolValue", "IdValue" },
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
                columns: new[] { "ConfigType", "Description", "StringValue", "BoolValue", "IdValue" },
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
                columns: new[] { "ConfigType", "Description", "StringValue", "BoolValue", "IdValue" },
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
                columns: new[] { "ConfigType", "Description", "StringValue", "BoolValue", "IdValue" },
                values: new object[]
                {
                    (int) ConfigType.PageSetup,
                    "Frontpage - Top Text Box",
                    null,
                    null,
                    null
                });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "ConfigType", "Description", "StringValue", "BoolValue", "IdValue" },
                values: new object[]
                {
                    (int) ConfigType.PageSetup,
                    "Login - Forgotten Password Text",
                    null,
                    null,
                    null
                });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "ConfigType", "Description", "StringValue", "BoolValue", "IdValue" },
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
                columns: new[] { "ConfigType", "Description", "StringValue", "BoolValue", "IdValue" },
                values: new object[]
                {
                    (int) ConfigType.PageSetup,
                    "Contact - Top Text",
                    null,
                    null,
                    null
                });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "ConfigType", "Description", "StringValue", "BoolValue", "IdValue" },
                values: new object[]
                {
                    (int) ConfigType.PageSetup,
                    "Contact - Left Text Box",
                    null,
                    null,
                    null
                });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "ConfigType", "Description", "StringValue", "BoolValue", "IdValue" },
                values: new object[]
                {
                    (int) ConfigType.PageSetup,
                    "Create Membership Top Text",
                    null,
                    null,
                    null
                });

            // Css Setup

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "ConfigType", "Description", "StringValue", "BoolValue", "IdValue" },
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
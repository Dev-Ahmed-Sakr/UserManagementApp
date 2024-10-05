using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class addzipCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "UserIdentifier", "ZipCode" },
                values: new object[] { new Guid("db5bc421-2c2d-4ec9-8271-14bf4910ee86"), "12345" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "UserIdentifier", "ZipCode" },
                values: new object[] { new Guid("5bf5024a-cb4c-40d2-afa0-64ca74fe9054"), "12345" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "UserIdentifier",
                value: new Guid("fc8fc1bd-8b90-4a42-9bca-d77cf4424ba1"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "UserIdentifier",
                value: new Guid("27fde4ba-2687-47a5-a9b5-8d945eadfdd1"));
        }
    }
}

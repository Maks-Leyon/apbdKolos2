using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kolos2.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2000, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2001, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2002, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

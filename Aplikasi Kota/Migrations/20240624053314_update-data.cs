using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aplikasi_Kota.Migrations
{
    /// <inheritdoc />
    public partial class updatedata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Master_Kota",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Master_Kota",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Master_Kota",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Master_Kecamatan",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Master_Kecamatan",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Master_Kecamatan",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Master_Kecamatan",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsDeleted", "ModifiedBy", "ModifiedDate" },
                values: new object[] { false, 1, new DateTime(2024, 6, 24, 12, 33, 14, 281, DateTimeKind.Local).AddTicks(3102) });

            migrationBuilder.UpdateData(
                table: "Master_Kecamatan",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IsDeleted", "ModifiedBy", "ModifiedDate" },
                values: new object[] { false, 1, new DateTime(2024, 6, 24, 12, 33, 14, 281, DateTimeKind.Local).AddTicks(3104) });

            migrationBuilder.UpdateData(
                table: "Master_Kecamatan",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "IsDeleted", "ModifiedBy", "ModifiedDate" },
                values: new object[] { false, 1, new DateTime(2024, 6, 24, 12, 33, 14, 281, DateTimeKind.Local).AddTicks(3106) });

            migrationBuilder.UpdateData(
                table: "Master_Kecamatan",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "IsDeleted", "ModifiedBy", "ModifiedDate" },
                values: new object[] { false, 1, new DateTime(2024, 6, 24, 12, 33, 14, 281, DateTimeKind.Local).AddTicks(3107) });

            migrationBuilder.UpdateData(
                table: "Master_Kota",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsDeleted", "ModifiedBy", "ModifiedDate" },
                values: new object[] { false, 1, new DateTime(2024, 6, 24, 12, 33, 14, 281, DateTimeKind.Local).AddTicks(2580) });

            migrationBuilder.UpdateData(
                table: "Master_Kota",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IsDeleted", "ModifiedBy", "ModifiedDate" },
                values: new object[] { false, 1, new DateTime(2024, 6, 24, 12, 33, 14, 281, DateTimeKind.Local).AddTicks(2595) });

            migrationBuilder.UpdateData(
                table: "Master_Kota",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "IsDeleted", "ModifiedBy", "ModifiedDate" },
                values: new object[] { false, 1, new DateTime(2024, 6, 24, 12, 33, 14, 281, DateTimeKind.Local).AddTicks(2597) });

            migrationBuilder.UpdateData(
                table: "Master_Kota",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "IsDeleted", "ModifiedBy", "ModifiedDate" },
                values: new object[] { false, 1, new DateTime(2024, 6, 24, 12, 33, 14, 281, DateTimeKind.Local).AddTicks(2598) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Master_Kota");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Master_Kota");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Master_Kota");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Master_Kecamatan");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Master_Kecamatan");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Master_Kecamatan");
        }
    }
}

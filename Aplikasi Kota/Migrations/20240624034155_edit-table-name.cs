using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Aplikasi_Kota.Migrations
{
    /// <inheritdoc />
    public partial class edittablename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kecamatans_Master_Kota_IdKota",
                table: "Kecamatans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kecamatans",
                table: "Kecamatans");

            migrationBuilder.RenameTable(
                name: "Kecamatans",
                newName: "Master_Kecamatan");

            migrationBuilder.RenameIndex(
                name: "IX_Kecamatans_IdKota",
                table: "Master_Kecamatan",
                newName: "IX_Master_Kecamatan_IdKota");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Master_Kecamatan",
                table: "Master_Kecamatan",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Master_Kecamatan",
                columns: new[] { "Id", "IdKota", "KodeKecamatan", "NamaKecamatan" },
                values: new object[,]
                {
                    { 1, 1, "DPK", "Beji" },
                    { 2, 1, "BJS", "Bojongsari" },
                    { 3, 1, "CLD", "Cilodong" },
                    { 4, 1, "BJT", "Beji timur" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Master_Kecamatan_Master_Kota_IdKota",
                table: "Master_Kecamatan",
                column: "IdKota",
                principalTable: "Master_Kota",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Master_Kecamatan_Master_Kota_IdKota",
                table: "Master_Kecamatan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Master_Kecamatan",
                table: "Master_Kecamatan");

            migrationBuilder.DeleteData(
                table: "Master_Kecamatan",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Master_Kecamatan",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Master_Kecamatan",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Master_Kecamatan",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameTable(
                name: "Master_Kecamatan",
                newName: "Kecamatans");

            migrationBuilder.RenameIndex(
                name: "IX_Master_Kecamatan_IdKota",
                table: "Kecamatans",
                newName: "IX_Kecamatans_IdKota");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kecamatans",
                table: "Kecamatans",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kecamatans_Master_Kota_IdKota",
                table: "Kecamatans",
                column: "IdKota",
                principalTable: "Master_Kota",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

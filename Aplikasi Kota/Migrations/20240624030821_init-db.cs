using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Aplikasi_Kota.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Master_Kota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaKota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KodeKota = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Master_Kota", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kecamatans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaKecamatan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KodeKecamatan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdKota = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kecamatans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kecamatans_Master_Kota_IdKota",
                        column: x => x.IdKota,
                        principalTable: "Master_Kota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Master_Kota",
                columns: new[] { "Id", "KodeKota", "NamaKota" },
                values: new object[,]
                {
                    { 1, "DPK", "Depok" },
                    { 2, "DPK", "Jakarta Utara" },
                    { 3, "DPK", "Jakarta Selatan" },
                    { 4, "DPK", "Jakarta Barat" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kecamatans_IdKota",
                table: "Kecamatans",
                column: "IdKota");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kecamatans");

            migrationBuilder.DropTable(
                name: "Master_Kota");
        }
    }
}

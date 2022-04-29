using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transaksi.Data.Migrations
{
    public partial class addTableTransaksi1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransaksiBelanja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TanggalTransaksi = table.Column<DateTime>(type: "datetime2", nullable: false,defaultValueSql:"getdate()"),
                    IdProduk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransaksiBelanja", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransaksiBelanja");
        }
    }
}

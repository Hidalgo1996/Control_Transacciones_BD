using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Control_Transacciones_BD3.Migrations
{
    /// <inheritdoc />
    public partial class carlos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "genero_musical",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreGeneroMusical = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    fechaRegistro = table.Column<DateTime>(type: "date", nullable: true),
                    estado = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__genero_m__3213E83F6F3BDC0C", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "nacionalidad",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreNacionalidad = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    fechaRegistro = table.Column<DateTime>(type: "date", nullable: true),
                    estado = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__nacional__3213E83F6E0D322E", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "persona",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombres = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    apellidos = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    telefono = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    fechaNacimiento = table.Column<DateTime>(type: "date", nullable: true),
                    estado = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    idGeneroMusical = table.Column<int>(type: "int", nullable: true),
                    idNacionalidad = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__persona__3213E83F73C2931A", x => x.id);
                    table.ForeignKey(
                        name: "FK__persona__idGener__3B75D760",
                        column: x => x.idGeneroMusical,
                        principalTable: "genero_musical",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__persona__idNacio__3C69FB99",
                        column: x => x.idNacionalidad,
                        principalTable: "nacionalidad",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_persona_idGeneroMusical",
                table: "persona",
                column: "idGeneroMusical");

            migrationBuilder.CreateIndex(
                name: "IX_persona_idNacionalidad",
                table: "persona",
                column: "idNacionalidad");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "persona");

            migrationBuilder.DropTable(
                name: "genero_musical");

            migrationBuilder.DropTable(
                name: "nacionalidad");
        }
    }
}

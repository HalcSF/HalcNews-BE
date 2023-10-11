using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HalcNews.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FuenteId",
                table: "AppNoticas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AppAlerta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Busqueda = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    FechaEncontrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Leida = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppAlerta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppFuentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppFuentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppLectura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaLectura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoticiaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppLectura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppLectura_AppNoticas_NoticiaId",
                        column: x => x.NoticiaId,
                        principalTable: "AppNoticas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppNotificaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Texto = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlertaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppNotificaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppNotificaciones_AppAlerta_AlertaId",
                        column: x => x.AlertaId,
                        principalTable: "AppAlerta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppNoticas_FuenteId",
                table: "AppNoticas",
                column: "FuenteId");

            migrationBuilder.CreateIndex(
                name: "IX_AppLectura_NoticiaId",
                table: "AppLectura",
                column: "NoticiaId");

            migrationBuilder.CreateIndex(
                name: "IX_AppNotificaciones_AlertaId",
                table: "AppNotificaciones",
                column: "AlertaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppNoticas_AppFuentes_FuenteId",
                table: "AppNoticas",
                column: "FuenteId",
                principalTable: "AppFuentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppNoticas_AppFuentes_FuenteId",
                table: "AppNoticas");

            migrationBuilder.DropTable(
                name: "AppFuentes");

            migrationBuilder.DropTable(
                name: "AppLectura");

            migrationBuilder.DropTable(
                name: "AppNotificaciones");

            migrationBuilder.DropTable(
                name: "AppAlerta");

            migrationBuilder.DropIndex(
                name: "IX_AppNoticas_FuenteId",
                table: "AppNoticas");

            migrationBuilder.DropColumn(
                name: "FuenteId",
                table: "AppNoticas");
        }
    }
}

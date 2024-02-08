using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HalcNews.Migrations
{
    /// <inheritdoc />
    public partial class aaaaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppAlerts_AppFolders_FolderId",
                table: "AppAlerts");

            migrationBuilder.AlterColumn<int>(
                name: "FolderId",
                table: "AppAlerts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppAlerts_AppFolders_FolderId",
                table: "AppAlerts",
                column: "FolderId",
                principalTable: "AppFolders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppAlerts_AppFolders_FolderId",
                table: "AppAlerts");

            migrationBuilder.AlterColumn<int>(
                name: "FolderId",
                table: "AppAlerts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AppAlerts_AppFolders_FolderId",
                table: "AppAlerts",
                column: "FolderId",
                principalTable: "AppFolders",
                principalColumn: "Id");
        }
    }
}

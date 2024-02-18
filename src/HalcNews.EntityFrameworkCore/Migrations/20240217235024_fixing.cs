using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HalcNews.Migrations
{
    /// <inheritdoc />
    public partial class fixing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppNotifications_AppNews_NewId",
                table: "AppNotifications");

            migrationBuilder.AlterColumn<int>(
                name: "NewId",
                table: "AppNotifications",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UrlImage",
                table: "AppNews",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddForeignKey(
                name: "FK_AppNotifications_AppNews_NewId",
                table: "AppNotifications",
                column: "NewId",
                principalTable: "AppNews",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppNotifications_AppNews_NewId",
                table: "AppNotifications");

            migrationBuilder.AlterColumn<int>(
                name: "NewId",
                table: "AppNotifications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UrlImage",
                table: "AppNews",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppNotifications_AppNews_NewId",
                table: "AppNotifications",
                column: "NewId",
                principalTable: "AppNews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HalcNews.Migrations
{
    /// <inheritdoc />
    public partial class CRUDS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AppFolders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AppFolders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "AppFolders");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AppFolders");
        }
    }
}

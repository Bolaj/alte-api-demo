﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace alte_app.Migrations
{
    /// <inheritdoc />
    public partial class ProjectCards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Projects",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Projects",
                newName: "ProjectId");
        }
    }
}

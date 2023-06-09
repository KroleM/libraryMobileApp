using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryAPI.Migrations
{
    public partial class M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReaderBookScore",
                table: "ReaderBookScore");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ReaderBookScore",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ReaderBookScore",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ReaderBookScore",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "ReaderBookScore",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReaderBookScore",
                table: "ReaderBookScore",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ReaderBookScore_BookId",
                table: "ReaderBookScore",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReaderBookScore",
                table: "ReaderBookScore");

            migrationBuilder.DropIndex(
                name: "IX_ReaderBookScore_BookId",
                table: "ReaderBookScore");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ReaderBookScore");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ReaderBookScore");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ReaderBookScore");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "ReaderBookScore");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReaderBookScore",
                table: "ReaderBookScore",
                columns: new[] { "BookId", "ReaderId" });
        }
    }
}

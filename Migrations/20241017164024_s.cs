using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectLibrary.Migrations
{
    /// <inheritdoc />
    public partial class s : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MilitaryUnits_ContactPersons_ContactPersonId",
                table: "MilitaryUnits");

            migrationBuilder.DropIndex(
                name: "IX_MilitaryUnits_ContactPersonId",
                table: "MilitaryUnits");

            migrationBuilder.AlterColumn<Guid>(
                name: "ContactPersonId",
                table: "MilitaryUnits",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "MilitaryUnitId",
                table: "ContactPersons",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryUnits_ContactPersonId",
                table: "MilitaryUnits",
                column: "ContactPersonId",
                unique: true,
                filter: "[ContactPersonId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_MilitaryUnits_ContactPersons_ContactPersonId",
                table: "MilitaryUnits",
                column: "ContactPersonId",
                principalTable: "ContactPersons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MilitaryUnits_ContactPersons_ContactPersonId",
                table: "MilitaryUnits");

            migrationBuilder.DropIndex(
                name: "IX_MilitaryUnits_ContactPersonId",
                table: "MilitaryUnits");

            migrationBuilder.AlterColumn<Guid>(
                name: "ContactPersonId",
                table: "MilitaryUnits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MilitaryUnitId",
                table: "ContactPersons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryUnits_ContactPersonId",
                table: "MilitaryUnits",
                column: "ContactPersonId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MilitaryUnits_ContactPersons_ContactPersonId",
                table: "MilitaryUnits",
                column: "ContactPersonId",
                principalTable: "ContactPersons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

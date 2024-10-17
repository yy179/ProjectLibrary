using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectLibrary.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
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

            migrationBuilder.CreateIndex(
                name: "IX_ContactPersons_MilitaryUnitId",
                table: "ContactPersons",
                column: "MilitaryUnitId",
                unique: true,
                filter: "[MilitaryUnitId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactPersons_MilitaryUnits_MilitaryUnitId",
                table: "ContactPersons",
                column: "MilitaryUnitId",
                principalTable: "MilitaryUnits",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactPersons_MilitaryUnits_MilitaryUnitId",
                table: "ContactPersons");

            migrationBuilder.DropIndex(
                name: "IX_ContactPersons_MilitaryUnitId",
                table: "ContactPersons");

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
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace skibidi_gamebook.Server.Migrations
{
    /// <inheritdoc />
    public partial class updatecontrolers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achivements_Items_ItemIId",
                table: "Achivements");

            migrationBuilder.DropIndex(
                name: "IX_Achivements_ItemIId",
                table: "Achivements");

            migrationBuilder.RenameColumn(
                name: "ItemIId",
                table: "Achivements",
                newName: "ItemId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Connections",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Connections");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Achivements",
                newName: "ItemIId");

            migrationBuilder.CreateIndex(
                name: "IX_Achivements_ItemIId",
                table: "Achivements",
                column: "ItemIId");

            migrationBuilder.AddForeignKey(
                name: "FK_Achivements_Items_ItemIId",
                table: "Achivements",
                column: "ItemIId",
                principalTable: "Items",
                principalColumn: "IId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

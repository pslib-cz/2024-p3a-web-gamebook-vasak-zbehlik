using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace skibidi_gamebook.Server.Migrations
{
    /// <inheritdoc />
    public partial class maybe_fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Connections_Achivements_AchivementAId",
                table: "Connections");

            migrationBuilder.DropForeignKey(
                name: "FK_Connections_Items_ItemIId",
                table: "Connections");

            migrationBuilder.DropForeignKey(
                name: "FK_Connections_Rooms_RoomRId",
                table: "Connections");

            migrationBuilder.DropIndex(
                name: "IX_Connections_AchivementAId",
                table: "Connections");

            migrationBuilder.DropIndex(
                name: "IX_Connections_ItemIId",
                table: "Connections");

            migrationBuilder.DropIndex(
                name: "IX_Connections_RoomRId",
                table: "Connections");

            migrationBuilder.RenameColumn(
                name: "RoomRId",
                table: "Connections",
                newName: "RoomId");

            migrationBuilder.RenameColumn(
                name: "ItemIId",
                table: "Connections",
                newName: "ItemId");

            migrationBuilder.RenameColumn(
                name: "AchivementAId",
                table: "Connections",
                newName: "AchivementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Connections",
                newName: "RoomRId");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Connections",
                newName: "ItemIId");

            migrationBuilder.RenameColumn(
                name: "AchivementId",
                table: "Connections",
                newName: "AchivementAId");

            migrationBuilder.CreateIndex(
                name: "IX_Connections_AchivementAId",
                table: "Connections",
                column: "AchivementAId");

            migrationBuilder.CreateIndex(
                name: "IX_Connections_ItemIId",
                table: "Connections",
                column: "ItemIId");

            migrationBuilder.CreateIndex(
                name: "IX_Connections_RoomRId",
                table: "Connections",
                column: "RoomRId");

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_Achivements_AchivementAId",
                table: "Connections",
                column: "AchivementAId",
                principalTable: "Achivements",
                principalColumn: "AId");

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_Items_ItemIId",
                table: "Connections",
                column: "ItemIId",
                principalTable: "Items",
                principalColumn: "IId");

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_Rooms_RoomRId",
                table: "Connections",
                column: "RoomRId",
                principalTable: "Rooms",
                principalColumn: "RId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

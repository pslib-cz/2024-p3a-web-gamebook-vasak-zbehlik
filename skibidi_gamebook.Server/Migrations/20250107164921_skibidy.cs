using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace skibidi_gamebook.Server.Migrations
{
    /// <inheritdoc />
    public partial class skibidy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achivements_Items_ItemIId",
                table: "Achivements");

            migrationBuilder.DropForeignKey(
                name: "FK_Connections_Achivements_AchivementAId",
                table: "Connections");

            migrationBuilder.DropForeignKey(
                name: "FK_Connections_Items_ItemIId",
                table: "Connections");

            migrationBuilder.DropForeignKey(
                name: "FK_Connections_Rooms_RoomRId",
                table: "Connections");

            migrationBuilder.DropColumn(
                name: "AchivementAId",
                table: "Connections");

            migrationBuilder.DropColumn(
                name: "ItemIId",
                table: "Connections");

            migrationBuilder.DropColumn(
                name: "RoomRId",
                table: "Connections");

            migrationBuilder.DropColumn(
                name: "ItemIId",
                table: "Achivements");

            migrationBuilder.AddColumn<string>(
                name: "charImg",
                table: "Rooms",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "charName",
                table: "Rooms",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "chartext",
                table: "Rooms",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "charImg",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "charName",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "chartext",
                table: "Rooms");

            migrationBuilder.AddColumn<int>(
                name: "AchivementAId",
                table: "Connections",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemIId",
                table: "Connections",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomRId",
                table: "Connections",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemIId",
                table: "Achivements",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Achivements_Items_ItemIId",
                table: "Achivements",
                column: "ItemIId",
                principalTable: "Items",
                principalColumn: "IId",
                onDelete: ReferentialAction.Cascade);

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

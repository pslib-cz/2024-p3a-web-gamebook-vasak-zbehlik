using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace skibidi_gamebook.Server.Migrations
{
    /// <inheritdoc />
    public partial class qqdfgh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Connections_ItemId",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "Items",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateIndex(
                name: "IX_Connections_RequieremenId",
                table: "Connections",
                column: "RequieremenId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_Items_RequieremenId",
                table: "Connections",
                column: "RequieremenId",
                principalTable: "Items",
                principalColumn: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Connections_Items_RequieremenId",
                table: "Connections");

            migrationBuilder.DropIndex(
                name: "IX_Connections_RequieremenId",
                table: "Connections");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "Items",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Connections_ItemId",
                table: "Items",
                column: "ItemId",
                principalTable: "Connections",
                principalColumn: "ConnectionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

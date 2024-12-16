using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace skibidi_gamebook.Server.Migrations
{
    /// <inheritdoc />
    public partial class update_foreign_keys : Migration
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

            migrationBuilder.DropColumn(
                name: "IId",
                table: "Achivements");

            migrationBuilder.AlterColumn<string>(
                name: "Img",
                table: "Rooms",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Items",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "Lock",
                table: "Connections",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "ItemIId",
                table: "Connections",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "AchivementAId",
                table: "Connections",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Achivements",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Achivements",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Connections_Achivements_AchivementAId",
                table: "Connections");

            migrationBuilder.DropForeignKey(
                name: "FK_Connections_Items_ItemIId",
                table: "Connections");

            migrationBuilder.AlterColumn<string>(
                name: "Img",
                table: "Rooms",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Items",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Lock",
                table: "Connections",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ItemIId",
                table: "Connections",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AchivementAId",
                table: "Connections",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Achivements",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Achivements",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IId",
                table: "Achivements",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_Achivements_AchivementAId",
                table: "Connections",
                column: "AchivementAId",
                principalTable: "Achivements",
                principalColumn: "AId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_Items_ItemIId",
                table: "Connections",
                column: "ItemIId",
                principalTable: "Items",
                principalColumn: "IId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

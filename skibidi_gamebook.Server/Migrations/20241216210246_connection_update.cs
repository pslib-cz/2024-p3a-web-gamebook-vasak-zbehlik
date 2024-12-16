using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace skibidi_gamebook.Server.Migrations
{
    /// <inheritdoc />
    public partial class connection_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AId",
                table: "Connections");

            migrationBuilder.DropColumn(
                name: "IId",
                table: "Connections");

            migrationBuilder.DropColumn(
                name: "RId",
                table: "Connections");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AId",
                table: "Connections",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IId",
                table: "Connections",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RId",
                table: "Connections",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}

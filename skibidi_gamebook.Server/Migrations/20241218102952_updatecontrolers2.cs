using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace skibidi_gamebook.Server.Migrations
{
    /// <inheritdoc />
    public partial class updatecontrolers2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FromId",
                table: "Connections",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromId",
                table: "Connections");
        }
    }
}

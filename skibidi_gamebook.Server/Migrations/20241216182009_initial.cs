using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace skibidi_gamebook.Server.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    IId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Img = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.IId);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Img = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RId);
                });

            migrationBuilder.CreateTable(
                name: "Achivements",
                columns: table => new
                {
                    AId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ItemIId = table.Column<int>(type: "INTEGER", nullable: false),
                    IId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achivements", x => x.AId);
                    table.ForeignKey(
                        name: "FK_Achivements_Items_ItemIId",
                        column: x => x.ItemIId,
                        principalTable: "Items",
                        principalColumn: "IId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Connections",
                columns: table => new
                {
                    CId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoomRId = table.Column<int>(type: "INTEGER", nullable: false),
                    RId = table.Column<int>(type: "INTEGER", nullable: false),
                    Lock = table.Column<string>(type: "TEXT", nullable: false),
                    ItemIId = table.Column<int>(type: "INTEGER", nullable: false),
                    IId = table.Column<int>(type: "INTEGER", nullable: false),
                    AchivementAId = table.Column<int>(type: "INTEGER", nullable: false),
                    AId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connections", x => x.CId);
                    table.ForeignKey(
                        name: "FK_Connections_Achivements_AchivementAId",
                        column: x => x.AchivementAId,
                        principalTable: "Achivements",
                        principalColumn: "AId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Connections_Items_ItemIId",
                        column: x => x.ItemIId,
                        principalTable: "Items",
                        principalColumn: "IId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Connections_Rooms_RoomRId",
                        column: x => x.RoomRId,
                        principalTable: "Rooms",
                        principalColumn: "RId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Achivements_ItemIId",
                table: "Achivements",
                column: "ItemIId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Connections");

            migrationBuilder.DropTable(
                name: "Achivements");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}

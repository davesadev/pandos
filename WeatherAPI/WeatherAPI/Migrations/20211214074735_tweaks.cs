using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherAPI.Migrations
{
    public partial class tweaks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookID = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Title = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: true),
                    Genre = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: true),
                    ReadingLevel = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Author = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: true),
                    Publisher = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: true),
                    MultipleCopies = table.Column<byte>(type: "tinyint", nullable: true),
                    CheckedOutToID = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookID);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Genre = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Genre);
                });

            migrationBuilder.CreateTable(
                name: "ReadingLevel",
                columns: table => new
                {
                    ReadingLevel = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadingLevel", x => x.ReadingLevel);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    username = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    email = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    password = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "ReadingLevel");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

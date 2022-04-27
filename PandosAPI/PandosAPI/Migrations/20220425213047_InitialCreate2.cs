using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PandosAPI.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "uniprot",
                columns: table => new
                {
                    uniprot_id = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    accession_number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    entry_status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    sequence = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uniprot", x => x.uniprot_id);
                });

            migrationBuilder.CreateTable(
                name: "pdb",
                columns: table => new
                {
                    pdb_id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    uniprot_id = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pdb", x => x.pdb_id);
                    table.ForeignKey(
                        name: "FK_pdb_uniprot",
                        column: x => x.uniprot_id,
                        principalTable: "uniprot",
                        principalColumn: "uniprot_id");
                });

            migrationBuilder.CreateTable(
                name: "pdb_chain",
                columns: table => new
                {
                    pdb_id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    pdb_chain_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    uniprot_id = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    pdb_sequence = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    head_domain = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    hinge_domain = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    stalk_domain = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    neck_domain = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    transmembrane_domain = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    cytoplasmic_domain = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.pdb_id, x.pdb_chain_id });
                    table.ForeignKey(
                        name: "FK_pdb_chain_pdb",
                        column: x => x.pdb_id,
                        principalTable: "pdb",
                        principalColumn: "pdb_id");
                    table.ForeignKey(
                        name: "FK_pdb_chain_uniprot",
                        column: x => x.uniprot_id,
                        principalTable: "uniprot",
                        principalColumn: "uniprot_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_pdb_uniprot_id",
                table: "pdb",
                column: "uniprot_id");

            migrationBuilder.CreateIndex(
                name: "IX_pdb_chain_uniprot_id",
                table: "pdb_chain",
                column: "uniprot_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "__efmigrationshistory");

            migrationBuilder.DropTable(
                name: "pdb_chain");

            migrationBuilder.DropTable(
                name: "pdb");

            migrationBuilder.DropTable(
                name: "uniprot");
        }
    }
}

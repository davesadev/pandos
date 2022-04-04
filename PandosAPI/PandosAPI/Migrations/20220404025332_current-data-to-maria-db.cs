using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PandosAPI.Migrations
{
    public partial class currentdatatomariadb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "uniprot",
                columns: table => new
                {
                    uniprot_id = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    accession_number = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    entry_status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sequence = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uniprot", x => x.uniprot_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pdb",
                columns: table => new
                {
                    pdb_id = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    uniprot_id = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pdb", x => x.pdb_id);
                    table.ForeignKey(
                        name: "FK_pdb_uniprot",
                        column: x => x.uniprot_id,
                        principalTable: "uniprot",
                        principalColumn: "uniprot_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pdb_chain",
                columns: table => new
                {
                    pdb_id = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    pdb_chain_id = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    uniprot_id = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    pdb_sequence = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    head_domain = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    hinge_domain = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    stalk_domain = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    neck_domain = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    transmembrane_domain = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cytoplasmic_domain = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pdb_chain", x => new { x.pdb_id, x.pdb_chain_id });
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                name: "pdb_chain");

            migrationBuilder.DropTable(
                name: "pdb");

            migrationBuilder.DropTable(
                name: "uniprot");
        }
    }
}

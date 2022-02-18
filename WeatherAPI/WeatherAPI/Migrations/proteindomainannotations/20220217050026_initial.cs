using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherAPI.Migrations.proteindomainannotations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "uniprot",
                columns: table => new
                {
                    uniprot_id = table.Column<int>(type: "int", nullable: false),
                    accession_number = table.Column<int>(type: "int", nullable: true),
                    entry_status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    sequence = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uniprot", x => x.uniprot_id);
                });

            migrationBuilder.CreateTable(
                name: "pdb",
                columns: table => new
                {
                    pdb_id = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    uniprot_id = table.Column<int>(type: "int", nullable: false)
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
                    pdb_chain_id = table.Column<int>(type: "int", nullable: false),
                    pdb_id = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    chain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    pdb_sequence = table.Column<byte[]>(type: "varbinary(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pdb_chain", x => x.pdb_chain_id);
                    table.ForeignKey(
                        name: "FK_pdb_chain_pdb",
                        column: x => x.pdb_id,
                        principalTable: "pdb",
                        principalColumn: "pdb_id");
                });

            migrationBuilder.CreateTable(
                name: "pdb_chain_data",
                columns: table => new
                {
                    pdb_chain_data_id = table.Column<int>(type: "int", nullable: false),
                    pdb_chain_id = table.Column<int>(type: "int", nullable: true),
                    head_domain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    hinge_domain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    stalk_domain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    neck_domain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    transmembrane = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    cytoplasmic = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pdb_chain_data", x => x.pdb_chain_data_id);
                    table.ForeignKey(
                        name: "FK_pdb_chain_data_pdb_chain",
                        column: x => x.pdb_chain_id,
                        principalTable: "pdb_chain",
                        principalColumn: "pdb_chain_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_pdb_uniprot_id",
                table: "pdb",
                column: "uniprot_id");

            migrationBuilder.CreateIndex(
                name: "IX_pdb_chain_pdb_id",
                table: "pdb_chain",
                column: "pdb_id");

            migrationBuilder.CreateIndex(
                name: "IX_pdb_chain_data_pdb_chain_id",
                table: "pdb_chain_data",
                column: "pdb_chain_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pdb_chain_data");

            migrationBuilder.DropTable(
                name: "pdb_chain");

            migrationBuilder.DropTable(
                name: "pdb");

            migrationBuilder.DropTable(
                name: "uniprot");
        }
    }
}

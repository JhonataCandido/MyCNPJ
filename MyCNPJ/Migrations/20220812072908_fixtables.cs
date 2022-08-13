using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MyCNPJ.Migrations
{
    public partial class fixtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtividadePrincipal");

            migrationBuilder.DropTable(
                name: "AtividadesSecundaria");

            migrationBuilder.CreateTable(
                name: "AtividadesPrincipais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CnpjDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtividadesPrincipais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AtividadesPrincipais_CnpjData_CnpjDataId",
                        column: x => x.CnpjDataId,
                        principalTable: "CnpjData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AtividadesSecundarias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CnpjDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtividadesSecundarias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AtividadesSecundarias_CnpjData_CnpjDataId",
                        column: x => x.CnpjDataId,
                        principalTable: "CnpjData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtividadesPrincipais_CnpjDataId",
                table: "AtividadesPrincipais",
                column: "CnpjDataId");

            migrationBuilder.CreateIndex(
                name: "IX_AtividadesSecundarias_CnpjDataId",
                table: "AtividadesSecundarias",
                column: "CnpjDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtividadesPrincipais");

            migrationBuilder.DropTable(
                name: "AtividadesSecundarias");

            migrationBuilder.CreateTable(
                name: "AtividadePrincipal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CnpjDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtividadePrincipal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AtividadePrincipal_CnpjData_CnpjDataId",
                        column: x => x.CnpjDataId,
                        principalTable: "CnpjData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AtividadesSecundaria",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CnpjDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtividadesSecundaria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AtividadesSecundaria_CnpjData_CnpjDataId",
                        column: x => x.CnpjDataId,
                        principalTable: "CnpjData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtividadePrincipal_CnpjDataId",
                table: "AtividadePrincipal",
                column: "CnpjDataId");

            migrationBuilder.CreateIndex(
                name: "IX_AtividadesSecundaria_CnpjDataId",
                table: "AtividadesSecundaria",
                column: "CnpjDataId");
        }
    }
}

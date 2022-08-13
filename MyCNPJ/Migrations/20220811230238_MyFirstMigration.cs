using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MyCNPJ.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Billing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Free = table.Column<bool>(type: "bit", nullable: false),
                    Database = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billing", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CnpjData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Porte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fantasia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abertura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NaturezaJuridica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Municipio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Efr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Situacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataSituacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotivoSituacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SituacaoEspecial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataSituacaoEspecial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CapitalSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CnpjData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CnpjData_Billing_BillingId",
                        column: x => x.BillingId,
                        principalTable: "Billing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AtividadePrincipal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CnpjDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CnpjDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Qsa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaisOrigem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeRepLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QualRepLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CnpjDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qsa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Qsa_CnpjData_CnpjDataId",
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

            migrationBuilder.CreateIndex(
                name: "IX_CnpjData_BillingId",
                table: "CnpjData",
                column: "BillingId");

            migrationBuilder.CreateIndex(
                name: "IX_Qsa_CnpjDataId",
                table: "Qsa",
                column: "CnpjDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtividadePrincipal");

            migrationBuilder.DropTable(
                name: "AtividadesSecundaria");

            migrationBuilder.DropTable(
                name: "Qsa");

            migrationBuilder.DropTable(
                name: "CnpjData");

            migrationBuilder.DropTable(
                name: "Billing");
        }
    }
}

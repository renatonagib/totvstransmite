using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Workers.Migrations
{
    public partial class upd1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NFes",
                columns: table => new
                {
                    DocumentId = table.Column<string>(nullable: false),
                    EntidadeId = table.Column<string>(nullable: true),
                    Ambiente = table.Column<int>(nullable: false),
                    Modalidade = table.Column<int>(nullable: false),
                    Xml = table.Column<string>(nullable: true),
                    DataRecepcao = table.Column<DateTime>(nullable: false),
                    StatusDistribuicao = table.Column<int>(nullable: false),
                    CorrelationId = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NFes", x => x.DocumentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NFes");
        }
    }
}

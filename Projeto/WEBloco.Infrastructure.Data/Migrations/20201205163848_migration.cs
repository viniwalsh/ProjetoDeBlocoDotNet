using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WEBloco.Infrastructure.Data.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Heroi",
                columns: table => new
                {
                    HeroiId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Codinome = table.Column<string>(nullable: true),
                    Poder = table.Column<string>(nullable: true),
                    Lancamento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroi", x => x.HeroiId);
                });

            migrationBuilder.CreateTable(
                name: "Imagem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FotoUri = table.Column<string>(nullable: true),
                    HeroiId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Imagem_Heroi_HeroiId",
                        column: x => x.HeroiId,
                        principalTable: "Heroi",
                        principalColumn: "HeroiId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Imagem_HeroiId",
                table: "Imagem",
                column: "HeroiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Imagem");

            migrationBuilder.DropTable(
                name: "Heroi");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Champion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Funcao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Champion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkillsChampion",
                columns: table => new
                {
                    IdChampion = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Passiva = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skill_1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skill_2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skill_3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skill_4 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsChampion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillsChampion_Champion_IdChampion",
                        column: x => x.IdChampion,
                        principalTable: "Champion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkillsChampion_IdChampion",
                table: "SkillsChampion",
                column: "IdChampion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillsChampion");

            migrationBuilder.DropTable(
                name: "Champion");
        }
    }
}

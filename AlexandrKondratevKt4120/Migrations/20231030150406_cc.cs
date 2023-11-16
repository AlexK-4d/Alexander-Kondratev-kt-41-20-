using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AlexandrKondratevKt4120.Migrations
{
    /// <inheritdoc />
    public partial class cc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    discipline_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор дисциплины")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_discipline_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Наименование дисциплины"),
                    c_discipline_prepod = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Преподаватель дисциплины"),
                    c_discipline_nagruzka = table.Column<int>(type: "int4", maxLength: 100, nullable: false, comment: "Нагрузка дисциплины")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_(TableName)_DisciplineId", x => x.discipline_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Disciplines");
        }
    }
}

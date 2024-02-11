using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOV26.Portfolio.web.Migrations
{
    /// <inheritdoc />
    public partial class Resume : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResumeModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    START_YEAR = table.Column<int>(type: "INTEGER", nullable: false),
                    END_YEAR = table.Column<int>(type: "INTEGER", nullable: false),
                    TITLE = table.Column<string>(type: "TEXT", nullable: false),
                    INSTITUTION_NAME = table.Column<string>(type: "TEXT", nullable: false),
                    DESC = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeModel", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResumeModel");
        }
    }
}

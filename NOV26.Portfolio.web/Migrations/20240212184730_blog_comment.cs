using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOV26.Portfolio.web.Migrations
{
    /// <inheritdoc />
    public partial class blog_comment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogCommentModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: false),
                    DateOfComment = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BlogId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCommentModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogCommentModel_BlogModel_BlogId",
                        column: x => x.BlogId,
                        principalTable: "BlogModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogCommentModel_BlogId",
                table: "BlogCommentModel",
                column: "BlogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogCommentModel");
        }
    }
}

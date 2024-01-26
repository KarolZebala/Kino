using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kino.Infrastructure.Migrations
{
    public partial class AddMovieItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieItems",
                columns: table => new
                {
                    MovieItemId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<long>(type: "bigint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxViewers = table.Column<int>(type: "int", nullable: false),
                    BaseTicketPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ActualTicketPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurchaseTicketPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieItems", x => x.MovieItemId);
                    table.ForeignKey(
                        name: "FK_MovieItems_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieItems_MovieId",
                table: "MovieItems",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieItems");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kino.Infrastructure.Migrations
{
    public partial class AddGradeToMovieReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Grade",
                table: "MovieReview",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "MovieReview");
        }
    }
}

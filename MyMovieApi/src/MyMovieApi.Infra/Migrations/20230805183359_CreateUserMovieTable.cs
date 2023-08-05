using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMovieApi.Infra.Migrations
{
    public partial class CreateUserMovieTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_movies",
                columns: table => new
                {
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    movieId = table.Column<long>(type: "bigint", nullable: false),
                    userRating = table.Column<string>(type: "text", nullable: false),
                    watched = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pK_user_movies", x => new { x.userId, x.movieId });
                    table.ForeignKey(
                        name: "fK_user_movies_movies_movieId",
                        column: x => x.movieId,
                        principalTable: "movies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fK_user_movies_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "iX_user_movies_movieId",
                table: "user_movies",
                column: "movieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_movies");
        }
    }
}

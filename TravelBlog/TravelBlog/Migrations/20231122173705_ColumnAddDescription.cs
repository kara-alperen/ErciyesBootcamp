using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelBlog.Migrations
{
    /// <inheritdoc />
    public partial class ColumnAddDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTag_Posts_PostsPostID",
                table: "PostTag");

            migrationBuilder.RenameColumn(
                name: "PostsPostID",
                table: "PostTag",
                newName: "PostsPostId");

            migrationBuilder.RenameColumn(
                name: "PostID",
                table: "Posts",
                newName: "PostId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Posts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTag_Posts_PostsPostId",
                table: "PostTag",
                column: "PostsPostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTag_Posts_PostsPostId",
                table: "PostTag");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "PostsPostId",
                table: "PostTag",
                newName: "PostsPostID");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Posts",
                newName: "PostID");

            migrationBuilder.AddForeignKey(
                name: "FK_PostTag_Posts_PostsPostID",
                table: "PostTag",
                column: "PostsPostID",
                principalTable: "Posts",
                principalColumn: "PostID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

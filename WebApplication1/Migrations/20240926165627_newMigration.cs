using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class newMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPostTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "BlogPosts");

            migrationBuilder.RenameColumn(
                name: "Athor",
                table: "BlogPosts",
                newName: "Author");

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "BlogPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "TagId1",
                table: "BlogPosts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogPosts",
                table: "BlogPosts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_TagId1",
                table: "BlogPosts",
                column: "TagId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_Tags_TagId1",
                table: "BlogPosts",
                column: "TagId1",
                principalTable: "Tags",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_Tags_TagId1",
                table: "BlogPosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogPosts",
                table: "BlogPosts");

            migrationBuilder.DropIndex(
                name: "IX_BlogPosts_TagId1",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "TagId1",
                table: "BlogPosts");

            migrationBuilder.RenameTable(
                name: "BlogPosts",
                newName: "Posts");

            migrationBuilder.RenameColumn(
                name: "Author",
                table: "Posts",
                newName: "Athor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BlogPostTag",
                columns: table => new
                {
                    blogPostsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tagsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPostTag", x => new { x.blogPostsId, x.tagsId });
                    table.ForeignKey(
                        name: "FK_BlogPostTag_Posts_blogPostsId",
                        column: x => x.blogPostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogPostTag_Tags_tagsId",
                        column: x => x.tagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostTag_tagsId",
                table: "BlogPostTag",
                column: "tagsId");
        }
    }
}

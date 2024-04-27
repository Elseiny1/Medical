using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medical.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddPostTypeColumnToPostTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PostType",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostType",
                table: "Posts");
        }
    }
}

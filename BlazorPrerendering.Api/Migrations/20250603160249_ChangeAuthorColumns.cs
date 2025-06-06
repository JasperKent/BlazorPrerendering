using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorPrerendering.Api.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAuthorColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Authors",
                newName: "Surname");

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Authors");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Authors",
                newName: "LastName");
        }
    }
}

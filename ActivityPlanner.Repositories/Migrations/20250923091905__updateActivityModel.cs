using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActivityPlanner.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class _updateActivityModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActivityFullAddress",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivityFullAddress",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Activities");
        }
    }
}

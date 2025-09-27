using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActivityPlanner.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class _deleteIsActiveColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Activities");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Activities",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

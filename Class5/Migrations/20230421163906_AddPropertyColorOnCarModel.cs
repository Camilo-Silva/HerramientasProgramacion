using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Class5.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertyColorOnCarModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Car",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Car");
        }
    }
}

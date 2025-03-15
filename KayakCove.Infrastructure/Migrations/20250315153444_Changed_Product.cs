using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KayakCove.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Changed_Product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsInStock",
                table: "Products",
                newName: "HasExpired");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "HasExpired",
                table: "Products",
                newName: "IsInStock");
        }
    }
}

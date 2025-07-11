using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaundryManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Addarticlequantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Qauntity",
                table: "Article",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Qauntity",
                table: "Article");
        }
    }
}

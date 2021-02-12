using Microsoft.EntityFrameworkCore.Migrations;

namespace SnackHouse.Migrations
{
    public partial class FieldOrderItensQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderItensQuantity",
                table: "Orders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderItensQuantity",
                table: "Orders");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoListApp.Migrations
{
    public partial class AddFieldTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FieldTest",
                table: "TodoItems",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FieldTest",
                table: "TodoItems");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoListApp.Migrations
{
    public partial class RemoveSomeFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FieldTest",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "TodoItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FieldTest",
                table: "TodoItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "TodoItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

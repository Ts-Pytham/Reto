using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIReto.Migrations
{
    public partial class ChangeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Person",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Person",
                newName: "FullName");
        }
    }
}

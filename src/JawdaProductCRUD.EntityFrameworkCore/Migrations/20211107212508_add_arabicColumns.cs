using Microsoft.EntityFrameworkCore.Migrations;

namespace JawdaProductCRUD.Migrations
{
    public partial class add_arabicColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "title",
                table: "JawdaProduct",
                newName: "title_en");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "JawdaProduct",
                newName: "title_ar");

            migrationBuilder.AddColumn<string>(
                name: "description_ar",
                table: "JawdaProduct",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description_en",
                table: "JawdaProduct",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description_ar",
                table: "JawdaProduct");

            migrationBuilder.DropColumn(
                name: "description_en",
                table: "JawdaProduct");

            migrationBuilder.RenameColumn(
                name: "title_en",
                table: "JawdaProduct",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "title_ar",
                table: "JawdaProduct",
                newName: "description");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingAPI.Migrations
{
    /// <inheritdoc />
    public partial class mig7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HomeSliders",
                schema: "Shop",
                table: "HomeSliders");

            migrationBuilder.RenameTable(
                name: "HomeSliders",
                schema: "Shop",
                newName: "TopSliders",
                newSchema: "Shop");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Shop",
                table: "TopSliders",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TopSliders",
                schema: "Shop",
                table: "TopSliders",
                column: "SliderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TopSliders",
                schema: "Shop",
                table: "TopSliders");

            migrationBuilder.RenameTable(
                name: "TopSliders",
                schema: "Shop",
                newName: "HomeSliders",
                newSchema: "Shop");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Shop",
                table: "HomeSliders",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomeSliders",
                schema: "Shop",
                table: "HomeSliders",
                column: "SliderId");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingAPI.Migrations
{
    /// <inheritdoc />
    public partial class mig10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SliderGroupId",
                schema: "Shop",
                table: "TopSliders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TopSliders_SliderGroupId",
                schema: "Shop",
                table: "TopSliders",
                column: "SliderGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_TopSliders_SliderGroups_SliderGroupId",
                schema: "Shop",
                table: "TopSliders",
                column: "SliderGroupId",
                principalSchema: "Shop",
                principalTable: "SliderGroups",
                principalColumn: "SliderGroupId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TopSliders_SliderGroups_SliderGroupId",
                schema: "Shop",
                table: "TopSliders");

            migrationBuilder.DropIndex(
                name: "IX_TopSliders_SliderGroupId",
                schema: "Shop",
                table: "TopSliders");

            migrationBuilder.DropColumn(
                name: "SliderGroupId",
                schema: "Shop",
                table: "TopSliders");
        }
    }
}

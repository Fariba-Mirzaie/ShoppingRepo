using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingAPI.Migrations
{
    /// <inheritdoc />
    public partial class mig16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Slider3Id",
                schema: "Shop",
                table: "SliderGroups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "slider3s",
                schema: "Shop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_slider3s", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SliderGroups_Slider3Id",
                schema: "Shop",
                table: "SliderGroups",
                column: "Slider3Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SliderGroups_slider3s_Slider3Id",
                schema: "Shop",
                table: "SliderGroups",
                column: "Slider3Id",
                principalSchema: "Shop",
                principalTable: "slider3s",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SliderGroups_slider3s_Slider3Id",
                schema: "Shop",
                table: "SliderGroups");

            migrationBuilder.DropTable(
                name: "slider3s",
                schema: "Shop");

            migrationBuilder.DropIndex(
                name: "IX_SliderGroups_Slider3Id",
                schema: "Shop",
                table: "SliderGroups");

            migrationBuilder.DropColumn(
                name: "Slider3Id",
                schema: "Shop",
                table: "SliderGroups");
        }
    }
}

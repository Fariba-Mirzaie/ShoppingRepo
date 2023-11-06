using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingAPI.Migrations
{
    /// <inheritdoc />
    public partial class mig18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TopSliders_SliderGroups_SliderGroupId",
                schema: "Shop",
                table: "TopSliders");

            migrationBuilder.AlterColumn<int>(
                name: "SliderGroupId",
                schema: "Shop",
                table: "TopSliders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "SliderGallery",
                schema: "Shop",
                columns: table => new
                {
                    SliderGalleryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SliderGallery", x => x.SliderGalleryId);
                });

            migrationBuilder.CreateTable(
                name: "SliderGallerySliderGroup",
                schema: "Shop",
                columns: table => new
                {
                    GallerySliderGalleryId = table.Column<int>(type: "int", nullable: false),
                    GroupsSliderGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SliderGallerySliderGroup", x => new { x.GallerySliderGalleryId, x.GroupsSliderGroupId });
                    table.ForeignKey(
                        name: "FK_SliderGallerySliderGroup_SliderGallery_GallerySliderGalleryId",
                        column: x => x.GallerySliderGalleryId,
                        principalSchema: "Shop",
                        principalTable: "SliderGallery",
                        principalColumn: "SliderGalleryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SliderGallerySliderGroup_SliderGroups_GroupsSliderGroupId",
                        column: x => x.GroupsSliderGroupId,
                        principalSchema: "Shop",
                        principalTable: "SliderGroups",
                        principalColumn: "SliderGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SliderGallerySliderGroup_GroupsSliderGroupId",
                schema: "Shop",
                table: "SliderGallerySliderGroup",
                column: "GroupsSliderGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_TopSliders_SliderGroups_SliderGroupId",
                schema: "Shop",
                table: "TopSliders",
                column: "SliderGroupId",
                principalSchema: "Shop",
                principalTable: "SliderGroups",
                principalColumn: "SliderGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TopSliders_SliderGroups_SliderGroupId",
                schema: "Shop",
                table: "TopSliders");

            migrationBuilder.DropTable(
                name: "SliderGallerySliderGroup",
                schema: "Shop");

            migrationBuilder.DropTable(
                name: "SliderGallery",
                schema: "Shop");

            migrationBuilder.AlterColumn<int>(
                name: "SliderGroupId",
                schema: "Shop",
                table: "TopSliders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}

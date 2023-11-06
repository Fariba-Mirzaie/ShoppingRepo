using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingAPI.Migrations
{
    /// <inheritdoc />
    public partial class mig19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SliderGallerySliderGroup_SliderGallery_GallerySliderGalleryId",
                schema: "Shop",
                table: "SliderGallerySliderGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SliderGallery",
                schema: "Shop",
                table: "SliderGallery");

            migrationBuilder.RenameTable(
                name: "SliderGallery",
                schema: "Shop",
                newName: "SliderGallerys",
                newSchema: "Shop");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SliderGallerys",
                schema: "Shop",
                table: "SliderGallerys",
                column: "SliderGalleryId");

            migrationBuilder.AddForeignKey(
                name: "FK_SliderGallerySliderGroup_SliderGallerys_GallerySliderGalleryId",
                schema: "Shop",
                table: "SliderGallerySliderGroup",
                column: "GallerySliderGalleryId",
                principalSchema: "Shop",
                principalTable: "SliderGallerys",
                principalColumn: "SliderGalleryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SliderGallerySliderGroup_SliderGallerys_GallerySliderGalleryId",
                schema: "Shop",
                table: "SliderGallerySliderGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SliderGallerys",
                schema: "Shop",
                table: "SliderGallerys");

            migrationBuilder.RenameTable(
                name: "SliderGallerys",
                schema: "Shop",
                newName: "SliderGallery",
                newSchema: "Shop");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SliderGallery",
                schema: "Shop",
                table: "SliderGallery",
                column: "SliderGalleryId");

            migrationBuilder.AddForeignKey(
                name: "FK_SliderGallerySliderGroup_SliderGallery_GallerySliderGalleryId",
                schema: "Shop",
                table: "SliderGallerySliderGroup",
                column: "GallerySliderGalleryId",
                principalSchema: "Shop",
                principalTable: "SliderGallery",
                principalColumn: "SliderGalleryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

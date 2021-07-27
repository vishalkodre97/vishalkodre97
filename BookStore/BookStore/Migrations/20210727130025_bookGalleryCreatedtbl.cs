using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class bookGalleryCreatedtbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookImageGallery_Books_BooksId",
                table: "BookImageGallery");

            migrationBuilder.DropIndex(
                name: "IX_BookImageGallery_BooksId",
                table: "BookImageGallery");

            migrationBuilder.DropColumn(
                name: "BooksId",
                table: "BookImageGallery");

            migrationBuilder.CreateIndex(
                name: "IX_BookImageGallery_BookId",
                table: "BookImageGallery",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookImageGallery_Books_BookId",
                table: "BookImageGallery",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookImageGallery_Books_BookId",
                table: "BookImageGallery");

            migrationBuilder.DropIndex(
                name: "IX_BookImageGallery_BookId",
                table: "BookImageGallery");

            migrationBuilder.AddColumn<int>(
                name: "BooksId",
                table: "BookImageGallery",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookImageGallery_BooksId",
                table: "BookImageGallery",
                column: "BooksId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookImageGallery_Books_BooksId",
                table: "BookImageGallery",
                column: "BooksId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

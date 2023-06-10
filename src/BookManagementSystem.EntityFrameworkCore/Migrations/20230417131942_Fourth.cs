using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookManagementSystem.Migrations
{
    public partial class Fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookHistories_BookAuthors_BookAuthorId",
                table: "BookHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_BookHistories_EBookAuthors_EBookAuthorId",
                table: "BookHistories");

            migrationBuilder.DropIndex(
                name: "IX_BookHistories_BookAuthorId",
                table: "BookHistories");

            migrationBuilder.DropColumn(
                name: "BookAuthorId",
                table: "BookHistories");

            migrationBuilder.RenameColumn(
                name: "EBookAuthorId",
                table: "BookHistories",
                newName: "EBookId");

            migrationBuilder.RenameIndex(
                name: "IX_BookHistories_EBookAuthorId",
                table: "BookHistories",
                newName: "IX_BookHistories_EBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookHistories_EBooks_EBookId",
                table: "BookHistories",
                column: "EBookId",
                principalTable: "EBooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookHistories_EBooks_EBookId",
                table: "BookHistories");

            migrationBuilder.RenameColumn(
                name: "EBookId",
                table: "BookHistories",
                newName: "EBookAuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_BookHistories_EBookId",
                table: "BookHistories",
                newName: "IX_BookHistories_EBookAuthorId");

            migrationBuilder.AddColumn<int>(
                name: "BookAuthorId",
                table: "BookHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookHistories_BookAuthorId",
                table: "BookHistories",
                column: "BookAuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookHistories_BookAuthors_BookAuthorId",
                table: "BookHistories",
                column: "BookAuthorId",
                principalTable: "BookAuthors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookHistories_EBookAuthors_EBookAuthorId",
                table: "BookHistories",
                column: "EBookAuthorId",
                principalTable: "EBookAuthors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

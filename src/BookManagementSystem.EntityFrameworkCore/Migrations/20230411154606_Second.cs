using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookManagementSystem.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookHistories_AbpUsers_UserId",
                table: "BookHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_BookHistories_BookAuthors_BookAuthorID",
                table: "BookHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_BookHistories_EBookAuthors_EBookAuthorID",
                table: "BookHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Books_BookId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Books_EBookId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "BookName",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "EBookName",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "BookHistories");

            migrationBuilder.RenameColumn(
                name: "EBookAuthorID",
                table: "BookHistories",
                newName: "EBookAuthorId");

            migrationBuilder.RenameColumn(
                name: "BookAuthorID",
                table: "BookHistories",
                newName: "BookAuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_BookHistories_EBookAuthorID",
                table: "BookHistories",
                newName: "IX_BookHistories_EBookAuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_BookHistories_BookAuthorID",
                table: "BookHistories",
                newName: "IX_BookHistories_BookAuthorId");

            migrationBuilder.AlterColumn<int>(
                name: "EBookId",
                table: "Feedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "Feedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "BookHistories",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookHistories_AbpUsers_UserId",
                table: "BookHistories",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Books_BookId",
                table: "Feedbacks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Books_EBookId",
                table: "Feedbacks",
                column: "EBookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookHistories_AbpUsers_UserId",
                table: "BookHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_BookHistories_BookAuthors_BookAuthorId",
                table: "BookHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_BookHistories_EBookAuthors_EBookAuthorId",
                table: "BookHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Books_BookId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Books_EBookId",
                table: "Feedbacks");

            migrationBuilder.RenameColumn(
                name: "EBookAuthorId",
                table: "BookHistories",
                newName: "EBookAuthorID");

            migrationBuilder.RenameColumn(
                name: "BookAuthorId",
                table: "BookHistories",
                newName: "BookAuthorID");

            migrationBuilder.RenameIndex(
                name: "IX_BookHistories_EBookAuthorId",
                table: "BookHistories",
                newName: "IX_BookHistories_EBookAuthorID");

            migrationBuilder.RenameIndex(
                name: "IX_BookHistories_BookAuthorId",
                table: "BookHistories",
                newName: "IX_BookHistories_BookAuthorID");

            migrationBuilder.AlterColumn<int>(
                name: "EBookId",
                table: "Feedbacks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "Feedbacks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "BookName",
                table: "Feedbacks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EBookName",
                table: "Feedbacks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "BookHistories",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "BookHistories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookHistories_AbpUsers_UserId",
                table: "BookHistories",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookHistories_BookAuthors_BookAuthorID",
                table: "BookHistories",
                column: "BookAuthorID",
                principalTable: "BookAuthors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookHistories_EBookAuthors_EBookAuthorID",
                table: "BookHistories",
                column: "EBookAuthorID",
                principalTable: "EBookAuthors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Books_BookId",
                table: "Feedbacks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Books_EBookId",
                table: "Feedbacks",
                column: "EBookId",
                principalTable: "Books",
                principalColumn: "Id");
        }
    }
}

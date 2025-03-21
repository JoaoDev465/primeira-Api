using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootboolVlog.Migrations
{
    /// <inheritdoc />
    public partial class Refresh10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Categorie_PostId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_PostId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Post");

            migrationBuilder.AddColumn<int>(
                name: "CategorieId",
                table: "Post",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "Categorie",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Post_CategorieId",
                table: "Post",
                column: "CategorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Categorie_CategorieId",
                table: "Post",
                column: "CategorieId",
                principalTable: "Categorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Categorie_CategorieId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_CategorieId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "CategorieId",
                table: "Post");

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "Categorie",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_PostId",
                table: "Post",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Categorie_PostId",
                table: "Post",
                column: "PostId",
                principalTable: "Categorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

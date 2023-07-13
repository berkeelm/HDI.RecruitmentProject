using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations.Application
{
    /// <inheritdoc />
    public partial class ReferenceFix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_User_CreatedUserId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_User_UpdatedUserId",
                table: "Product");

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedUserId",
                table: "Product",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedUserId",
                table: "Product",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_User_CreatedUserId",
                table: "Product",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_User_UpdatedUserId",
                table: "Product",
                column: "UpdatedUserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_User_CreatedUserId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_User_UpdatedUserId",
                table: "Product");

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedUserId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedUserId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_User_CreatedUserId",
                table: "Product",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_User_UpdatedUserId",
                table: "Product",
                column: "UpdatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

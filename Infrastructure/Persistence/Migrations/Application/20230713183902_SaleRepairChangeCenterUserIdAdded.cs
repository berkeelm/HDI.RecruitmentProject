using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations.Application
{
    /// <inheritdoc />
    public partial class SaleRepairChangeCenterUserIdAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RepairChangeCenterUserId",
                table: "Sale",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sale_RepairChangeCenterUserId",
                table: "Sale",
                column: "RepairChangeCenterUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_User_RepairChangeCenterUserId",
                table: "Sale",
                column: "RepairChangeCenterUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_User_RepairChangeCenterUserId",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Sale_RepairChangeCenterUserId",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "RepairChangeCenterUserId",
                table: "Sale");
        }
    }
}

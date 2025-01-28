using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Migrations
{
    /// <inheritdoc />
    public partial class AddToUserIdToTransfers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transfer_AspNetUsers_AppUserId",
                table: "Transfer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transfer",
                table: "Transfer");

            migrationBuilder.DropColumn(
                name: "ToWalletId",
                table: "Transfer");

            migrationBuilder.RenameTable(
                name: "Transfer",
                newName: "Transfers");

            migrationBuilder.RenameColumn(
                name: "ToUsername",
                table: "Transfers",
                newName: "ToUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Transfer_AppUserId",
                table: "Transfers",
                newName: "IX_Transfers_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transfers",
                table: "Transfers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_AspNetUsers_AppUserId",
                table: "Transfers",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_AspNetUsers_AppUserId",
                table: "Transfers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transfers",
                table: "Transfers");

            migrationBuilder.RenameTable(
                name: "Transfers",
                newName: "Transfer");

            migrationBuilder.RenameColumn(
                name: "ToUserId",
                table: "Transfer",
                newName: "ToUsername");

            migrationBuilder.RenameIndex(
                name: "IX_Transfers_AppUserId",
                table: "Transfer",
                newName: "IX_Transfer_AppUserId");

            migrationBuilder.AddColumn<int>(
                name: "ToWalletId",
                table: "Transfer",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transfer",
                table: "Transfer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transfer_AspNetUsers_AppUserId",
                table: "Transfer",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

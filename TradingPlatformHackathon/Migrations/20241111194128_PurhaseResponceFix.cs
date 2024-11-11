using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradingPlatformHackathon.Migrations
{
    /// <inheritdoc />
    public partial class PurhaseResponceFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseResponse_PurchaseRequests_PurchaseRequestId",
                table: "PurchaseResponse");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseResponse_Users_SupplierId",
                table: "PurchaseResponse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseResponse",
                table: "PurchaseResponse");

            migrationBuilder.RenameTable(
                name: "PurchaseResponse",
                newName: "PurchaseResponses");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseResponse_SupplierId",
                table: "PurchaseResponses",
                newName: "IX_PurchaseResponses_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseResponse_PurchaseRequestId",
                table: "PurchaseResponses",
                newName: "IX_PurchaseResponses_PurchaseRequestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseResponses",
                table: "PurchaseResponses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseResponses_PurchaseRequests_PurchaseRequestId",
                table: "PurchaseResponses",
                column: "PurchaseRequestId",
                principalTable: "PurchaseRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseResponses_Users_SupplierId",
                table: "PurchaseResponses",
                column: "SupplierId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseResponses_PurchaseRequests_PurchaseRequestId",
                table: "PurchaseResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseResponses_Users_SupplierId",
                table: "PurchaseResponses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseResponses",
                table: "PurchaseResponses");

            migrationBuilder.RenameTable(
                name: "PurchaseResponses",
                newName: "PurchaseResponse");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseResponses_SupplierId",
                table: "PurchaseResponse",
                newName: "IX_PurchaseResponse_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseResponses_PurchaseRequestId",
                table: "PurchaseResponse",
                newName: "IX_PurchaseResponse_PurchaseRequestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseResponse",
                table: "PurchaseResponse",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseResponse_PurchaseRequests_PurchaseRequestId",
                table: "PurchaseResponse",
                column: "PurchaseRequestId",
                principalTable: "PurchaseRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseResponse_Users_SupplierId",
                table: "PurchaseResponse",
                column: "SupplierId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

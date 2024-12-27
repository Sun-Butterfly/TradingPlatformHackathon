using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradingPlatformHackathon.Migrations
{
    /// <inheritdoc />
    public partial class addMessageIsReadFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsRead",
                table: "Messages",
                type: "boolean",
                nullable: false,
                defaultValueSql: "false",
                oldClrType: typeof(bool),
                oldType: "boolean");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsRead",
                table: "Messages",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValueSql: "false");
        }
    }
}

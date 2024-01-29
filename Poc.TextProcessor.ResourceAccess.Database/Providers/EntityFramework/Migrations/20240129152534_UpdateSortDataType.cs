using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Poc.TextProcessor.ResourceAccess.Database.Providers.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSortDataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Option",
                table: "TextSorts",
                type: "nvarchar(24)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Option",
                table: "TextSorts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(24)");
        }
    }
}

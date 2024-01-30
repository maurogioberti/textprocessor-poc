using Microsoft.EntityFrameworkCore.Migrations;
using Poc.TextProcessor.CrossCutting.Enums;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Poc.TextProcessor.ResourceAccess.Database.Providers.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddTextDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var enumValues = Enum.GetValues(typeof(SortOption)).Cast<SortOption>().Where(x => x != 0);
            var enumValuesCount = enumValues.Count();
            var enumValuesMatrix = new object[enumValuesCount, 2];

            var row = 0;
            foreach (var option in enumValues)
            {
                enumValuesMatrix[row, 0] = (int)option;
                enumValuesMatrix[row, 1] = option.ToString();
                row++;
            }

            migrationBuilder.InsertData(
                table: "TextSorts",
                columns: new[] { "Id", "Option" },
                values: enumValuesMatrix
            );

            migrationBuilder.InsertData(
                table: "Texts",
                columns: new[] { "Id", "Content" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." },
                    { 2, "Parmesan mascarpone cheese on toast. Manchego cheese strings goat rubber cheese cheese and biscuits cheese on toast boursin jarlsberg. Macaroni cheese when the cheese comes out everybody's happy cauliflower cheese cheddar cow taleggio queso bavarian bergkase. Edam parmesan queso ricotta babybel cow who moved my cheese cheese triangles. Everyone loves." },
                    { 3, "Pudding topping candy biscuit halvah apple pie chocolate. Tootsie roll tootsie roll sugar plum dessert bear claw cake. Jelly-o gummi bears cake jelly beans macaroon tart jelly. Pie powder macaroon pie sweet gummies cupcake. Wafer dragée chupa chups lollipop carrot cake candy. Ice cream halvah pie tootsie roll donut jelly beans. Tootsie roll lemon drops lemon drops oat cake candy. Marzipan gummies marshmallow tart soufflé muffin." },
                    { 4, "They're late. My experiment worked. They're all exactly twenty-five minutes slow. Nothing, nothing, nothing, look tell her destiny has brought you together, tell her that she's the most beautiful you have ever seen. Girls like that stuff. What, what are you doing George? Can I go now, Mr. Strickland? It works, ha ha ha ha, it works. I finally invent something that works. Oh." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TextSorts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TextSorts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TextSorts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Texts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Texts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Texts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Texts",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}

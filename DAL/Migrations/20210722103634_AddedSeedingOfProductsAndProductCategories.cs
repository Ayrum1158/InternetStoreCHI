using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddedSeedingOfProductsAndProductCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_CategoryId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Smartphone" },
                    { 2, "TV" },
                    { 3, "Tool" },
                    { 4, "Headphones" },
                    { 5, "Food" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHashed",
                value: "2rxmwCFIbkMfOyK51XDoMWdRQptnY3epAxNhJiWS4SYF+qIv");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 3, 1, "Smartphone", "Smartphone - 2", 2153m },
                    { 47, 4, "Headphones", "Headphones - 46", 4486m },
                    { 45, 4, "Headphones", "Headphones - 44", 4307m },
                    { 38, 4, "Headphones", "Headphones - 37", 1479m },
                    { 37, 4, "Headphones", "Headphones - 36", 1062m },
                    { 35, 4, "Headphones", "Headphones - 34", 4923m },
                    { 29, 4, "Headphones", "Headphones - 28", 2387m },
                    { 26, 4, "Headphones", "Headphones - 25", 3469m },
                    { 6, 4, "Headphones", "Headphones - 5", 4754m },
                    { 5, 4, "Headphones", "Headphones - 4", 146m },
                    { 4, 4, "Headphones", "Headphones - 3", 2245m },
                    { 100, 3, "Tool", "Tool - 99", 3995m },
                    { 91, 3, "Tool", "Tool - 90", 1921m },
                    { 89, 3, "Tool", "Tool - 88", 1313m },
                    { 88, 3, "Tool", "Tool - 87", 3340m },
                    { 80, 3, "Tool", "Tool - 79", 3659m },
                    { 74, 3, "Tool", "Tool - 73", 2701m },
                    { 67, 3, "Tool", "Tool - 66", 27m },
                    { 65, 3, "Tool", "Tool - 64", 4694m },
                    { 64, 3, "Tool", "Tool - 63", 4083m },
                    { 57, 3, "Tool", "Tool - 56", 3505m },
                    { 55, 3, "Tool", "Tool - 54", 4080m },
                    { 49, 4, "Headphones", "Headphones - 48", 3758m },
                    { 53, 3, "Tool", "Tool - 52", 3026m },
                    { 50, 4, "Headphones", "Headphones - 49", 4131m },
                    { 58, 4, "Headphones", "Headphones - 57", 930m },
                    { 51, 5, "Food", "Food - 50", 1294m },
                    { 43, 5, "Food", "Food - 42", 4259m },
                    { 42, 5, "Food", "Food - 41", 1567m },
                    { 41, 5, "Food", "Food - 40", 3815m },
                    { 32, 5, "Food", "Food - 31", 1176m },
                    { 15, 5, "Food", "Food - 14", 2065m },
                    { 14, 5, "Food", "Food - 13", 2225m },
                    { 12, 5, "Food", "Food - 11", 2904m },
                    { 10, 5, "Food", "Food - 9", 144m },
                    { 2, 5, "Food", "Food - 1", 4072m },
                    { 99, 4, "Headphones", "Headphones - 98", 3186m },
                    { 95, 4, "Headphones", "Headphones - 94", 2350m },
                    { 92, 4, "Headphones", "Headphones - 91", 4219m },
                    { 90, 4, "Headphones", "Headphones - 89", 1932m },
                    { 86, 4, "Headphones", "Headphones - 85", 4687m },
                    { 84, 4, "Headphones", "Headphones - 83", 2343m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 81, 4, "Headphones", "Headphones - 80", 3070m },
                    { 78, 4, "Headphones", "Headphones - 77", 4948m },
                    { 68, 4, "Headphones", "Headphones - 67", 4244m },
                    { 62, 4, "Headphones", "Headphones - 61", 3806m },
                    { 60, 4, "Headphones", "Headphones - 59", 764m },
                    { 56, 4, "Headphones", "Headphones - 55", 2084m },
                    { 48, 3, "Tool", "Tool - 47", 874m },
                    { 34, 3, "Tool", "Tool - 33", 1307m },
                    { 22, 3, "Tool", "Tool - 21", 1024m },
                    { 98, 1, "Smartphone", "Smartphone - 97", 4263m },
                    { 96, 1, "Smartphone", "Smartphone - 95", 4097m },
                    { 94, 1, "Smartphone", "Smartphone - 93", 4069m },
                    { 85, 1, "Smartphone", "Smartphone - 84", 3728m },
                    { 79, 1, "Smartphone", "Smartphone - 78", 95m },
                    { 76, 1, "Smartphone", "Smartphone - 75", 1155m },
                    { 75, 1, "Smartphone", "Smartphone - 74", 3263m },
                    { 72, 1, "Smartphone", "Smartphone - 71", 1574m },
                    { 71, 1, "Smartphone", "Smartphone - 70", 3856m },
                    { 69, 1, "Smartphone", "Smartphone - 68", 1389m },
                    { 52, 1, "Smartphone", "Smartphone - 51", 3932m },
                    { 39, 1, "Smartphone", "Smartphone - 38", 746m },
                    { 36, 1, "Smartphone", "Smartphone - 35", 1339m },
                    { 33, 1, "Smartphone", "Smartphone - 32", 1969m },
                    { 27, 1, "Smartphone", "Smartphone - 26", 3052m },
                    { 25, 1, "Smartphone", "Smartphone - 24", 2491m },
                    { 24, 1, "Smartphone", "Smartphone - 23", 315m },
                    { 19, 1, "Smartphone", "Smartphone - 18", 2666m },
                    { 16, 1, "Smartphone", "Smartphone - 15", 831m },
                    { 11, 1, "Smartphone", "Smartphone - 10", 1488m },
                    { 7, 1, "Smartphone", "Smartphone - 6", 1230m },
                    { 8, 2, "TV", "TV - 7", 496m },
                    { 9, 2, "TV", "TV - 8", 930m },
                    { 17, 2, "TV", "TV - 16", 3961m },
                    { 20, 2, "TV", "TV - 19", 2992m },
                    { 18, 3, "Tool", "Tool - 17", 1654m },
                    { 13, 3, "Tool", "Tool - 12", 1463m },
                    { 1, 3, "Tool", "Tool - 0", 4016m },
                    { 97, 2, "TV", "TV - 96", 3458m },
                    { 93, 2, "TV", "TV - 92", 1725m },
                    { 87, 2, "TV", "TV - 86", 2236m },
                    { 83, 2, "TV", "TV - 82", 1840m },
                    { 82, 2, "TV", "TV - 81", 1270m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 77, 2, "TV", "TV - 76", 852m },
                    { 70, 2, "TV", "TV - 69", 4813m },
                    { 66, 5, "Food", "Food - 65", 4399m },
                    { 63, 2, "TV", "TV - 62", 2196m },
                    { 59, 2, "TV", "TV - 58", 3841m },
                    { 54, 2, "TV", "TV - 53", 2716m },
                    { 46, 2, "TV", "TV - 45", 2919m },
                    { 44, 2, "TV", "TV - 43", 3793m },
                    { 40, 2, "TV", "TV - 39", 4052m },
                    { 31, 2, "TV", "TV - 30", 4532m },
                    { 30, 2, "TV", "TV - 29", 934m },
                    { 28, 2, "TV", "TV - 27", 1511m },
                    { 23, 2, "TV", "TV - 22", 4654m },
                    { 21, 2, "TV", "TV - 20", 3630m },
                    { 61, 2, "TV", "TV - 60", 794m },
                    { 73, 5, "Food", "Food - 72", 4995m }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_CategoryId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHashed",
                value: "KI+hCVGYCz9hsX+qUZRBg2EifsfmWdli4NfF4ntQHwlklEqg");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Email", "Login", "Name", "PasswordHashed", "Surname" },
                values: new object[] { 2, null, null, "Ayrum1158", "Ayrum", "TzOaa3bz2JoTgJvBGD3sX4+tiakPi5N66ctPIjQZuBII5A6t", "asdads" });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameAddressToDev_Add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Developers_Dev_Address_Dev_AddressId",
                table: "Developers");

            migrationBuilder.DropTable(
                name: "Dev_Address");

            migrationBuilder.RenameColumn(
                name: "Dev_AddressId",
                table: "Developers",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Developers_Dev_AddressId",
                table: "Developers",
                newName: "IX_Developers_AddressId");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Developers_Address_AddressId",
                table: "Developers",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Developers_Address_AddressId",
                table: "Developers");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Developers",
                newName: "Dev_AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Developers_AddressId",
                table: "Developers",
                newName: "IX_Developers_Dev_AddressId");

            migrationBuilder.CreateTable(
                name: "Dev_Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dev_Address", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Developers_Dev_Address_Dev_AddressId",
                table: "Developers",
                column: "Dev_AddressId",
                principalTable: "Dev_Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameAddressToDev_Addressrt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Developers_Address_AddressId",
                table: "Developers");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Developers",
                newName: "Dev_AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Developers_AddressId",
                table: "Developers",
                newName: "IX_Developers_Dev_AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Developers_Address_Dev_AddressId",
                table: "Developers",
                column: "Dev_AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Developers_Address_Dev_AddressId",
                table: "Developers");

            migrationBuilder.RenameColumn(
                name: "Dev_AddressId",
                table: "Developers",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Developers_Dev_AddressId",
                table: "Developers",
                newName: "IX_Developers_AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Developers_Address_AddressId",
                table: "Developers",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

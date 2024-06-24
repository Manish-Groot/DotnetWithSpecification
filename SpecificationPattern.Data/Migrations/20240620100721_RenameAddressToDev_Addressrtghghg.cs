using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameAddressToDev_Addressrtghghg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Developers_Address_Dev_AddressId",
                table: "Developers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Dev_Address");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dev_Address",
                table: "Dev_Address",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Developers_Dev_Address_Dev_AddressId",
                table: "Developers",
                column: "Dev_AddressId",
                principalTable: "Dev_Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Developers_Dev_Address_Dev_AddressId",
                table: "Developers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dev_Address",
                table: "Dev_Address");

            migrationBuilder.RenameTable(
                name: "Dev_Address",
                newName: "Address");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Developers_Address_Dev_AddressId",
                table: "Developers",
                column: "Dev_AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

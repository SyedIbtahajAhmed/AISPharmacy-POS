using Microsoft.EntityFrameworkCore.Migrations;

namespace AISPharmacy.Migrations
{
    public partial class AddFKReferenceOnCompanyOfProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "productId",
                table: "CompanyTable",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyTable_productId",
                table: "CompanyTable",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyTable_ProductsTable_productId",
                table: "CompanyTable",
                column: "productId",
                principalTable: "ProductsTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyTable_ProductsTable_productId",
                table: "CompanyTable");

            migrationBuilder.DropIndex(
                name: "IX_CompanyTable_productId",
                table: "CompanyTable");

            migrationBuilder.DropColumn(
                name: "productId",
                table: "CompanyTable");
        }
    }
}

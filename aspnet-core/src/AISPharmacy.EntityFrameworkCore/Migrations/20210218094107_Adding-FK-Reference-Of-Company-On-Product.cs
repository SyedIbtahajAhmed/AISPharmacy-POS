using Microsoft.EntityFrameworkCore.Migrations;

namespace AISPharmacy.Migrations
{
    public partial class AddingFKReferenceOfCompanyOnProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "ProductsTable",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductsTable_CompanyId",
                table: "ProductsTable",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsTable_CompanyTable_CompanyId",
                table: "ProductsTable",
                column: "CompanyId",
                principalTable: "CompanyTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsTable_CompanyTable_CompanyId",
                table: "ProductsTable");

            migrationBuilder.DropIndex(
                name: "IX_ProductsTable_CompanyId",
                table: "ProductsTable");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "ProductsTable");
        }
    }
}

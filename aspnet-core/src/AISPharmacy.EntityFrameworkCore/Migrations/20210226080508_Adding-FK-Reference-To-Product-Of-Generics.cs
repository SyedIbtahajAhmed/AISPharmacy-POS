using Microsoft.EntityFrameworkCore.Migrations;

namespace AISPharmacy.Migrations
{
    public partial class AddingFKReferenceToProductOfGenerics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenericId",
                table: "ProductsTable",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductsTable_GenericId",
                table: "ProductsTable",
                column: "GenericId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsTable_MedcineGenericsTable_GenericId",
                table: "ProductsTable",
                column: "GenericId",
                principalTable: "MedcineGenericsTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsTable_MedcineGenericsTable_GenericId",
                table: "ProductsTable");

            migrationBuilder.DropIndex(
                name: "IX_ProductsTable_GenericId",
                table: "ProductsTable");

            migrationBuilder.DropColumn(
                name: "GenericId",
                table: "ProductsTable");
        }
    }
}

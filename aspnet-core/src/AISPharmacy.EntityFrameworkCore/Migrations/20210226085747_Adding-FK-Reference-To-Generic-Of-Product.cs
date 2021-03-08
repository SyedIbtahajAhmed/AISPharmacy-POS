using Microsoft.EntityFrameworkCore.Migrations;

namespace AISPharmacy.Migrations
{
    public partial class AddingFKReferenceToGenericOfProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "MedcineGenericsTable",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedcineGenericsTable_ProductId",
                table: "MedcineGenericsTable",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedcineGenericsTable_ProductsTable_ProductId",
                table: "MedcineGenericsTable",
                column: "ProductId",
                principalTable: "ProductsTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedcineGenericsTable_ProductsTable_ProductId",
                table: "MedcineGenericsTable");

            migrationBuilder.DropIndex(
                name: "IX_MedcineGenericsTable_ProductId",
                table: "MedcineGenericsTable");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "MedcineGenericsTable");
        }
    }
}

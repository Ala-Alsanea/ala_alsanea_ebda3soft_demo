using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ala_alsanea_ebda3soft_demo.Migrations
{
    /// <inheritdoc />
    public partial class linkAccountwithInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AccountId",
                table: "Invoices",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_AccountId",
                table: "Invoices",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Accounts_AccountId",
                table: "Invoices",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Accounts_AccountId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_AccountId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Invoices");
        }
    }
}

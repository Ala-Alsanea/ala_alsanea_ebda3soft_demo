using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ala_alsanea_ebda3soft_demo.Migrations
{
    /// <inheritdoc />
    public partial class completeAllAttr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AccountId",
                table: "Receipts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Receipts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Receipts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Receipts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ReceiptType",
                table: "Receipts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "CategoryId",
                table: "Invoices",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "InvoiceType",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PayType",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Qty",
                table: "Invoices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "UnitPrice",
                table: "Invoices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_AccountId",
                table: "Receipts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CategoryId",
                table: "Invoices",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Categories_CategoryId",
                table: "Invoices",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Accounts_AccountId",
                table: "Receipts",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Categories_CategoryId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Accounts_AccountId",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_AccountId",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_CategoryId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "ReceiptType",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "InvoiceType",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "PayType",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Qty",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "Invoices");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Essensys.Infrastructure.Migrations
{
    public partial class Innitial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tokens_Transactions_TransactionId",
                table: "Tokens");

            migrationBuilder.RenameColumn(
                name: "TransactionId",
                table: "Tokens",
                newName: "TransactionID");

            migrationBuilder.RenameIndex(
                name: "IX_Tokens_TransactionId",
                table: "Tokens",
                newName: "IX_Tokens_TransactionID");

            migrationBuilder.AlterColumn<int>(
                name: "TransactionID",
                table: "Tokens",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tokens_Transactions_TransactionID",
                table: "Tokens",
                column: "TransactionID",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tokens_Transactions_TransactionID",
                table: "Tokens");

            migrationBuilder.RenameColumn(
                name: "TransactionID",
                table: "Tokens",
                newName: "TransactionId");

            migrationBuilder.RenameIndex(
                name: "IX_Tokens_TransactionID",
                table: "Tokens",
                newName: "IX_Tokens_TransactionId");

            migrationBuilder.AlterColumn<int>(
                name: "TransactionId",
                table: "Tokens",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Tokens_Transactions_TransactionId",
                table: "Tokens",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

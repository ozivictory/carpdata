using Microsoft.EntityFrameworkCore.Migrations;

namespace CARPDataGenerator.Data.Migrations
{
    public partial class updateRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SIGNATORY_OR_DIRECTOR_ID",
                table: "TransactionPersonIdentification",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SIGNATORY_OR_DIRECTOR_ID",
                table: "TransactionPersonIdentification",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

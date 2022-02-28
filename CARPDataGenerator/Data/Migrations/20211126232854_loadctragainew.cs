using Microsoft.EntityFrameworkCore.Migrations;

namespace CARPDataGenerator.Data.Migrations
{
    public partial class loadctragainew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SIGNATORY_OR_DIRECTOR_ID",
                table: "TransactionSignatoryOrDirector",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SIGNATORY_OR_DIRECTOR_ID",
                table: "TransactionSignatoryOrDirector");
        }
    }
}

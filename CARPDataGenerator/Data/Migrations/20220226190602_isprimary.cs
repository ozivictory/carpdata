using Microsoft.EntityFrameworkCore.Migrations;

namespace CARPDataGenerator.Data.Migrations
{
    public partial class isprimary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IS_PRIMARY",
                table: "TransactionSignatoryOrDirector");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IS_PRIMARY",
                table: "TransactionSignatoryOrDirector",
                type: "bit",
                nullable: true);
        }
    }
}

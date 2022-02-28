using Microsoft.EntityFrameworkCore.Migrations;

namespace CARPDataGenerator.Data.Migrations
{
    public partial class loadctragain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SIGNATORY_ADDRESS",
                table: "TransactionSignatoryOrDirector");

            migrationBuilder.DropColumn(
                name: "SIGNATORY_ADDRESS_COMMENTS",
                table: "TransactionSignatoryOrDirector");

            migrationBuilder.DropColumn(
                name: "SIGNATORY_ADDRESS_TYPE",
                table: "TransactionSignatoryOrDirector");

            migrationBuilder.DropColumn(
                name: "SIGNATORY_CITY",
                table: "TransactionSignatoryOrDirector");

            migrationBuilder.DropColumn(
                name: "SIGNATORY_COMMENTS",
                table: "TransactionSignatoryOrDirector");

            migrationBuilder.DropColumn(
                name: "SIGNATORY_COUNTRY_CODE",
                table: "TransactionSignatoryOrDirector");

            migrationBuilder.DropColumn(
                name: "SIGNATORY_COUNTRY_PREFIX",
                table: "TransactionSignatoryOrDirector");

            migrationBuilder.DropColumn(
                name: "SIGNATORY_NUMBER",
                table: "TransactionSignatoryOrDirector");

            migrationBuilder.DropColumn(
                name: "SIGNATORY_PHONE_COMMENTS",
                table: "TransactionSignatoryOrDirector");

            migrationBuilder.DropColumn(
                name: "SIGNATORY_STATE",
                table: "TransactionSignatoryOrDirector");

            migrationBuilder.DropColumn(
                name: "SIGNATORY_TOWN",
                table: "TransactionSignatoryOrDirector");

            migrationBuilder.DropColumn(
                name: "SIGNATORY_TPH_COMMUNICATION_TYPE",
                table: "TransactionSignatoryOrDirector");

            migrationBuilder.DropColumn(
                name: "SIGNATORY_TPH_CONTACT_TYPE",
                table: "TransactionSignatoryOrDirector");

            migrationBuilder.DropColumn(
                name: "SIGNATORY_TPH_EXTENSION",
                table: "TransactionSignatoryOrDirector");

            migrationBuilder.DropColumn(
                name: "SIGNATORY_ZIP",
                table: "TransactionSignatoryOrDirector");

            migrationBuilder.AlterColumn<bool>(
                name: "DECEASED",
                table: "TransactionSignatoryOrDirector",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<bool>(
                name: "IS_PRIMARY",
                table: "TransactionSignatoryOrDirector",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SIGNATORY_OR_DIRECTOR_ADDRESS",
                table: "TransactionSignatoryOrDirector",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SIGNATORY_OR_DIRECTOR_ADDRESS_COMMENTS",
                table: "TransactionSignatoryOrDirector",
                maxLength: 25,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SIGNATORY_OR_DIRECTOR_ADDRESS_TYPE",
                table: "TransactionSignatoryOrDirector",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SIGNATORY_OR_DIRECTOR_CITY",
                table: "TransactionSignatoryOrDirector",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SIGNATORY_OR_DIRECTOR_COMMENTS",
                table: "TransactionSignatoryOrDirector",
                maxLength: 4000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SIGNATORY_OR_DIRECTOR_COUNTRY_CODE",
                table: "TransactionSignatoryOrDirector",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SIGNATORY_OR_DIRECTOR_COUNTRY_PREFIX",
                table: "TransactionSignatoryOrDirector",
                maxLength: 4,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SIGNATORY_OR_DIRECTOR_NUMBER",
                table: "TransactionSignatoryOrDirector",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SIGNATORY_OR_DIRECTOR_PHONE_COMMENTS",
                table: "TransactionSignatoryOrDirector",
                maxLength: 4000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SIGNATORY_OR_DIRECTOR_STATE",
                table: "TransactionSignatoryOrDirector",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SIGNATORY_OR_DIRECTOR_TOWN",
                table: "TransactionSignatoryOrDirector",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SIGNATORY_OR_DIRECTOR_TPH_COMMUNICATION_TYPE",
                table: "TransactionSignatoryOrDirector",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SIGNATORY_OR_DIRECTOR_TPH_CONTACT_TYPE",
                table: "TransactionSignatoryOrDirector",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SIGNATORY_OR_DIRECTOR_TPH_EXTENSION",
                table: "TransactionSignatoryOrDirector",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SIGNATORY_OR_DIRECTOR_ZIP",
                table: "TransactionSignatoryOrDirector",
                maxLength: 10,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IS_PRIMARY",
                table: "TransactionSignatoryOrDirector");

            migrationBuilder.DropColumn(
                name: "SIGNATORY_OR_DIRECTOR_ADDRESS",
                table: "TransactionSignatoryOrDirector");

            migrationBuilder.DropColumn(
                name: "SIGNATORY_OR_DIRECTOR_ADDRESS_COMMENTS",
                table: "TransactionSignatoryOrDirector");

            migrationBuilder.DropColumn(
                name: "SIGNATORY_OR_DIRECTOR_ADDRESS_TYPE",
                table: "TransactionSignatoryOrDirector");

            migrationBuilder.DropColumn(
                name: "SIGNATORY_OR_DIRECTOR_CITY",
                table: "TransactionSignatoryOrDirector");

            migrationBuilder.DropColumn(
                name: "SIGNATORY_OR_DIRECTOR_COMMENTS",
                table: "TransactionSignatoryOrDirector");

            migrationBuilder.DropColumn(
                name: "SIGNATORY_OR_DIRECTOR_COUNTRY_CODE",
                table: "TransactionSignatoryOrDirector");

            migrationBuilder.DropColumn(
                name: "SIGNATORY_OR_DIRECTOR_COUNTRY_PREFIX",
                table: "TransactionSignatoryOrDirector");

            migrationBuilder.DropColumn(
                name: "SIGNATORY_OR_DIRECTOR_NUMBER",
                table: "TransactionSignatoryOrDirector");

            migrationBuilder.DropColumn(
                name: "SIGNATORY_OR_DIRECTOR_PHONE_COMMENTS",
                table: "TransactionSignatoryOrDirector");

            migrationBuilder.DropColumn(
                name: "SIGNATORY_OR_DIRECTOR_STATE",
                table: "TransactionSignatoryOrDirector");

            migrationBuilder.DropColumn(
                name: "SIGNATORY_OR_DIRECTOR_TOWN",
                table: "TransactionSignatoryOrDirector");

            migrationBuilder.DropColumn(
                name: "SIGNATORY_OR_DIRECTOR_TPH_COMMUNICATION_TYPE",
                table: "TransactionSignatoryOrDirector");

            migrationBuilder.DropColumn(
                name: "SIGNATORY_OR_DIRECTOR_TPH_CONTACT_TYPE",
                table: "TransactionSignatoryOrDirector");

            migrationBuilder.DropColumn(
                name: "SIGNATORY_OR_DIRECTOR_TPH_EXTENSION",
                table: "TransactionSignatoryOrDirector");

            migrationBuilder.DropColumn(
                name: "SIGNATORY_OR_DIRECTOR_ZIP",
                table: "TransactionSignatoryOrDirector");

            migrationBuilder.AlterColumn<bool>(
                name: "DECEASED",
                table: "TransactionSignatoryOrDirector",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SIGNATORY_ADDRESS",
                table: "TransactionSignatoryOrDirector",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SIGNATORY_ADDRESS_COMMENTS",
                table: "TransactionSignatoryOrDirector",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SIGNATORY_ADDRESS_TYPE",
                table: "TransactionSignatoryOrDirector",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SIGNATORY_CITY",
                table: "TransactionSignatoryOrDirector",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SIGNATORY_COMMENTS",
                table: "TransactionSignatoryOrDirector",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SIGNATORY_COUNTRY_CODE",
                table: "TransactionSignatoryOrDirector",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SIGNATORY_COUNTRY_PREFIX",
                table: "TransactionSignatoryOrDirector",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SIGNATORY_NUMBER",
                table: "TransactionSignatoryOrDirector",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SIGNATORY_PHONE_COMMENTS",
                table: "TransactionSignatoryOrDirector",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SIGNATORY_STATE",
                table: "TransactionSignatoryOrDirector",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SIGNATORY_TOWN",
                table: "TransactionSignatoryOrDirector",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SIGNATORY_TPH_COMMUNICATION_TYPE",
                table: "TransactionSignatoryOrDirector",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SIGNATORY_TPH_CONTACT_TYPE",
                table: "TransactionSignatoryOrDirector",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SIGNATORY_TPH_EXTENSION",
                table: "TransactionSignatoryOrDirector",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SIGNATORY_ZIP",
                table: "TransactionSignatoryOrDirector",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);
        }
    }
}

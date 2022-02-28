using Microsoft.EntityFrameworkCore.Migrations;

namespace CARPDataGenerator.Data.Migrations
{
    public partial class lookup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentifierType",
                table: "IdentifierType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CountryCodes",
                table: "CountryCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactType",
                table: "ContactType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommunicationType",
                table: "CommunicationType");

            migrationBuilder.RenameTable(
                name: "IdentifierType",
                newName: "LookupIdentifierType");

            migrationBuilder.RenameTable(
                name: "CountryCodes",
                newName: "LookupCountryCodes");

            migrationBuilder.RenameTable(
                name: "ContactType",
                newName: "LookupContactType");

            migrationBuilder.RenameTable(
                name: "CommunicationType",
                newName: "LookupCommunicationType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LookupIdentifierType",
                table: "LookupIdentifierType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LookupCountryCodes",
                table: "LookupCountryCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LookupContactType",
                table: "LookupContactType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LookupCommunicationType",
                table: "LookupCommunicationType",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "LookupAccountStatusType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupAccountStatusType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LookupAccountType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupAccountType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LookupConductionType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupConductionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LookupCurrencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupCurrencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LookupEntityLegalFormType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupEntityLegalFormType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LookupFundsType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupFundsType", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LookupAccountStatusType");

            migrationBuilder.DropTable(
                name: "LookupAccountType");

            migrationBuilder.DropTable(
                name: "LookupConductionType");

            migrationBuilder.DropTable(
                name: "LookupCurrencies");

            migrationBuilder.DropTable(
                name: "LookupEntityLegalFormType");

            migrationBuilder.DropTable(
                name: "LookupFundsType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LookupIdentifierType",
                table: "LookupIdentifierType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LookupCountryCodes",
                table: "LookupCountryCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LookupContactType",
                table: "LookupContactType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LookupCommunicationType",
                table: "LookupCommunicationType");

            migrationBuilder.RenameTable(
                name: "LookupIdentifierType",
                newName: "IdentifierType");

            migrationBuilder.RenameTable(
                name: "LookupCountryCodes",
                newName: "CountryCodes");

            migrationBuilder.RenameTable(
                name: "LookupContactType",
                newName: "ContactType");

            migrationBuilder.RenameTable(
                name: "LookupCommunicationType",
                newName: "CommunicationType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentifierType",
                table: "IdentifierType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CountryCodes",
                table: "CountryCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactType",
                table: "ContactType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommunicationType",
                table: "CommunicationType",
                column: "Id");
        }
    }
}

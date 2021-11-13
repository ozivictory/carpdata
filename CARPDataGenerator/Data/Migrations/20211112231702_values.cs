using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CARPDataGenerator.Data.Migrations
{
    public partial class values : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommunicationType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunicationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountryCodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CTR",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TRANSACTION_NUMBER = table.Column<string>(nullable: true),
                    TRANSACTION_DESCRIPTION = table.Column<string>(nullable: true),
                    TRANSACTION_LOCATION = table.Column<string>(nullable: true),
                    TRANSACTION_DATE = table.Column<DateTime>(nullable: true),
                    TELLER = table.Column<string>(nullable: true),
                    AUTHORIZED = table.Column<string>(nullable: true),
                    LATE_DEPOSIT = table.Column<bool>(nullable: false),
                    DATE_POSTING = table.Column<DateTime>(nullable: true),
                    AMOUNT_LOCAL = table.Column<double>(nullable: false),
                    TRANSACTION_MODE = table.Column<string>(nullable: true),
                    TO_FUNDS_CODE = table.Column<string>(nullable: true),
                    TO_FUNDS_COMMENT = table.Column<string>(nullable: true),
                    TO_FOREIGN_CURRENCY = table.Column<string>(nullable: true),
                    FOREIGN_CURRENCY = table.Column<string>(nullable: true),
                    FOREIGN_AMOUNT = table.Column<double>(nullable: true),
                    FOREIGN_EX_RATE = table.Column<string>(nullable: true),
                    FROM_FUNDS_CODE = table.Column<string>(nullable: true),
                    FROM_FUNDS_COMMENT = table.Column<string>(nullable: true),
                    FROM_FOREIGN_CURRENCY = table.Column<string>(nullable: true),
                    TRANS_CONDUCTOR = table.Column<string>(nullable: true),
                    FROM_INSTITUTION_NAME = table.Column<string>(maxLength: 255, nullable: true),
                    FROM_INSTITUTION_CODE = table.Column<string>(maxLength: 50, nullable: true),
                    FROM_INSTITUTION_SWIFT = table.Column<string>(maxLength: 11, nullable: true),
                    FROM_NON_BANK_INSTUTION = table.Column<bool>(nullable: true),
                    FROM_INSTITUTION_BRANCH = table.Column<string>(maxLength: 255, nullable: true),
                    FROM_ACCOUNT = table.Column<string>(maxLength: 50, nullable: true),
                    FROM_CURRENCY_CODE = table.Column<string>(nullable: true),
                    FROM_ACCOUNT_NAME = table.Column<string>(maxLength: 255, nullable: true),
                    FROM_ACCOUNT_IBAN = table.Column<string>(maxLength: 34, nullable: true),
                    FROM_CLIENT_NUMBER = table.Column<string>(maxLength: 30, nullable: true),
                    FROM_PERSONAL_ACCOUNT_TYPE = table.Column<string>(nullable: true),
                    OPENED = table.Column<DateTime>(nullable: true),
                    CLOSED = table.Column<DateTime>(nullable: true),
                    BALANCE = table.Column<double>(nullable: true),
                    DATE_BALANCE = table.Column<DateTime>(nullable: true),
                    STATUS_CODE = table.Column<string>(nullable: true),
                    BENEFICIARY = table.Column<string>(maxLength: 100, nullable: true),
                    BENEFICIARY_COMMENT = table.Column<string>(maxLength: 255, nullable: true),
                    FROM_ACCOUNT_COMMENTS = table.Column<string>(maxLength: 4000, nullable: true),
                    FROM_PERSON_GENDER = table.Column<string>(nullable: true),
                    FROM_PERSON_TITLE = table.Column<string>(maxLength: 30, nullable: true),
                    FROM_PERSON_FIRST_NAME = table.Column<string>(maxLength: 100, nullable: true),
                    FROM_PERSON_MIDDLE_NAME = table.Column<string>(maxLength: 100, nullable: true),
                    FROM_PERSON_PREFIX = table.Column<string>(maxLength: 100, nullable: true),
                    FROM_PERSON_LAST_NAME = table.Column<string>(maxLength: 100, nullable: true),
                    FROM_PERSON_BIRTHDATE = table.Column<DateTime>(nullable: true),
                    FROM_PERSON_BIRTH_PLACE = table.Column<string>(maxLength: 255, nullable: true),
                    FROM_PERSON_MOTHERS_NAME = table.Column<string>(maxLength: 100, nullable: true),
                    FROM_PERSON_ALIAS = table.Column<string>(maxLength: 100, nullable: true),
                    FROM_PERSON_SSN = table.Column<string>(maxLength: 25, nullable: true),
                    FROM_PERSON_PASSPORT_NUMBER = table.Column<string>(maxLength: 25, nullable: true),
                    FROM_PERSON_PASSPORT_COUNTRY = table.Column<string>(maxLength: 25, nullable: true),
                    FROM_PERSON_ID_NUMBER = table.Column<string>(maxLength: 25, nullable: true),
                    FROM_PERSON_TPH_CONTACT_TYPE = table.Column<string>(nullable: true),
                    FROM_PERSON_TPH_COMMUNICATION_TYPE = table.Column<string>(nullable: true),
                    FROM_PERSON_COUNTRY_PREFIX = table.Column<string>(maxLength: 4, nullable: true),
                    FROM_PERSON_NUMBER = table.Column<string>(maxLength: 50, nullable: true),
                    FROM_PERSON_TPH_EXTENSION = table.Column<string>(maxLength: 10, nullable: true),
                    FROM_PERSON_PHONE_COMMENTS = table.Column<string>(maxLength: 4000, nullable: true),
                    FROM_PERSON_ADDRESS_TYPE = table.Column<string>(nullable: true),
                    FROM_PERSON_ADDRESS = table.Column<string>(maxLength: 100, nullable: true),
                    FROM_PERSON_TOWN = table.Column<string>(maxLength: 255, nullable: true),
                    FROM_PERSON_CITY = table.Column<string>(maxLength: 255, nullable: true),
                    FROM_PERSON_ZIP = table.Column<string>(maxLength: 10, nullable: true),
                    FROM_PERSON_COUNTRY_CODE = table.Column<string>(nullable: true),
                    FROM_PERSON_STATE = table.Column<string>(maxLength: 255, nullable: true),
                    FROM_PERSON_ADDRESS_COMMENTS = table.Column<string>(maxLength: 25, nullable: true),
                    FROM_PERSON_NATIONALITY1 = table.Column<string>(nullable: true),
                    FROM_PERSON_NATIONALITY2 = table.Column<string>(nullable: true),
                    FROM_PERSON_NATIONALITY3 = table.Column<string>(nullable: true),
                    FROM_PERSON_RESIDENCE = table.Column<string>(nullable: true),
                    FROM_PERSON_EMAIL1 = table.Column<string>(nullable: true),
                    FROM_PERSON_EMAIL2 = table.Column<string>(nullable: true),
                    FROM_PERSON_EMAIL3 = table.Column<string>(nullable: true),
                    FROM_PERSON_EMAIL4 = table.Column<string>(nullable: true),
                    FROM_PERSON_EMAIL5 = table.Column<string>(nullable: true),
                    FROM_PERSON_OCCUPATION = table.Column<string>(maxLength: 255, nullable: true),
                    FROM_PERSON_EMPLOYER_NAME = table.Column<string>(maxLength: 255, nullable: true),
                    FROM_PERSON_EMPLOYER_ADDRESS_TYPE = table.Column<string>(nullable: true),
                    FROM_PERSON_EMPLOYER_ADDRESS = table.Column<string>(maxLength: 100, nullable: true),
                    FROM_PERSON_EMPLOYER_TOWN = table.Column<string>(maxLength: 255, nullable: true),
                    FROM_PERSON_EMPLOYER_CITY = table.Column<string>(maxLength: 255, nullable: true),
                    FROM_PERSON_EMPLOYER_ZIP = table.Column<string>(maxLength: 10, nullable: true),
                    FROM_PERSON_EMPLOYER_COUNTRY_CODE = table.Column<string>(nullable: true),
                    FROM_PERSON_EMPLOYER_STATE = table.Column<string>(maxLength: 255, nullable: true),
                    FROM_PERSON_EMPLOYER_ADDRESS_COMMENTS = table.Column<string>(maxLength: 25, nullable: true),
                    FROM_PERSON_EMPLOYER_TPH_CONTACT_TYPE = table.Column<string>(nullable: true),
                    FROM_PERSON_EMPLOYER_TPH_COMMUNICATION_TYPE = table.Column<string>(nullable: true),
                    FROM_PERSON_EMPLOYER_COUNTRY_PREFIX = table.Column<string>(maxLength: 4, nullable: true),
                    FROM_PERSON_EMPLOYER_NUMBER = table.Column<string>(maxLength: 50, nullable: true),
                    FROM_PERSON_EMPLOYER_TPH_EXTENSION = table.Column<string>(maxLength: 10, nullable: true),
                    FROM_PERSON_EMPLOYER_PHONE_COMMENTS = table.Column<string>(maxLength: 4000, nullable: true),
                    DECEASED = table.Column<bool>(nullable: false),
                    FROM_PERSON_DECEASED_DATE = table.Column<DateTime>(nullable: true),
                    FROM_PERSON_TAX_NUMBER = table.Column<string>(maxLength: 100, nullable: true),
                    FROM_PERSON_TAX_REG_NUMBER = table.Column<string>(maxLength: 100, nullable: true),
                    FROM_PERSON_SOURCE_OF_WEALTH = table.Column<string>(maxLength: 255, nullable: true),
                    FROM_PERSON_COMMENTS = table.Column<string>(maxLength: 4000, nullable: true),
                    FROM_ENTITY_NAME = table.Column<string>(maxLength: 255, nullable: true),
                    FROM_ENTITY_COMMERCIAL_NAME = table.Column<string>(maxLength: 255, nullable: true),
                    FROM_ENTITY_INCORPORATION_LEGAL_FORM = table.Column<string>(nullable: true),
                    FROM_ENTITY_INCORPORATION_NUMBER = table.Column<string>(maxLength: 50, nullable: true),
                    FROM_ENTITY_BUSINESS = table.Column<string>(maxLength: 255, nullable: true),
                    FROM_ENTITY_TPH_CONTACT_TYPE = table.Column<string>(nullable: true),
                    FROM_ENTITY_TPH_COMMUNICATION_TYPE = table.Column<string>(nullable: true),
                    FROM_ENTITY_COUNTRY_PREFIX = table.Column<string>(maxLength: 4, nullable: true),
                    FROM_ENTITY_NUMBER = table.Column<string>(maxLength: 50, nullable: true),
                    FROM_ENTITY_TPH_EXTENSION = table.Column<string>(maxLength: 10, nullable: true),
                    FROM_ENTITY_PHONE_COMMENTS = table.Column<string>(maxLength: 4000, nullable: true),
                    FROM_ENTITY_ADDRESS_TYPE = table.Column<string>(nullable: true),
                    FROM_ENTITY_ADDRESS = table.Column<string>(maxLength: 100, nullable: true),
                    FROM_ENTITY_TOWN = table.Column<string>(maxLength: 255, nullable: true),
                    FROM_ENTITY_CITY = table.Column<string>(maxLength: 255, nullable: true),
                    FROM_ENTITY_ZIP = table.Column<string>(maxLength: 10, nullable: true),
                    FROM_ENTITY_COUNTRY_CODE = table.Column<string>(nullable: true),
                    FROM_ENTITY_STATE = table.Column<string>(maxLength: 255, nullable: true),
                    FROM_ENTITY_ADDRESS_COMMENTS = table.Column<string>(maxLength: 25, nullable: true),
                    FROM_ENTITY_EMAIL = table.Column<string>(maxLength: 255, nullable: true),
                    FROM_ENTITY_URL = table.Column<string>(maxLength: 255, nullable: true),
                    FROM_ENTITY_INCORPORATION_STATE = table.Column<string>(maxLength: 255, nullable: true),
                    FROM_ENTITY_INCORPORATION_COUNTRY_CODE = table.Column<string>(nullable: true),
                    FROM_ENTITY_INCORPORATION_DATE = table.Column<DateTime>(nullable: true),
                    FROM_ENTITY_BUSINESS_CLOSED = table.Column<bool>(nullable: true),
                    FROM_ENTITY_DATE_BUSINESS_CLOSED = table.Column<DateTime>(nullable: true),
                    FROM_ENTITY_TAX_NUMBER = table.Column<string>(maxLength: 100, nullable: true),
                    FROM_ENTITY_TAX_REG_NUMBER = table.Column<string>(maxLength: 100, nullable: true),
                    FROM_ENTITY_COMMENTS = table.Column<string>(maxLength: 4000, nullable: true),
                    TO_INSTITUTION_NAME = table.Column<string>(maxLength: 255, nullable: true),
                    TO_INSTITUTION_CODE = table.Column<string>(maxLength: 50, nullable: true),
                    TO_INSTITUTION_SWIFT = table.Column<string>(maxLength: 11, nullable: true),
                    TO_NON_BANK_INSTUTION = table.Column<bool>(nullable: true),
                    TO_INSTITUTION_BRANCH = table.Column<string>(maxLength: 255, nullable: true),
                    TO_ACCOUNT = table.Column<string>(maxLength: 50, nullable: true),
                    TO_CURRENCY_CODE = table.Column<string>(nullable: true),
                    TO_ACCOUNT_NAME = table.Column<string>(maxLength: 255, nullable: true),
                    TO_ACCOUNT_IBAN = table.Column<string>(maxLength: 34, nullable: true),
                    TO_CLIENT_NUMBER = table.Column<string>(maxLength: 30, nullable: true),
                    TO_PERSONAL_ACCOUNT_TYPE = table.Column<string>(nullable: true),
                    TO_OPENED = table.Column<DateTime>(nullable: true),
                    TO_CLOSED = table.Column<DateTime>(nullable: true),
                    TO_BALANCE = table.Column<double>(nullable: true),
                    TO_DATE_BALANCE = table.Column<DateTime>(nullable: true),
                    TO_STATUS_CODE = table.Column<string>(nullable: true),
                    TO_BENEFICIARY = table.Column<string>(maxLength: 100, nullable: true),
                    TO_BENEFICIARY_COMMENT = table.Column<string>(maxLength: 255, nullable: true),
                    TO_ACCOUNT_COMMENTS = table.Column<string>(maxLength: 4000, nullable: true),
                    TO_PERSON_GENDER = table.Column<string>(nullable: true),
                    TO_PERSON_TITLE = table.Column<string>(maxLength: 30, nullable: true),
                    TO_PERSON_FIRST_NAME = table.Column<string>(maxLength: 100, nullable: true),
                    TO_PERSON_MIDDLE_NAME = table.Column<string>(maxLength: 100, nullable: true),
                    TO_PERSON_PREFIX = table.Column<string>(maxLength: 100, nullable: true),
                    TO_PERSON_LAST_NAME = table.Column<string>(maxLength: 100, nullable: true),
                    TO_PERSON_BIRTHDATE = table.Column<DateTime>(nullable: true),
                    TO_PERSON_BIRTH_PLACE = table.Column<string>(maxLength: 255, nullable: true),
                    TO_PERSON_MOTHERS_NAME = table.Column<string>(maxLength: 100, nullable: true),
                    TO_PERSON_ALIAS = table.Column<string>(maxLength: 100, nullable: true),
                    TO_PERSON_SSN = table.Column<string>(maxLength: 25, nullable: true),
                    TO_PERSON_PASSPORT_NUMBER = table.Column<string>(maxLength: 25, nullable: true),
                    TO_PERSON_PASSPORT_COUNTRY = table.Column<string>(maxLength: 25, nullable: true),
                    TO_PERSON_ID_NUMBER = table.Column<string>(maxLength: 25, nullable: true),
                    TO_PERSON_TPH_CONTACT_TYPE = table.Column<string>(nullable: true),
                    TO_PERSON_TPH_COMMUNICATION_TYPE = table.Column<string>(nullable: true),
                    TO_PERSON_COUNTRY_PREFIX = table.Column<string>(maxLength: 4, nullable: true),
                    TO_PERSON_NUMBER = table.Column<string>(maxLength: 50, nullable: true),
                    TO_PERSON_TPH_EXTENSION = table.Column<string>(maxLength: 10, nullable: true),
                    TO_PERSON_PHONE_COMMENTS = table.Column<string>(maxLength: 4000, nullable: true),
                    TO_PERSON_ADDRESS_TYPE = table.Column<string>(nullable: true),
                    TO_PERSON_ADDRESS = table.Column<string>(maxLength: 100, nullable: true),
                    TO_PERSON_TOWN = table.Column<string>(maxLength: 255, nullable: true),
                    TO_PERSON_CITY = table.Column<string>(maxLength: 255, nullable: true),
                    TO_PERSON_ZIP = table.Column<string>(maxLength: 10, nullable: true),
                    TO_PERSON_COUNTRY_CODE = table.Column<string>(nullable: true),
                    TO_PERSON_STATE = table.Column<string>(maxLength: 255, nullable: true),
                    TO_PERSON_ADDRESS_COMMENTS = table.Column<string>(maxLength: 25, nullable: true),
                    TO_PERSON_NATIONALITY1 = table.Column<string>(nullable: true),
                    TO_PERSON_NATIONALITY2 = table.Column<string>(nullable: true),
                    TO_PERSON_NATIONALITY3 = table.Column<string>(nullable: true),
                    TO_PERSON_RESIDENCE = table.Column<string>(nullable: true),
                    TO_PERSON_EMAIL1 = table.Column<string>(nullable: true),
                    TO_PERSON_EMAIL2 = table.Column<string>(nullable: true),
                    TO_PERSON_EMAIL3 = table.Column<string>(nullable: true),
                    TO_PERSON_EMAIL4 = table.Column<string>(nullable: true),
                    TO_PERSON_EMAIL5 = table.Column<string>(nullable: true),
                    TO_PERSON_OCCUPATION = table.Column<string>(maxLength: 255, nullable: true),
                    TO_PERSON_EMPLOYER_NAME = table.Column<string>(maxLength: 255, nullable: true),
                    TO_PERSON_EMPLOYER_ADDRESS_TYPE = table.Column<string>(nullable: true),
                    TO_PERSON_EMPLOYER_ADDRESS = table.Column<string>(maxLength: 100, nullable: true),
                    TO_PERSON_EMPLOYER_TOWN = table.Column<string>(maxLength: 255, nullable: true),
                    TO_PERSON_EMPLOYER_CITY = table.Column<string>(maxLength: 255, nullable: true),
                    TO_PERSON_EMPLOYER_ZIP = table.Column<string>(maxLength: 10, nullable: true),
                    TO_PERSON_EMPLOYER_COUNTRY_CODE = table.Column<string>(nullable: true),
                    TO_PERSON_EMPLOYER_STATE = table.Column<string>(maxLength: 255, nullable: true),
                    TO_PERSON_EMPLOYER_ADDRESS_COMMENTS = table.Column<string>(maxLength: 25, nullable: true),
                    TO_PERSON_EMPLOYER_TPH_CONTACT_TYPE = table.Column<string>(nullable: true),
                    TO_PERSON_EMPLOYER_TPH_COMMUNICATION_TYPE = table.Column<string>(nullable: true),
                    TO_PERSON_EMPLOYER_COUNTRY_PREFIX = table.Column<string>(maxLength: 4, nullable: true),
                    TO_PERSON_EMPLOYER_NUMBER = table.Column<string>(maxLength: 50, nullable: true),
                    TO_PERSON_EMPLOYER_TPH_EXTENSION = table.Column<string>(maxLength: 10, nullable: true),
                    TO_PERSON_EMPLOYER_PHONE_COMMENTS = table.Column<string>(maxLength: 4000, nullable: true),
                    TO_PERSON_DECEASED = table.Column<bool>(nullable: false),
                    TO_PERSON_DECEASED_DATE = table.Column<DateTime>(nullable: true),
                    TO_PERSON_TAX_NUMBER = table.Column<string>(maxLength: 100, nullable: true),
                    TO_PERSON_TAX_REG_NUMBER = table.Column<string>(maxLength: 100, nullable: true),
                    TO_PERSON_SOURCE_OF_WEALTH = table.Column<string>(maxLength: 255, nullable: true),
                    TO_PERSON_COMMENTS = table.Column<string>(maxLength: 4000, nullable: true),
                    TO_ENTITY_NAME = table.Column<string>(maxLength: 255, nullable: true),
                    TO_ENTITY_COMMERCIAL_NAME = table.Column<string>(maxLength: 255, nullable: true),
                    TO_ENTITY_INCORPORATION_LEGAL_FORM = table.Column<string>(nullable: true),
                    TO_ENTITY_INCORPORATION_NUMBER = table.Column<string>(maxLength: 50, nullable: true),
                    TO_ENTITY_BUSINESS = table.Column<string>(maxLength: 255, nullable: true),
                    TO_ENTITY_TPH_CONTACT_TYPE = table.Column<string>(nullable: true),
                    TO_ENTITY_TPH_COMMUNICATION_TYPE = table.Column<string>(nullable: true),
                    TO_ENTITY_COUNTRY_PREFIX = table.Column<string>(maxLength: 4, nullable: true),
                    TO_ENTITY_NUMBER = table.Column<string>(maxLength: 50, nullable: true),
                    TO_ENTITY_TPH_EXTENSION = table.Column<string>(maxLength: 10, nullable: true),
                    TO_ENTITY_PHONE_COMMENTS = table.Column<string>(maxLength: 4000, nullable: true),
                    TO_ENTITY_ADDRESS_TYPE = table.Column<string>(nullable: true),
                    TO_ENTITY_ADDRESS = table.Column<string>(maxLength: 100, nullable: true),
                    TO_ENTITY_TOWN = table.Column<string>(maxLength: 255, nullable: true),
                    TO_ENTITY_CITY = table.Column<string>(maxLength: 255, nullable: true),
                    TO_ENTITY_ZIP = table.Column<string>(maxLength: 10, nullable: true),
                    TO_ENTITY_COUNTRY_CODE = table.Column<string>(nullable: true),
                    TO_ENTITY_STATE = table.Column<string>(maxLength: 255, nullable: true),
                    TO_ENTITY_ADDRESS_COMMENTS = table.Column<string>(maxLength: 25, nullable: true),
                    TO_ENTITY_EMAIL = table.Column<string>(maxLength: 255, nullable: true),
                    TO_ENTITY_URL = table.Column<string>(maxLength: 255, nullable: true),
                    TO_ENTITY_INCORPORATION_STATE = table.Column<string>(maxLength: 255, nullable: true),
                    TO_ENTITY_INCORPORATION_COUNTRY_CODE = table.Column<string>(nullable: true),
                    TO_ENTITY_INCORPORATION_DATE = table.Column<DateTime>(nullable: true),
                    TO_ENTITY_BUSINESS_CLOSED = table.Column<bool>(nullable: true),
                    TO_ENTITY_DATE_BUSINESS_CLOSED = table.Column<DateTime>(nullable: true),
                    TO_ENTITY_TAX_NUMBER = table.Column<string>(maxLength: 100, nullable: true),
                    TO_ENTITY_TAX_REG_NUMBER = table.Column<string>(maxLength: 100, nullable: true),
                    TO_ENTITY_COMMENTS = table.Column<string>(maxLength: 4000, nullable: true),
                    CODE_FROM_TRANS = table.Column<string>(nullable: true),
                    DATE_GENERATED_FROM_DB = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTR", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IdentifierType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentifierType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionPersonIdentification",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TRANSACTION_NUMBER = table.Column<string>(nullable: false),
                    SIGNATORY_OR_DIRECTOR_ID = table.Column<int>(nullable: true),
                    FOR_SIGNATORY_IDENTIFICATION = table.Column<bool>(nullable: true),
                    FOR_DIRECTOR_IDENTIFICATION = table.Column<bool>(nullable: true),
                    FOR_PERSON_IDENTIFICATION = table.Column<bool>(nullable: true),
                    FOR_PERSON_SOURCE_TRANSACTION = table.Column<bool>(nullable: true),
                    FOR_PERSON_DESTINATION_TRANSACTION = table.Column<bool>(nullable: true),
                    TYPE = table.Column<string>(nullable: true),
                    NUMBER = table.Column<string>(maxLength: 255, nullable: true),
                    ISSUE_DATE = table.Column<DateTime>(nullable: true),
                    EXPIRY_DATE = table.Column<DateTime>(nullable: true),
                    ISSUED_BY = table.Column<string>(maxLength: 255, nullable: true),
                    ISSUE_COUNTRY = table.Column<string>(nullable: true),
                    COMMENTS = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionPersonIdentification", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TransactionSignatoryOrDirector",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TRANSACTION_NUMBER = table.Column<string>(nullable: false),
                    FOR_SOURCE_TRANSACTION = table.Column<bool>(nullable: true),
                    FOR_DESTINATION_TRANSACTION = table.Column<bool>(nullable: true),
                    FOR_SIGNATORY_RECORD = table.Column<bool>(nullable: true),
                    FOR_DIRECTOR_RECORD = table.Column<bool>(nullable: true),
                    GENDER = table.Column<string>(nullable: true),
                    TITLE = table.Column<string>(maxLength: 30, nullable: true),
                    FIRST_NAME = table.Column<string>(maxLength: 100, nullable: true),
                    MIDDLE_NAME = table.Column<string>(maxLength: 100, nullable: true),
                    PREFIX = table.Column<string>(maxLength: 100, nullable: true),
                    LAST_NAME = table.Column<string>(maxLength: 100, nullable: true),
                    BIRTHDATE = table.Column<DateTime>(nullable: true),
                    BIRTH_PLACE = table.Column<string>(maxLength: 255, nullable: true),
                    MOTHERS_NAME = table.Column<string>(maxLength: 100, nullable: true),
                    ALIAS = table.Column<string>(maxLength: 100, nullable: true),
                    SSN = table.Column<string>(maxLength: 25, nullable: true),
                    PASSPORT_NUMBER = table.Column<string>(maxLength: 25, nullable: true),
                    PASSPORT_COUNTRY = table.Column<string>(maxLength: 25, nullable: true),
                    ID_NUMBER = table.Column<string>(maxLength: 25, nullable: true),
                    SIGNATORY_TPH_CONTACT_TYPE = table.Column<string>(nullable: true),
                    SIGNATORY_TPH_COMMUNICATION_TYPE = table.Column<string>(nullable: true),
                    SIGNATORY_COUNTRY_PREFIX = table.Column<string>(maxLength: 4, nullable: true),
                    SIGNATORY_NUMBER = table.Column<string>(maxLength: 50, nullable: true),
                    SIGNATORY_TPH_EXTENSION = table.Column<string>(maxLength: 10, nullable: true),
                    SIGNATORY_PHONE_COMMENTS = table.Column<string>(maxLength: 4000, nullable: true),
                    SIGNATORY_ADDRESS_TYPE = table.Column<string>(nullable: true),
                    SIGNATORY_ADDRESS = table.Column<string>(maxLength: 100, nullable: true),
                    SIGNATORY_TOWN = table.Column<string>(maxLength: 255, nullable: true),
                    SIGNATORY_CITY = table.Column<string>(maxLength: 255, nullable: true),
                    SIGNATORY_ZIP = table.Column<string>(maxLength: 10, nullable: true),
                    SIGNATORY_COUNTRY_CODE = table.Column<string>(nullable: true),
                    SIGNATORY_STATE = table.Column<string>(maxLength: 255, nullable: true),
                    SIGNATORY_ADDRESS_COMMENTS = table.Column<string>(maxLength: 25, nullable: true),
                    NATIONALITY1 = table.Column<string>(nullable: true),
                    NATIONALITY2 = table.Column<string>(nullable: true),
                    NATIONALITY3 = table.Column<string>(nullable: true),
                    RESIDENCE = table.Column<string>(nullable: true),
                    EMAIL1 = table.Column<string>(nullable: true),
                    EMAIL2 = table.Column<string>(nullable: true),
                    EMAIL3 = table.Column<string>(nullable: true),
                    EMAIL4 = table.Column<string>(nullable: true),
                    EMAIL5 = table.Column<string>(nullable: true),
                    OCCUPATION = table.Column<string>(maxLength: 255, nullable: true),
                    EMPLOYER_NAME = table.Column<string>(maxLength: 255, nullable: true),
                    EMPLOYER_ADDRESS_TYPE = table.Column<string>(nullable: true),
                    EMPLOYER_ADDRESS = table.Column<string>(maxLength: 100, nullable: true),
                    EMPLOYER_TOWN = table.Column<string>(maxLength: 255, nullable: true),
                    EMPLOYER_CITY = table.Column<string>(maxLength: 255, nullable: true),
                    EMPLOYER_ZIP = table.Column<string>(maxLength: 10, nullable: true),
                    EMPLOYER_COUNTRY_CODE = table.Column<string>(nullable: true),
                    EMPLOYER_STATE = table.Column<string>(maxLength: 255, nullable: true),
                    EMPLOYER_ADDRESS_COMMENTS = table.Column<string>(maxLength: 25, nullable: true),
                    EMPLOYER_TPH_CONTACT_TYPE = table.Column<string>(nullable: true),
                    EMPLOYER_TPH_COMMUNICATION_TYPE = table.Column<string>(nullable: true),
                    EMPLOYER_COUNTRY_PREFIX = table.Column<string>(maxLength: 4, nullable: true),
                    EMPLOYER_NUMBER = table.Column<string>(maxLength: 50, nullable: true),
                    EMPLOYER_TPH_EXTENSION = table.Column<string>(maxLength: 10, nullable: true),
                    EMPLOYER_PHONE_COMMENTS = table.Column<string>(maxLength: 4000, nullable: true),
                    DECEASED = table.Column<bool>(nullable: false),
                    DECEASED_DATE = table.Column<DateTime>(nullable: true),
                    TAX_NUMBER = table.Column<string>(maxLength: 100, nullable: true),
                    TAX_REG_NUMBER = table.Column<string>(maxLength: 100, nullable: true),
                    SOURCE_OF_WEALTH = table.Column<string>(maxLength: 255, nullable: true),
                    SIGNATORY_COMMENTS = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionSignatoryOrDirector", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommunicationType");

            migrationBuilder.DropTable(
                name: "ContactType");

            migrationBuilder.DropTable(
                name: "CountryCodes");

            migrationBuilder.DropTable(
                name: "CTR");

            migrationBuilder.DropTable(
                name: "IdentifierType");

            migrationBuilder.DropTable(
                name: "TransactionPersonIdentification");

            migrationBuilder.DropTable(
                name: "TransactionSignatoryOrDirector");
        }
    }
}

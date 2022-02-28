using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CARPDataGenerator.Data.Migrations
{
    public partial class loadctr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FOREIGN_AMOUNT",
                table: "CTR");

            migrationBuilder.DropColumn(
                name: "FOREIGN_CURRENCY",
                table: "CTR");

            migrationBuilder.DropColumn(
                name: "FOREIGN_EX_RATE",
                table: "CTR");

            migrationBuilder.DropColumn(
                name: "FROM_FOREIGN_CURRENCY",
                table: "CTR");

            migrationBuilder.DropColumn(
                name: "TO_FOREIGN_CURRENCY",
                table: "CTR");

            migrationBuilder.DropColumn(
                name: "TRANSACTION_MODE",
                table: "CTR");

            migrationBuilder.AlterColumn<string>(
                name: "TRANSACTION_NUMBER",
                table: "CTR",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TRANSACTION_LOCATION",
                table: "CTR",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TRANSACTION_DESCRIPTION",
                table: "CTR",
                maxLength: 4000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "TO_PERSON_DECEASED",
                table: "CTR",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "TO_CLIENT_NUMBER",
                table: "CTR",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TELLER",
                table: "CTR",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "LATE_DEPOSIT",
                table: "CTR",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "FROM_CLIENT_NUMBER",
                table: "CTR",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "DECEASED",
                table: "CTR",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "AUTHORIZED",
                table: "CTR",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FROM_COUNTRY",
                table: "CTR",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FROM_FOREIGN_AMOUNT",
                table: "CTR",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FROM_FOREIGN_CURRENCY_CODE",
                table: "CTR",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FROM_FOREIGN_EXCHANGE_RATE",
                table: "CTR",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TO_COUNTRY_CODE",
                table: "CTR",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TO_FOREIGN_AMOUNT",
                table: "CTR",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TO_FOREIGN_CURRENCY_CODE",
                table: "CTR",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TO_FOREIGN_EXCHANGE_RATE",
                table: "CTR",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TRANSACTION_MODE_CODE",
                table: "CTR",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TRANSACTION_MODE_COMMENT",
                table: "CTR",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VALUE_DATE",
                table: "CTR",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FROM_COUNTRY",
                table: "CTR");

            migrationBuilder.DropColumn(
                name: "FROM_FOREIGN_AMOUNT",
                table: "CTR");

            migrationBuilder.DropColumn(
                name: "FROM_FOREIGN_CURRENCY_CODE",
                table: "CTR");

            migrationBuilder.DropColumn(
                name: "FROM_FOREIGN_EXCHANGE_RATE",
                table: "CTR");

            migrationBuilder.DropColumn(
                name: "TO_COUNTRY_CODE",
                table: "CTR");

            migrationBuilder.DropColumn(
                name: "TO_FOREIGN_AMOUNT",
                table: "CTR");

            migrationBuilder.DropColumn(
                name: "TO_FOREIGN_CURRENCY_CODE",
                table: "CTR");

            migrationBuilder.DropColumn(
                name: "TO_FOREIGN_EXCHANGE_RATE",
                table: "CTR");

            migrationBuilder.DropColumn(
                name: "TRANSACTION_MODE_CODE",
                table: "CTR");

            migrationBuilder.DropColumn(
                name: "TRANSACTION_MODE_COMMENT",
                table: "CTR");

            migrationBuilder.DropColumn(
                name: "VALUE_DATE",
                table: "CTR");

            migrationBuilder.AlterColumn<string>(
                name: "TRANSACTION_NUMBER",
                table: "CTR",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TRANSACTION_LOCATION",
                table: "CTR",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TRANSACTION_DESCRIPTION",
                table: "CTR",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 4000,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "TO_PERSON_DECEASED",
                table: "CTR",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TO_CLIENT_NUMBER",
                table: "CTR",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TELLER",
                table: "CTR",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "LATE_DEPOSIT",
                table: "CTR",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FROM_CLIENT_NUMBER",
                table: "CTR",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "DECEASED",
                table: "CTR",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AUTHORIZED",
                table: "CTR",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FOREIGN_AMOUNT",
                table: "CTR",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FOREIGN_CURRENCY",
                table: "CTR",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FOREIGN_EX_RATE",
                table: "CTR",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FROM_FOREIGN_CURRENCY",
                table: "CTR",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TO_FOREIGN_CURRENCY",
                table: "CTR",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TRANSACTION_MODE",
                table: "CTR",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

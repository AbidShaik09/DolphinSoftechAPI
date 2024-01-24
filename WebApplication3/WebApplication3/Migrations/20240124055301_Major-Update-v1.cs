using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegisterationAPI.Migrations
{
    /// <inheritdoc />
    public partial class MajorUpdatev1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "username",
                table: "reports",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "pincode",
                table: "reports",
                newName: "Pincode");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "reports",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "reports",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "designation",
                table: "reports",
                newName: "Designation");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "reports",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "accountNumber",
                table: "reports",
                newName: "AccountNumber");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "reports",
                newName: "State");

            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "reports",
                type: "nvarchar(600)",
                maxLength: 600,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "BirthDay",
                table: "reports",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "reports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EID",
                table: "reports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "reports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "JoinDate",
                table: "reports",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<long>(
                name: "PhoneNumber",
                table: "reports",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bio",
                table: "reports");

            migrationBuilder.DropColumn(
                name: "BirthDay",
                table: "reports");

            migrationBuilder.DropColumn(
                name: "City",
                table: "reports");

            migrationBuilder.DropColumn(
                name: "EID",
                table: "reports");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "reports");

            migrationBuilder.DropColumn(
                name: "JoinDate",
                table: "reports");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "reports");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "reports",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Pincode",
                table: "reports",
                newName: "pincode");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "reports",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "reports",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Designation",
                table: "reports",
                newName: "designation");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "reports",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "AccountNumber",
                table: "reports",
                newName: "accountNumber");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "reports",
                newName: "phone");
        }
    }
}

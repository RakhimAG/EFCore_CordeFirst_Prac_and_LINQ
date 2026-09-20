using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_CordeFirst_Prac.Migrations
{
    /// <inheritdoc />
    public partial class onDateOfBirthFixedDefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateOfBirth",
                table: "StudentProfiles",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldDefaultValueSql: "CAST(GETDATE() AS date)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateOfBirth",
                table: "StudentProfiles",
                type: "date",
                nullable: false,
                defaultValueSql: "CAST(GETDATE() AS date)",
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    public partial class Log : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "users",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 13, 34, 48, 371, DateTimeKind.Local).AddTicks(2322),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2022, 9, 6, 12, 49, 41, 299, DateTimeKind.Local).AddTicks(5542));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "lessons",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 13, 34, 48, 375, DateTimeKind.Local).AddTicks(8446),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2022, 9, 6, 12, 49, 41, 302, DateTimeKind.Local).AddTicks(2138));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "courses",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 13, 34, 48, 373, DateTimeKind.Local).AddTicks(6586),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2022, 9, 6, 12, 49, 41, 301, DateTimeKind.Local).AddTicks(2804));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "users",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 12, 49, 41, 299, DateTimeKind.Local).AddTicks(5542),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2022, 9, 6, 13, 34, 48, 371, DateTimeKind.Local).AddTicks(2322));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "lessons",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 12, 49, 41, 302, DateTimeKind.Local).AddTicks(2138),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2022, 9, 6, 13, 34, 48, 375, DateTimeKind.Local).AddTicks(8446));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "courses",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 12, 49, 41, 301, DateTimeKind.Local).AddTicks(2804),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2022, 9, 6, 13, 34, 48, 373, DateTimeKind.Local).AddTicks(6586));
        }
    }
}

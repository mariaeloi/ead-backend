using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    public partial class SemUnicidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_lessons_link",
                table: "lessons");

            migrationBuilder.DropIndex(
                name: "IX_courses_title",
                table: "courses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "users",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 11, 16, 15, 16, 33, DateTimeKind.Local).AddTicks(9160),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2022, 9, 6, 12, 49, 41, 299, DateTimeKind.Local).AddTicks(5542));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "lessons",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 11, 16, 15, 16, 35, DateTimeKind.Local).AddTicks(3220),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2022, 9, 6, 12, 49, 41, 302, DateTimeKind.Local).AddTicks(2138));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "courses",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 11, 16, 15, 16, 34, DateTimeKind.Local).AddTicks(8840),
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
                oldDefaultValue: new DateTime(2022, 9, 11, 16, 15, 16, 33, DateTimeKind.Local).AddTicks(9160));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "lessons",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 12, 49, 41, 302, DateTimeKind.Local).AddTicks(2138),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2022, 9, 11, 16, 15, 16, 35, DateTimeKind.Local).AddTicks(3220));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "courses",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 12, 49, 41, 301, DateTimeKind.Local).AddTicks(2804),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2022, 9, 11, 16, 15, 16, 34, DateTimeKind.Local).AddTicks(8840));

            migrationBuilder.CreateIndex(
                name: "IX_lessons_link",
                table: "lessons",
                column: "link",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_courses_title",
                table: "courses",
                column: "title",
                unique: true);
        }
    }
}

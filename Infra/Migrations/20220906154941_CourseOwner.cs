using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    public partial class CourseOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CousersUsers_courses_CoursesId",
                table: "CousersUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CousersUsers_users_UsersId",
                table: "CousersUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CousersUsers",
                table: "CousersUsers");

            migrationBuilder.RenameTable(
                name: "CousersUsers",
                newName: "CousersStudents");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "CousersStudents",
                newName: "StudentsId");

            migrationBuilder.RenameIndex(
                name: "IX_CousersUsers_UsersId",
                table: "CousersStudents",
                newName: "IX_CousersStudents_StudentsId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "users",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 12, 49, 41, 299, DateTimeKind.Local).AddTicks(5542),
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AlterColumn<bool>(
                name: "active",
                table: "users",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "lessons",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 12, 49, 41, 302, DateTimeKind.Local).AddTicks(2138),
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AlterColumn<bool>(
                name: "active",
                table: "lessons",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "courses",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 12, 49, 41, 301, DateTimeKind.Local).AddTicks(2804),
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AlterColumn<bool>(
                name: "active",
                table: "courses",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AddColumn<long>(
                name: "OwnerId",
                table: "courses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CousersStudents",
                table: "CousersStudents",
                columns: new[] { "CoursesId", "StudentsId" });

            migrationBuilder.CreateIndex(
                name: "IX_courses_OwnerId",
                table: "courses",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_users_OwnerId",
                table: "courses",
                column: "OwnerId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CousersStudents_courses_CoursesId",
                table: "CousersStudents",
                column: "CoursesId",
                principalTable: "courses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CousersStudents_users_StudentsId",
                table: "CousersStudents",
                column: "StudentsId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_users_OwnerId",
                table: "courses");

            migrationBuilder.DropForeignKey(
                name: "FK_CousersStudents_courses_CoursesId",
                table: "CousersStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_CousersStudents_users_StudentsId",
                table: "CousersStudents");

            migrationBuilder.DropIndex(
                name: "IX_courses_OwnerId",
                table: "courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CousersStudents",
                table: "CousersStudents");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "courses");

            migrationBuilder.RenameTable(
                name: "CousersStudents",
                newName: "CousersUsers");

            migrationBuilder.RenameColumn(
                name: "StudentsId",
                table: "CousersUsers",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_CousersStudents_StudentsId",
                table: "CousersUsers",
                newName: "IX_CousersUsers_UsersId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "users",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2022, 9, 6, 12, 49, 41, 299, DateTimeKind.Local).AddTicks(5542));

            migrationBuilder.AlterColumn<bool>(
                name: "active",
                table: "users",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "lessons",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2022, 9, 6, 12, 49, 41, 302, DateTimeKind.Local).AddTicks(2138));

            migrationBuilder.AlterColumn<bool>(
                name: "active",
                table: "lessons",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "courses",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2022, 9, 6, 12, 49, 41, 301, DateTimeKind.Local).AddTicks(2804));

            migrationBuilder.AlterColumn<bool>(
                name: "active",
                table: "courses",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CousersUsers",
                table: "CousersUsers",
                columns: new[] { "CoursesId", "UsersId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CousersUsers_courses_CoursesId",
                table: "CousersUsers",
                column: "CoursesId",
                principalTable: "courses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CousersUsers_users_UsersId",
                table: "CousersUsers",
                column: "UsersId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

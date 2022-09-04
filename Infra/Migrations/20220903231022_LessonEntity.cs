using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    public partial class LessonEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_courses_CourseId",
                table: "Lesson");

            migrationBuilder.DropForeignKey(
                name: "FK_users_courses_CourseId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_CourseId",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lesson",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "users");

            migrationBuilder.RenameTable(
                name: "Lesson",
                newName: "lessons");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "lessons",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "lessons",
                newName: "order");

            migrationBuilder.RenameColumn(
                name: "Link",
                table: "lessons",
                newName: "link");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "lessons",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "lessons",
                newName: "active");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "lessons",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "lessons",
                newName: "updated_on");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "lessons",
                newName: "created_on");

            migrationBuilder.RenameIndex(
                name: "IX_Lesson_CourseId",
                table: "lessons",
                newName: "IX_lessons_CourseId");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "lessons",
                type: "varchar",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "order",
                table: "lessons",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "link",
                table: "lessons",
                type: "varchar",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "lessons",
                type: "varchar",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CourseId",
                table: "lessons",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_on",
                table: "lessons",
                type: "timestamp",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "lessons",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_lessons",
                table: "lessons",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_lessons_link",
                table: "lessons",
                column: "link",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Course_CourseID",
                table: "lessons",
                column: "CourseId",
                principalTable: "courses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Course_CourseID",
                table: "lessons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_lessons",
                table: "lessons");

            migrationBuilder.DropIndex(
                name: "IX_lessons_link",
                table: "lessons");

            migrationBuilder.RenameTable(
                name: "lessons",
                newName: "Lesson");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Lesson",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "order",
                table: "Lesson",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "link",
                table: "Lesson",
                newName: "Link");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Lesson",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "active",
                table: "Lesson",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Lesson",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_on",
                table: "Lesson",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "created_on",
                table: "Lesson",
                newName: "CreatedOn");

            migrationBuilder.RenameIndex(
                name: "IX_lessons_CourseId",
                table: "Lesson",
                newName: "IX_Lesson_CourseId");

            migrationBuilder.AddColumn<long>(
                name: "CourseId",
                table: "users",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Lesson",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Order",
                table: "Lesson",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "Lesson",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Lesson",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CourseId",
                table: "Lesson",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                table: "Lesson",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Lesson",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lesson",
                table: "Lesson",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_users_CourseId",
                table: "users",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_courses_CourseId",
                table: "Lesson",
                column: "CourseId",
                principalTable: "courses",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_courses_CourseId",
                table: "users",
                column: "CourseId",
                principalTable: "courses",
                principalColumn: "id");
        }
    }
}

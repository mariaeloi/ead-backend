using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infra.Migrations
{
    public partial class Relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "varchar", maxLength: 150, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp", nullable: false),
                    updated_on = table.Column<DateTime>(type: "timestamp", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    username = table.Column<string>(type: "varchar", maxLength: 15, nullable: false),
                    password = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    role = table.Column<string>(type: "varchar", maxLength: 10, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp", nullable: false),
                    updated_on = table.Column<DateTime>(type: "timestamp", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "lessons",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    link = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "varchar", maxLength: 150, nullable: true),
                    order = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp", nullable: false),
                    updated_on = table.Column<DateTime>(type: "timestamp", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lessons", x => x.id);
                    table.ForeignKey(
                        name: "FK_Lesson_Course_CourseID",
                        column: x => x.CourseId,
                        principalTable: "courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CousersUsers",
                columns: table => new
                {
                    CoursesId = table.Column<long>(type: "bigint", nullable: false),
                    UsersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CousersUsers", x => new { x.CoursesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_CousersUsers_courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CousersUsers_users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_courses_title",
                table: "courses",
                column: "title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CousersUsers_UsersId",
                table: "CousersUsers",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_lessons_CourseId",
                table: "lessons",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_lessons_link",
                table: "lessons",
                column: "link",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_email",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_username",
                table: "users",
                column: "username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CousersUsers");

            migrationBuilder.DropTable(
                name: "lessons");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "courses");
        }
    }
}

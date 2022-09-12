using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infra.Migrations
{
    public partial class LogFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "users",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 21, 27, 59, 408, DateTimeKind.Local).AddTicks(9975),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2022, 9, 6, 13, 34, 48, 371, DateTimeKind.Local).AddTicks(2322));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "lessons",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 21, 27, 59, 418, DateTimeKind.Local).AddTicks(6623),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2022, 9, 6, 13, 34, 48, 375, DateTimeKind.Local).AddTicks(8446));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "courses",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 21, 27, 59, 414, DateTimeKind.Local).AddTicks(6095),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2022, 9, 6, 13, 34, 48, 373, DateTimeKind.Local).AddTicks(6586));

            migrationBuilder.CreateTable(
                name: "logs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    action = table.Column<string>(type: "varchar", maxLength: 15, nullable: false),
                    entity_name = table.Column<string>(type: "varchar", maxLength: 10, nullable: false),
                    entity_id = table.Column<long>(type: "bigint", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValue: new DateTime(2022, 9, 6, 21, 27, 59, 427, DateTimeKind.Local).AddTicks(9306))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logs", x => x.id);
                    table.ForeignKey(
                        name: "FK_logs_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_logs_UserId",
                table: "logs",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "logs");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "users",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 13, 34, 48, 371, DateTimeKind.Local).AddTicks(2322),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2022, 9, 6, 21, 27, 59, 408, DateTimeKind.Local).AddTicks(9975));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "lessons",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 13, 34, 48, 375, DateTimeKind.Local).AddTicks(8446),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2022, 9, 6, 21, 27, 59, 418, DateTimeKind.Local).AddTicks(6623));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "courses",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 13, 34, 48, 373, DateTimeKind.Local).AddTicks(6586),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2022, 9, 6, 21, 27, 59, 414, DateTimeKind.Local).AddTicks(6095));
        }
    }
}

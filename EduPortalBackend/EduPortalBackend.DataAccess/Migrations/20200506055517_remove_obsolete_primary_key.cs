using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class remove_obsolete_primary_key : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCourses",
                table: "UserCourses");

            migrationBuilder.DropIndex(
                name: "IX_UserCourses_CourseId",
                table: "UserCourses");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserCourses");

            migrationBuilder.DropColumn(
                name: "CraetedDate",
                table: "Materials");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Materials",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCourses",
                table: "UserCourses",
                columns: new[] { "CourseId", "UserId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCourses",
                table: "UserCourses");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Materials");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "UserCourses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CraetedDate",
                table: "Materials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCourses",
                table: "UserCourses",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourses_CourseId",
                table: "UserCourses",
                column: "CourseId");
        }
    }
}

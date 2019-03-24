using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class dbusereklendiplacesusercreatedateeklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "places",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "createdAtTime",
                table: "places",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_places_UserID",
                table: "places",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_places_User_UserID",
                table: "places",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_places_User_UserID",
                table: "places");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_places_UserID",
                table: "places");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "places");

            migrationBuilder.DropColumn(
                name: "createdAtTime",
                table: "places");
        }
    }
}

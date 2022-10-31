using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminApi.Migrations
{
    public partial class homeworklogic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Homeworks",
                columns: table => new
                {
                    HomeWorkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    ChapterId = table.Column<int>(type: "int", nullable: false),
                    FilePath = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Notes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homeworks", x => x.HomeWorkId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(5471));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(5474));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(5476));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(5477));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(5478));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(5479));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(5481));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(5482));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(5483));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(5484));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(3485));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(3496));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(5939));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(5941));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(5942));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(5943));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(5943));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(5944));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(5945));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(5946));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(5947));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(5948));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(4034));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(4037));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(4038));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(4039));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(4040));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(4041));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(4042));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(4043));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(4044));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(4045));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 11,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(4045));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 12,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(4046));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 13,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(4047));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 14,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(4048));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 15,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(4050));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(4798));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 10, 58, 29, 747, DateTimeKind.Local).AddTicks(4803));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Homeworks");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 617, DateTimeKind.Local).AddTicks(1097));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 617, DateTimeKind.Local).AddTicks(1101));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 617, DateTimeKind.Local).AddTicks(1102));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 617, DateTimeKind.Local).AddTicks(1104));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 617, DateTimeKind.Local).AddTicks(1105));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 617, DateTimeKind.Local).AddTicks(1106));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 617, DateTimeKind.Local).AddTicks(1107));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 617, DateTimeKind.Local).AddTicks(1108));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 617, DateTimeKind.Local).AddTicks(1109));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 617, DateTimeKind.Local).AddTicks(1110));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 616, DateTimeKind.Local).AddTicks(9464));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 616, DateTimeKind.Local).AddTicks(9474));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 617, DateTimeKind.Local).AddTicks(1432));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 617, DateTimeKind.Local).AddTicks(1434));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 617, DateTimeKind.Local).AddTicks(1435));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 617, DateTimeKind.Local).AddTicks(1436));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 617, DateTimeKind.Local).AddTicks(1437));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 617, DateTimeKind.Local).AddTicks(1438));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 617, DateTimeKind.Local).AddTicks(1439));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 617, DateTimeKind.Local).AddTicks(1441));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 617, DateTimeKind.Local).AddTicks(1442));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 617, DateTimeKind.Local).AddTicks(1443));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 616, DateTimeKind.Local).AddTicks(9906));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 616, DateTimeKind.Local).AddTicks(9909));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 616, DateTimeKind.Local).AddTicks(9910));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 616, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 616, DateTimeKind.Local).AddTicks(9912));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 616, DateTimeKind.Local).AddTicks(9913));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 616, DateTimeKind.Local).AddTicks(9914));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 616, DateTimeKind.Local).AddTicks(9915));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 616, DateTimeKind.Local).AddTicks(9916));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 616, DateTimeKind.Local).AddTicks(9918));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 11,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 616, DateTimeKind.Local).AddTicks(9919));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 12,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 616, DateTimeKind.Local).AddTicks(9920));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 13,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 616, DateTimeKind.Local).AddTicks(9921));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 14,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 616, DateTimeKind.Local).AddTicks(9922));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 15,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 616, DateTimeKind.Local).AddTicks(9923));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 617, DateTimeKind.Local).AddTicks(510));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 9, 22, 6, 36, 617, DateTimeKind.Local).AddTicks(553));
        }
    }
}

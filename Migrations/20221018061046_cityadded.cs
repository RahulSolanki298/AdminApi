using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminApi.Migrations
{
    public partial class cityadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CityName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.CityId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 556, DateTimeKind.Local).AddTicks(515));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 556, DateTimeKind.Local).AddTicks(520));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 556, DateTimeKind.Local).AddTicks(522));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 556, DateTimeKind.Local).AddTicks(523));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 556, DateTimeKind.Local).AddTicks(527));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 556, DateTimeKind.Local).AddTicks(530));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 556, DateTimeKind.Local).AddTicks(533));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 556, DateTimeKind.Local).AddTicks(538));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 556, DateTimeKind.Local).AddTicks(540));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 556, DateTimeKind.Local).AddTicks(542));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 555, DateTimeKind.Local).AddTicks(7225));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 555, DateTimeKind.Local).AddTicks(7238));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 556, DateTimeKind.Local).AddTicks(1135));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 556, DateTimeKind.Local).AddTicks(1138));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 556, DateTimeKind.Local).AddTicks(1140));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 556, DateTimeKind.Local).AddTicks(1141));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 556, DateTimeKind.Local).AddTicks(1143));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 556, DateTimeKind.Local).AddTicks(1144));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 556, DateTimeKind.Local).AddTicks(1146));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 556, DateTimeKind.Local).AddTicks(1147));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 556, DateTimeKind.Local).AddTicks(1149));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 556, DateTimeKind.Local).AddTicks(1150));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 555, DateTimeKind.Local).AddTicks(8171));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 555, DateTimeKind.Local).AddTicks(8175));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 555, DateTimeKind.Local).AddTicks(8177));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 555, DateTimeKind.Local).AddTicks(8178));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 555, DateTimeKind.Local).AddTicks(8180));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 555, DateTimeKind.Local).AddTicks(8181));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 555, DateTimeKind.Local).AddTicks(8183));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 555, DateTimeKind.Local).AddTicks(8184));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 555, DateTimeKind.Local).AddTicks(8186));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 555, DateTimeKind.Local).AddTicks(8187));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 11,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 555, DateTimeKind.Local).AddTicks(8188));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 12,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 555, DateTimeKind.Local).AddTicks(8190));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 13,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 555, DateTimeKind.Local).AddTicks(8191));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 14,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 555, DateTimeKind.Local).AddTicks(8193));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 15,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 555, DateTimeKind.Local).AddTicks(8195));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 555, DateTimeKind.Local).AddTicks(9389));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 18, 11, 40, 45, 555, DateTimeKind.Local).AddTicks(9456));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(3009));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(3014));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(3020));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(3021));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(3023));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(3024));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(3027));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(3028));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(3030));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(3031));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 509, DateTimeKind.Local).AddTicks(9456));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 509, DateTimeKind.Local).AddTicks(9466));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(3895));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(3900));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(3901));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(3902));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(3903));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(3904));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(3905));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(3906));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(3907));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(3908));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(489));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(494));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(495));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(497));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(498));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(499));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(501));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(503));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(504));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(505));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 11,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(506));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 12,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(507));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 13,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(508));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 14,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(509));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 15,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(511));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(2027));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 17, 9, 43, 5, 510, DateTimeKind.Local).AddTicks(2035));
        }
    }
}

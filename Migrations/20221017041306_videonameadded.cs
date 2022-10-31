using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminApi.Migrations
{
    public partial class videonameadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VideoName",
                table: "Videos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateIndex(
                name: "IX_eBook_ClassMasterId",
                table: "eBook",
                column: "ClassMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_eBook_SubjectId",
                table: "eBook",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_eBook_TeachingMediumId",
                table: "eBook",
                column: "TeachingMediumId");

            migrationBuilder.AddForeignKey(
                name: "FK_eBook_ClassMasters_ClassMasterId",
                table: "eBook",
                column: "ClassMasterId",
                principalTable: "ClassMasters",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_eBook_Subjects_SubjectId",
                table: "eBook",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_eBook_TeachingMedium_TeachingMediumId",
                table: "eBook",
                column: "TeachingMediumId",
                principalTable: "TeachingMedium",
                principalColumn: "TeachingMediumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_eBook_ClassMasters_ClassMasterId",
                table: "eBook");

            migrationBuilder.DropForeignKey(
                name: "FK_eBook_Subjects_SubjectId",
                table: "eBook");

            migrationBuilder.DropForeignKey(
                name: "FK_eBook_TeachingMedium_TeachingMediumId",
                table: "eBook");

            migrationBuilder.DropIndex(
                name: "IX_eBook_ClassMasterId",
                table: "eBook");

            migrationBuilder.DropIndex(
                name: "IX_eBook_SubjectId",
                table: "eBook");

            migrationBuilder.DropIndex(
                name: "IX_eBook_TeachingMediumId",
                table: "eBook");

            migrationBuilder.DropColumn(
                name: "VideoName",
                table: "Videos");

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
    }
}

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminApi.Migrations
{
    public partial class videos_cate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TeachingMedia",
                table: "TeachingMedia");

            migrationBuilder.RenameTable(
                name: "TeachingMedia",
                newName: "TeachingMedium");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeachingMedium",
                table: "TeachingMedium",
                column: "TeachingMediumId");

            migrationBuilder.CreateTable(
                name: "VideoCategories",
                columns: table => new
                {
                    VideoCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VideoCategoryName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoCategories", x => x.VideoCategoryId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    VideoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VideoCategoryId = table.Column<int>(type: "int", nullable: false),
                    VideoPath = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VideoThumbnail = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.VideoId);
                    table.ForeignKey(
                        name: "FK_Videos_VideoCategories_VideoCategoryId",
                        column: x => x.VideoCategoryId,
                        principalTable: "VideoCategories",
                        principalColumn: "VideoCategoryId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateIndex(
                name: "IX_SubSubjects_SubjectId",
                table: "SubSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_eBookChapter_eBookId",
                table: "eBookChapter",
                column: "eBookId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_VideoCategoryId",
                table: "Videos",
                column: "VideoCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_eBookChapter_eBook_eBookId",
                table: "eBookChapter",
                column: "eBookId",
                principalTable: "eBook",
                principalColumn: "eBookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubSubjects_Subjects_SubjectId",
                table: "SubSubjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_eBookChapter_eBook_eBookId",
                table: "eBookChapter");

            migrationBuilder.DropForeignKey(
                name: "FK_SubSubjects_Subjects_SubjectId",
                table: "SubSubjects");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "VideoCategories");

            migrationBuilder.DropIndex(
                name: "IX_SubSubjects_SubjectId",
                table: "SubSubjects");

            migrationBuilder.DropIndex(
                name: "IX_eBookChapter_eBookId",
                table: "eBookChapter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeachingMedium",
                table: "TeachingMedium");

            migrationBuilder.RenameTable(
                name: "TeachingMedium",
                newName: "TeachingMedia");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeachingMedia",
                table: "TeachingMedia",
                column: "TeachingMediumId");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(4886));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(4889));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(4890));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(4891));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(4893));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(4894));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(4896));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(4899));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(4901));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(4902));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(3089));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(3100));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(5270));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(5273));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(5274));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(5275));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(5276));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(5277));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(5278));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(5279));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(5280));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(5281));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(3572));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(3574));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(3575));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(3576));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(3578));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(3582));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(3583));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(3584));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(3586));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 11,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(3587));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 12,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(3587));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 13,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(3588));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 14,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(3591));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 15,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(3594));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(4318));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 5, 13, 50, 50, 329, DateTimeKind.Local).AddTicks(4321));
        }
    }
}

using System;
using AdminApi.Helpers;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LogHistory",
                columns: table => new
                {
                    LogId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LogCode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LogDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LogInTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LogOutTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogHistory", x => x.LogId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    MenuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ParentID = table.Column<int>(type: "int", nullable: false),
                    MenuTitle = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    URL = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsSubMenu = table.Column<int>(type: "int", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    IconClass = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AddedBy = table.Column<int>(type: "int", nullable: false),
                    IsMigrationData = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.MenuID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MenuGroup",
                columns: table => new
                {
                    MenuGroupID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MenuGroupName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AddedBy = table.Column<int>(type: "int", nullable: false),
                    IsMigrationData = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuGroup", x => x.MenuGroupID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MenuGroupWiseMenuMapping",
                columns: table => new
                {
                    MenuGroupWiseMenuMappingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MenuGroupId = table.Column<int>(type: "int", nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsMigrationData = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AddedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuGroupWiseMenuMapping", x => x.MenuGroupWiseMenuMappingId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleDesc = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MenuGroupId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AddedBy = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsMigrationData = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.UserRoleId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserRoleId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mobile = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ImagePath = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AddedBy = table.Column<int>(type: "int", nullable: false),
                    IsMigrationData = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastPasswordChangeDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PasswordChangedBy = table.Column<int>(type: "int", nullable: true),
                    IsPasswordChange = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "MenuID", "AddedBy", "DateAdded", "IconClass", "IsActive", "IsMigrationData", "IsSubMenu", "LastUpdatedBy", "LastUpdatedDate", "MenuTitle", "ParentID", "SortOrder", "URL" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 10, 1, 8, 25, 1, 111, DateTimeKind.Local).AddTicks(3348), "fas fa-home", true, true, 0, null, null, "Dashboard", 0, 1, "/DashBoard/Index" },
                    { 2, 1, new DateTime(2022, 10, 1, 8, 25, 1, 111, DateTimeKind.Local).AddTicks(3351), "fas fa-ellipsis-v", true, true, 1, null, null, "Menu", 0, 2, "" },
                    { 3, 1, new DateTime(2022, 10, 1, 8, 25, 1, 111, DateTimeKind.Local).AddTicks(3353), "", true, true, 0, null, null, "Menu List", 2, 0, "/Menu/MenuList" },
                    { 4, 1, new DateTime(2022, 10, 1, 8, 25, 1, 111, DateTimeKind.Local).AddTicks(3354), "", true, true, 0, null, null, "Menu Group List", 2, 0, "/Menu/MenuGroupList" },
                    { 5, 1, new DateTime(2022, 10, 1, 8, 25, 1, 111, DateTimeKind.Local).AddTicks(3356), "fas fa-user", true, true, 1, null, null, "User", 0, 3, "" },
                    { 6, 1, new DateTime(2022, 10, 1, 8, 25, 1, 111, DateTimeKind.Local).AddTicks(3358), "", true, true, 0, null, null, "User List", 5, 0, "/User/UserList" },
                    { 7, 1, new DateTime(2022, 10, 1, 8, 25, 1, 111, DateTimeKind.Local).AddTicks(3359), "", true, true, 0, null, null, "Role List", 5, 0, "/User/RoleList" },
                    { 8, 1, new DateTime(2022, 10, 1, 8, 25, 1, 111, DateTimeKind.Local).AddTicks(3360), "", true, true, 0, null, null, "Profile", 5, 0, "/User/UserProfile" },
                    { 9, 1, new DateTime(2022, 10, 1, 8, 25, 1, 111, DateTimeKind.Local).AddTicks(3361), "fas fa-wrench", true, true, 1, null, null, "Settings", 0, 4, "" },
                    { 10, 1, new DateTime(2022, 10, 1, 8, 25, 1, 111, DateTimeKind.Local).AddTicks(3362), "", true, true, 0, null, null, "Change Password", 9, 0, "/User/ChangePassword" }
                });

            migrationBuilder.InsertData(
                table: "MenuGroup",
                columns: new[] { "MenuGroupID", "AddedBy", "DateAdded", "IsActive", "IsMigrationData", "LastUpdatedBy", "LastUpdatedDate", "MenuGroupName" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 10, 1, 8, 25, 1, 111, DateTimeKind.Local).AddTicks(1852), true, true, null, null, "Super Admin Group" },
                    { 2, 1, new DateTime(2022, 10, 1, 8, 25, 1, 111, DateTimeKind.Local).AddTicks(1862), true, true, null, null, "User Group" }
                });

            migrationBuilder.InsertData(
                table: "MenuGroupWiseMenuMapping",
                columns: new[] { "MenuGroupWiseMenuMappingId", "AddedBy", "DateAdded", "IsActive", "IsMigrationData", "MenuGroupId", "MenuId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 10, 1, 8, 25, 1, 111, DateTimeKind.Local).AddTicks(3675), true, true, 1, 1 },
                    { 2, 1, new DateTime(2022, 10, 1, 8, 25, 1, 111, DateTimeKind.Local).AddTicks(3677), true, true, 1, 3 },
                    { 3, 1, new DateTime(2022, 10, 1, 8, 25, 1, 111, DateTimeKind.Local).AddTicks(3678), true, true, 1, 4 },
                    { 4, 1, new DateTime(2022, 10, 1, 8, 25, 1, 111, DateTimeKind.Local).AddTicks(3679), true, true, 1, 6 },
                    { 5, 1, new DateTime(2022, 10, 1, 8, 25, 1, 111, DateTimeKind.Local).AddTicks(3680), true, true, 1, 7 },
                    { 6, 1, new DateTime(2022, 10, 1, 8, 25, 1, 111, DateTimeKind.Local).AddTicks(3681), true, true, 1, 8 },
                    { 7, 1, new DateTime(2022, 10, 1, 8, 25, 1, 111, DateTimeKind.Local).AddTicks(3682), true, true, 1, 10 },
                    { 8, 1, new DateTime(2022, 10, 1, 8, 25, 1, 111, DateTimeKind.Local).AddTicks(3683), true, true, 2, 1 },
                    { 9, 1, new DateTime(2022, 10, 1, 8, 25, 1, 111, DateTimeKind.Local).AddTicks(3683), true, true, 2, 8 },
                    { 10, 1, new DateTime(2022, 10, 1, 8, 25, 1, 111, DateTimeKind.Local).AddTicks(3684), true, true, 2, 10 }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserRoleId", "AddedBy", "DateAdded", "IsActive", "IsMigrationData", "LastUpdatedBy", "LastUpdatedDate", "MenuGroupId", "RoleDesc", "RoleName" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 10, 1, 8, 25, 1, 111, DateTimeKind.Local).AddTicks(2266), true, true, null, null, 1, null, "Admin" },
                    { 2, 1, new DateTime(2022, 10, 1, 8, 25, 1, 111, DateTimeKind.Local).AddTicks(2268), true, true, null, null, 2, null, "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "AddedBy", "DateAdded", "DateOfBirth", "Email", "FullName", "ImagePath", "IsActive", "IsMigrationData", "IsPasswordChange", "LastPasswordChangeDate", "LastUpdatedBy", "LastUpdatedDate", "Mobile", "Password", "PasswordChangedBy", "UserName", "UserRoleId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 10, 1, 8, 25, 1, 111, DateTimeKind.Local).AddTicks(2817), null, null, "John Doe", null, true, true, false, null, null, null, null, DataEncript.ConvertToEncrypt("admin@2020"), null, "admin@2020", 1 },
                    { 2, 1, new DateTime(2022, 10, 1, 8, 25, 1, 111, DateTimeKind.Local).AddTicks(2820), null, null, "Helen Smith", null, true, true, false, null, null, null, null, DataEncript.ConvertToEncrypt("user@2020"), null, "user@2020", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogHistory");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "MenuGroup");

            migrationBuilder.DropTable(
                name: "MenuGroupWiseMenuMapping");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

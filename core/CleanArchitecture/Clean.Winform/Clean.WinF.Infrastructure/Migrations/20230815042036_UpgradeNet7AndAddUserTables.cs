using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clean.WinF.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpgradeNet7AndAddUserTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "masterdatas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_threads",
                table: "threads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_suppliers",
                table: "suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_settings",
                table: "settings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_reports",
                table: "reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_protocols",
                table: "protocols");

            migrationBuilder.DropPrimaryKey(
                name: "PK_parts",
                table: "parts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orders",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_languages",
                table: "languages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_computers",
                table: "computers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bobbins",
                table: "bobbins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_articles",
                table: "articles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_app_group_gui_definitions",
                table: "app_group_gui_definitions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_app_definitions",
                table: "app_definitions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_app_code_gui_definitions",
                table: "app_code_gui_definitions");

            migrationBuilder.RenameTable(
                name: "threads",
                newName: "Thread");

            migrationBuilder.RenameTable(
                name: "suppliers",
                newName: "Supplier");

            migrationBuilder.RenameTable(
                name: "settings",
                newName: "Setting");

            migrationBuilder.RenameTable(
                name: "reports",
                newName: "Report");

            migrationBuilder.RenameTable(
                name: "protocols",
                newName: "Protocol");

            migrationBuilder.RenameTable(
                name: "parts",
                newName: "Part");

            migrationBuilder.RenameTable(
                name: "orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "languages",
                newName: "Language");

            migrationBuilder.RenameTable(
                name: "computers",
                newName: "Computer");

            migrationBuilder.RenameTable(
                name: "bobbins",
                newName: "Bobbin");

            migrationBuilder.RenameTable(
                name: "articles",
                newName: "Article");

            migrationBuilder.RenameTable(
                name: "app_group_gui_definitions",
                newName: "AppGroupGUIDefinition");

            migrationBuilder.RenameTable(
                name: "app_definitions",
                newName: "AppDefinition");

            migrationBuilder.RenameTable(
                name: "app_code_gui_definitions",
                newName: "AppCodeGUIDefinition");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Thread",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Thread",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Supplier",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Supplier",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Report",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Report",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Protocol",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Protocol",
                newName: "StitchesNotCrit4");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Protocol",
                newName: "SerialNo");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Part",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Part",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Order",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Order",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Bobbin",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Bobbin",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Article",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Article",
                newName: "CreatedOn");

            migrationBuilder.AddColumn<int>(
                name: "ComputerID",
                table: "Setting",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Report",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Protocol",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EndLabe2Seamed",
                table: "Protocol",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EndLabel",
                table: "Protocol",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EndLabelSeamed1",
                table: "Protocol",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "Protocol",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "SeamDetailStatus",
                table: "Protocol",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SeamOK",
                table: "Protocol",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "StitchesCrit1",
                table: "Protocol",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StitchesCrit2",
                table: "Protocol",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StitchesCrit3",
                table: "Protocol",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StitchesNotCrit1",
                table: "Protocol",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StitchesNotCrit2",
                table: "Protocol",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AppCodeGUIDefinition",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Thread",
                table: "Thread",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Setting",
                table: "Setting",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Report",
                table: "Report",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Protocol",
                table: "Protocol",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Part",
                table: "Part",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Language",
                table: "Language",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Computer",
                table: "Computer",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bobbin",
                table: "Bobbin",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Article",
                table: "Article",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppGroupGUIDefinition",
                table: "AppGroupGUIDefinition",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppDefinition",
                table: "AppDefinition",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppCodeGUIDefinition",
                table: "AppCodeGUIDefinition",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ParentID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    IconUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Desciption = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserGroup",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroup", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    IsRead = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsInserted = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsExecuted = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserGroupID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permission_UserGroup_UserGroupID",
                        column: x => x.UserGroupID,
                        principalTable: "UserGroup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    WinAccount = table.Column<string>(type: "TEXT", nullable: false),
                    ComputerNumber = table.Column<string>(type: "TEXT", nullable: true),
                    ZKFingerReader = table.Column<bool>(type: "INTEGER", nullable: false),
                    FirstFinger = table.Column<string>(type: "TEXT", nullable: true),
                    SecondFinger = table.Column<string>(type: "TEXT", nullable: true),
                    ThirdFinger = table.Column<string>(type: "TEXT", nullable: true),
                    ExpiredDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserID = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    UserImage = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserGroupID = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                    table.ForeignKey(
                        name: "FK_User_UserGroup_UserGroupID",
                        column: x => x.UserGroupID,
                        principalTable: "UserGroup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Setting_ComputerID",
                table: "Setting",
                column: "ComputerID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permission_UserGroupID",
                table: "Permission",
                column: "UserGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserGroupID",
                table: "User",
                column: "UserGroupID");

            migrationBuilder.AddForeignKey(
                name: "FK_Setting_Computer_ComputerID",
                table: "Setting",
                column: "ComputerID",
                principalTable: "Computer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Setting_Computer_ComputerID",
                table: "Setting");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Thread",
                table: "Thread");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Setting",
                table: "Setting");

            migrationBuilder.DropIndex(
                name: "IX_Setting_ComputerID",
                table: "Setting");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Report",
                table: "Report");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Protocol",
                table: "Protocol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Part",
                table: "Part");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Language",
                table: "Language");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Computer",
                table: "Computer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bobbin",
                table: "Bobbin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Article",
                table: "Article");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppGroupGUIDefinition",
                table: "AppGroupGUIDefinition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppDefinition",
                table: "AppDefinition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppCodeGUIDefinition",
                table: "AppCodeGUIDefinition");

            migrationBuilder.DropColumn(
                name: "ComputerID",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Protocol");

            migrationBuilder.DropColumn(
                name: "EndLabe2Seamed",
                table: "Protocol");

            migrationBuilder.DropColumn(
                name: "EndLabel",
                table: "Protocol");

            migrationBuilder.DropColumn(
                name: "EndLabelSeamed1",
                table: "Protocol");

            migrationBuilder.DropColumn(
                name: "Label",
                table: "Protocol");

            migrationBuilder.DropColumn(
                name: "SeamDetailStatus",
                table: "Protocol");

            migrationBuilder.DropColumn(
                name: "SeamOK",
                table: "Protocol");

            migrationBuilder.DropColumn(
                name: "StitchesCrit1",
                table: "Protocol");

            migrationBuilder.DropColumn(
                name: "StitchesCrit2",
                table: "Protocol");

            migrationBuilder.DropColumn(
                name: "StitchesCrit3",
                table: "Protocol");

            migrationBuilder.DropColumn(
                name: "StitchesNotCrit1",
                table: "Protocol");

            migrationBuilder.DropColumn(
                name: "StitchesNotCrit2",
                table: "Protocol");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AppCodeGUIDefinition");

            migrationBuilder.RenameTable(
                name: "Thread",
                newName: "threads");

            migrationBuilder.RenameTable(
                name: "Supplier",
                newName: "suppliers");

            migrationBuilder.RenameTable(
                name: "Setting",
                newName: "settings");

            migrationBuilder.RenameTable(
                name: "Report",
                newName: "reports");

            migrationBuilder.RenameTable(
                name: "Protocol",
                newName: "protocols");

            migrationBuilder.RenameTable(
                name: "Part",
                newName: "parts");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "orders");

            migrationBuilder.RenameTable(
                name: "Language",
                newName: "languages");

            migrationBuilder.RenameTable(
                name: "Computer",
                newName: "computers");

            migrationBuilder.RenameTable(
                name: "Bobbin",
                newName: "bobbins");

            migrationBuilder.RenameTable(
                name: "Article",
                newName: "articles");

            migrationBuilder.RenameTable(
                name: "AppGroupGUIDefinition",
                newName: "app_group_gui_definitions");

            migrationBuilder.RenameTable(
                name: "AppDefinition",
                newName: "app_definitions");

            migrationBuilder.RenameTable(
                name: "AppCodeGUIDefinition",
                newName: "app_code_gui_definitions");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "threads",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "threads",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "suppliers",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "suppliers",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "reports",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "reports",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "protocols",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "StitchesNotCrit4",
                table: "protocols",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "SerialNo",
                table: "protocols",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "parts",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "parts",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "orders",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "orders",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "bobbins",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "bobbins",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "articles",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "articles",
                newName: "CreatedDate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_threads",
                table: "threads",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_suppliers",
                table: "suppliers",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_settings",
                table: "settings",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_reports",
                table: "reports",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_protocols",
                table: "protocols",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_parts",
                table: "parts",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orders",
                table: "orders",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_languages",
                table: "languages",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_computers",
                table: "computers",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bobbins",
                table: "bobbins",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_articles",
                table: "articles",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_app_group_gui_definitions",
                table: "app_group_gui_definitions",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_app_definitions",
                table: "app_definitions",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_app_code_gui_definitions",
                table: "app_code_gui_definitions",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "masterdatas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Desciption = table.Column<string>(type: "TEXT", nullable: true),
                    IconUrl = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ParentID = table.Column<int>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_masterdatas", x => x.ID);
                });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Example.Migrations
{
    public partial class Starting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataProcessor",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    WebSite = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataProcessor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DPSystem",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    SystemCode = table.Column<string>(nullable: true),
                    SystemName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DPSystem", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SystemCapablity",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemCapablity", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SystemCode",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemCode", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SystemService",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Core = table.Column<bool>(nullable: false),
                    CreditCard = table.Column<bool>(nullable: false),
                    LOS = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemService", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ContactType = table.Column<int>(nullable: false),
                    DataProcessorID = table.Column<Guid>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_DataProcessor_DataProcessorID",
                        column: x => x.DataProcessorID,
                        principalTable: "DataProcessor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_DataProcessorID",
                table: "Contact",
                column: "DataProcessorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "DPSystem");

            migrationBuilder.DropTable(
                name: "SystemCapablity");

            migrationBuilder.DropTable(
                name: "SystemCode");

            migrationBuilder.DropTable(
                name: "SystemService");

            migrationBuilder.DropTable(
                name: "DataProcessor");
        }
    }
}

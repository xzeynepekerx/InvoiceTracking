using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvoiceTracking.Data.Migrations
{
    public partial class AddInvoiceTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvoiceNumberTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultDays = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceNumberTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceNumberAllocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfDays = table.Column<int>(type: "int", nullable: false),
                    DateCraeted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Period = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InvoiceNumberTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceNumberAllocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceNumberAllocations_AspNetUsers_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceNumberAllocations_InvoiceNumberTypes_InvoiceNumberTypeId",
                        column: x => x.InvoiceNumberTypeId,
                        principalTable: "InvoiceNumberTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceNumberRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestingInvoiceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ApprovedInvoiceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InvoiceNumberTypeId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Approved = table.Column<bool>(type: "bit", nullable: true),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceNumberRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceNumberRequests_AspNetUsers_ApprovedInvoiceId",
                        column: x => x.ApprovedInvoiceId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceNumberRequests_AspNetUsers_RequestingInvoiceId",
                        column: x => x.RequestingInvoiceId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceNumberRequests_InvoiceNumberTypes_InvoiceNumberTypeId",
                        column: x => x.InvoiceNumberTypeId,
                        principalTable: "InvoiceNumberTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceNumberAllocations_InvoiceId",
                table: "InvoiceNumberAllocations",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceNumberAllocations_InvoiceNumberTypeId",
                table: "InvoiceNumberAllocations",
                column: "InvoiceNumberTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceNumberRequests_ApprovedInvoiceId",
                table: "InvoiceNumberRequests",
                column: "ApprovedInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceNumberRequests_InvoiceNumberTypeId",
                table: "InvoiceNumberRequests",
                column: "InvoiceNumberTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceNumberRequests_RequestingInvoiceId",
                table: "InvoiceNumberRequests",
                column: "RequestingInvoiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceNumberAllocations");

            migrationBuilder.DropTable(
                name: "InvoiceNumberRequests");

            migrationBuilder.DropTable(
                name: "InvoiceNumberTypes");
        }
    }
}

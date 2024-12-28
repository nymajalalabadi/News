using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace News.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Reports_ReportId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Galleries_GalleryId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_ReportGroups_ReportGroupId",
                table: "Reports");

            migrationBuilder.CreateTable(
                name: "links",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSuccess = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_links", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "links",
                columns: new[] { "Id", "CreateDate", "IsDelete", "IsSuccess", "LastUpdateDate", "LinkAddress", "LinkName" },
                values: new object[] { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "test", "test" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Reports_ReportId",
                table: "Comments",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Galleries_GalleryId",
                table: "Images",
                column: "GalleryId",
                principalTable: "Galleries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_ReportGroups_ReportGroupId",
                table: "Reports",
                column: "ReportGroupId",
                principalTable: "ReportGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Reports_ReportId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Galleries_GalleryId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_ReportGroups_ReportGroupId",
                table: "Reports");

            migrationBuilder.DropTable(
                name: "links");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Reports_ReportId",
                table: "Comments",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Galleries_GalleryId",
                table: "Images",
                column: "GalleryId",
                principalTable: "Galleries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_ReportGroups_ReportGroupId",
                table: "Reports",
                column: "ReportGroupId",
                principalTable: "ReportGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

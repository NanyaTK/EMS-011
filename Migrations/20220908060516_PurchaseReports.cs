using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS_011.Migrations
{
    public partial class PurchaseReports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "ImageFile",
                table: "PurchaseReports",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "mediumblob");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "ImageFile",
                table: "PurchaseReports",
                type: "mediumblob",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedNavigationProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ZooId",
                table: "Animals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Animals_ZooId",
                table: "Animals",
                column: "ZooId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Zoos_ZooId",
                table: "Animals",
                column: "ZooId",
                principalTable: "Zoos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Zoos_ZooId",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_ZooId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "ZooId",
                table: "Animals");
        }
    }
}

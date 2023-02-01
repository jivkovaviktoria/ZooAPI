using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalAPI.Migrations
{
    /// <inheritdoc />
    public partial class ZooIdNotNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Zoos_ZooId",
                table: "Animals");

            migrationBuilder.AlterColumn<Guid>(
                name: "ZooId",
                table: "Animals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<Guid>(
                name: "ZooId",
                table: "Animals",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Zoos_ZooId",
                table: "Animals",
                column: "ZooId",
                principalTable: "Zoos",
                principalColumn: "Id");
        }
    }
}

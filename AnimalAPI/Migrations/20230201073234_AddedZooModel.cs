using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedZooModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ZooId",
                table: "Animals",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Zoos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zoos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_ZooId",
                table: "Animals",
                column: "ZooId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Zoos_ZooId",
                table: "Animals",
                column: "ZooId",
                principalTable: "Zoos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Zoos_ZooId",
                table: "Animals");

            migrationBuilder.DropTable(
                name: "Zoos");

            migrationBuilder.DropIndex(
                name: "IX_Animals_ZooId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "ZooId",
                table: "Animals");
        }
    }
}

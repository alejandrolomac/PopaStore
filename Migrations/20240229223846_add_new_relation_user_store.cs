using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PopaStore.Migrations
{
    /// <inheritdoc />
    public partial class add_new_relation_user_store : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoreBrands");

            migrationBuilder.DropTable(
                name: "UserStores");

            migrationBuilder.RenameColumn(
                name: "otros",
                table: "Stores",
                newName: "Otros");

            migrationBuilder.CreateTable(
                name: "StoreUserRelations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreUserRelations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoreUserRelations");

            migrationBuilder.RenameColumn(
                name: "Otros",
                table: "Stores",
                newName: "otros");

            migrationBuilder.CreateTable(
                name: "StoreBrands",
                columns: table => new
                {
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreBrands", x => new { x.StoreId, x.BrandId });
                    table.ForeignKey(
                        name: "FK_StoreBrands_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreBrands_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserStores",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStores", x => new { x.UserId, x.StoreId });
                    table.ForeignKey(
                        name: "FK_UserStores_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserStores_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoreBrands_BrandId",
                table: "StoreBrands",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_UserStores_StoreId",
                table: "UserStores",
                column: "StoreId");
        }
    }
}

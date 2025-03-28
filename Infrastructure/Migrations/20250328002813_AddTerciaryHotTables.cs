using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTerciaryHotTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UUID", nullable: false),
                    Name = table.Column<string>(type: "String", maxLength: 100, nullable: true),
                    Active = table.Column<bool>(type: "UInt8", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "DateTime", nullable: true, defaultValueSql: "now()"),
                    UpdatedDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "now()"),
                    DeletedDate = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UUID", nullable: false),
                    Name = table.Column<string>(type: "String", maxLength: 100, nullable: false),
                    Slug = table.Column<string>(type: "String", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "DateTime", nullable: true, defaultValueSql: "now()"),
                    UpdatedDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "now()"),
                    DeletedDate = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UUID", nullable: false),
                    FirstName = table.Column<string>(type: "String", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "String", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "String", maxLength: 50, nullable: true),
                    Road = table.Column<string>(type: "String", maxLength: 100, nullable: true),
                    NeighborHood = table.Column<string>(type: "String", nullable: true),
                    Number = table.Column<long>(type: "Int64", nullable: true),
                    Complement = table.Column<string>(type: "String", maxLength: 100, nullable: true),
                    Hash = table.Column<string>(type: "String", nullable: true),
                    Salt = table.Column<string>(type: "String", nullable: true),
                    Active = table.Column<bool>(type: "UInt8", nullable: false),
                    TokenActivate = table.Column<long>(type: "String", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "DateTime", nullable: true, defaultValueSql: "now()"),
                    UpdatedDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "now()"),
                    DeletedDate = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Apps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UUID", nullable: false),
                    Name = table.Column<string>(type: "String", maxLength: 100, nullable: false),
                    CategoryId = table.Column<Guid>(type: "UUID", nullable: false),
                    Environment = table.Column<int>(type: "String", nullable: true),
                    Active = table.Column<bool>(type: "UInt8", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "DateTime", nullable: true, defaultValueSql: "now()"),
                    UpdatedDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "now()"),
                    DeletedDate = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apps_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "UUID", nullable: false),
                    UserId = table.Column<Guid>(type: "UUID", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogApps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UUID", nullable: false),
                    Environment = table.Column<string>(type: "TEXT", nullable: false),
                    Level = table.Column<string>(type: "TEXT", nullable: true),
                    Message = table.Column<string>(type: "String", nullable: true),
                    StackTrace = table.Column<string>(type: "String", nullable: true),
                    AppId = table.Column<Guid>(type: "UUID", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "DateTime", nullable: true, defaultValueSql: "now()"),
                    UpdatedDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogApps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogApps_Apps_AppId",
                        column: x => x.AppId,
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apps_CategoryId",
                table: "Apps",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_LogApps_AppId",
                table: "LogApps",
                column: "AppId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogApps");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Apps");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

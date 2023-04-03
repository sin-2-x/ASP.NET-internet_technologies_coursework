using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_MVC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Day",
                columns: table => new
                {
                    IdDay = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DayEnabledValue = table.Column<double>(type: "float", nullable: true),
                    DayFactValue = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Day", x => x.IdDay);
                });

            migrationBuilder.CreateTable(
                name: "Usr",
                columns: table => new
                {
                    IdUsr = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginUsr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordUsr = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usr", x => x.IdUsr);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    IdCategory = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    NameCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsedCountCategory = table.Column<long>(type: "bigint", nullable: false),
                    IdUserNavigationIdUsr = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.IdCategory);
                    table.ForeignKey(
                        name: "FK_Category_Usr_IdUserNavigationIdUsr",
                        column: x => x.IdUserNavigationIdUsr,
                        principalTable: "Usr",
                        principalColumn: "IdUsr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Month",
                columns: table => new
                {
                    IdMonth = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    Year = table.Column<long>(type: "bigint", nullable: false),
                    Month1 = table.Column<long>(type: "bigint", nullable: false),
                    MonyLimit = table.Column<double>(type: "float", nullable: false),
                    IdUserNavigationIdUsr = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Month", x => x.IdMonth);
                    table.ForeignKey(
                        name: "FK_Month_Usr_IdUserNavigationIdUsr",
                        column: x => x.IdUserNavigationIdUsr,
                        principalTable: "Usr",
                        principalColumn: "IdUsr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Waste",
                columns: table => new
                {
                    IdWaste = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    IdDay = table.Column<long>(type: "bigint", nullable: false),
                    IdCategory = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCategoryNavigationIdCategory = table.Column<long>(type: "bigint", nullable: false),
                    IdDayNavigationIdDay = table.Column<long>(type: "bigint", nullable: false),
                    IdUserNavigationIdUsr = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waste", x => x.IdWaste);
                    table.ForeignKey(
                        name: "FK_Waste_Category_IdCategoryNavigationIdCategory",
                        column: x => x.IdCategoryNavigationIdCategory,
                        principalTable: "Category",
                        principalColumn: "IdCategory",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Waste_Day_IdDayNavigationIdDay",
                        column: x => x.IdDayNavigationIdDay,
                        principalTable: "Day",
                        principalColumn: "IdDay",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Waste_Usr_IdUserNavigationIdUsr",
                        column: x => x.IdUserNavigationIdUsr,
                        principalTable: "Usr",
                        principalColumn: "IdUsr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_IdUserNavigationIdUsr",
                table: "Category",
                column: "IdUserNavigationIdUsr");

            migrationBuilder.CreateIndex(
                name: "IX_Month_IdUserNavigationIdUsr",
                table: "Month",
                column: "IdUserNavigationIdUsr");

            migrationBuilder.CreateIndex(
                name: "IX_Waste_IdCategoryNavigationIdCategory",
                table: "Waste",
                column: "IdCategoryNavigationIdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Waste_IdDayNavigationIdDay",
                table: "Waste",
                column: "IdDayNavigationIdDay");

            migrationBuilder.CreateIndex(
                name: "IX_Waste_IdUserNavigationIdUsr",
                table: "Waste",
                column: "IdUserNavigationIdUsr");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Month");

            migrationBuilder.DropTable(
                name: "Waste");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Day");

            migrationBuilder.DropTable(
                name: "Usr");
        }
    }
}

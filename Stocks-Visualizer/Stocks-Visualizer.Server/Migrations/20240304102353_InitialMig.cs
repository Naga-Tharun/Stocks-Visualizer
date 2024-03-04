using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stocks_Visualizer.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Symbol = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Interval = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    OutputSize = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TimeZone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeSeriesDatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Open = table.Column<float>(type: "BINARY_FLOAT", nullable: false),
                    High = table.Column<float>(type: "BINARY_FLOAT", nullable: false),
                    Low = table.Column<float>(type: "BINARY_FLOAT", nullable: false),
                    Close = table.Column<float>(type: "BINARY_FLOAT", nullable: false),
                    Volume = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    StockId = table.Column<Guid>(type: "RAW(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSeriesDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSeriesDatas_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeSeriesDatas_StockId",
                table: "TimeSeriesDatas",
                column: "StockId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeSeriesDatas");

            migrationBuilder.DropTable(
                name: "Stocks");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Baseline : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NodeEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NodeSelector = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NodeEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PodEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PodSelector = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Metrics",
                columns: table => new
                {
                    Label = table.Column<string>(type: "text", nullable: false),
                    MetricType = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    CpuTotal = table.Column<double>(type: "double precision", nullable: true),
                    MemoryTotal = table.Column<double>(type: "double precision", nullable: true),
                    NodeId = table.Column<Guid>(type: "uuid", nullable: true),
                    CpuUsage = table.Column<double>(type: "double precision", nullable: true),
                    MemoryUsage = table.Column<double>(type: "double precision", nullable: true),
                    PodId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metrics", x => x.Label);
                    table.ForeignKey(
                        name: "FK_Metrics_NodeEntity_NodeId",
                        column: x => x.NodeId,
                        principalTable: "NodeEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Metrics_PodEntity_PodId",
                        column: x => x.PodId,
                        principalTable: "PodEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Metrics_NodeId",
                table: "Metrics",
                column: "NodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Metrics_PodId",
                table: "Metrics",
                column: "PodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Metrics");

            migrationBuilder.DropTable(
                name: "NodeEntity");

            migrationBuilder.DropTable(
                name: "PodEntity");
        }
    }
}

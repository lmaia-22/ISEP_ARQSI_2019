using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectIteration1.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Machine",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdTypeMachine = table.Column<long>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Localization = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    InspectionDate = table.Column<DateTime>(nullable: false),
                    StatusOperational = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MachineOperation",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdOperation = table.Column<long>(nullable: false),
                    IdMachine = table.Column<long>(nullable: false),
                    IdTool = table.Column<long>(nullable: false),
                    DurationOperationInMinutes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineOperation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operation",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdFabricPlan = table.Column<long>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionLine",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdsMachine = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ProductionLineNumber = table.Column<int>(nullable: false),
                    DateOperationStarted = table.Column<DateTime>(nullable: false),
                    DateOperatedFinished = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    DailyProductionCapacity = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionLine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tool",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tool", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeMachine",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeMachine", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Machine");

            migrationBuilder.DropTable(
                name: "MachineOperation");

            migrationBuilder.DropTable(
                name: "Operation");

            migrationBuilder.DropTable(
                name: "ProductionLine");

            migrationBuilder.DropTable(
                name: "Tool");

            migrationBuilder.DropTable(
                name: "TypeMachine");
        }
    }
}

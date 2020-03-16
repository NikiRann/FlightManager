using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightManager1.Data.Migrations
{
    public partial class Flights1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    From = table.Column<string>(nullable: true),
                    To = table.Column<string>(nullable: true),
                    ArivalTime = table.Column<DateTime>(nullable: false),
                    LeaveTime = table.Column<DateTime>(nullable: false),
                    TypeOfPlane = table.Column<string>(nullable: true),
                    PlaneId = table.Column<int>(nullable: false),
                    PilotName = table.Column<string>(nullable: true),
                    PlaneCapacity = table.Column<int>(nullable: false),
                    BuisnessClassCapacity = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}

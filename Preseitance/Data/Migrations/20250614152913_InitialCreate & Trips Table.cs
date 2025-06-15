using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateTripsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    StartTripe = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndTripe = table.Column<DateTime>(type: "datetime", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailableDays = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeOfDeparture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsChildrenAllowed = table.Column<bool>(type: "bit", nullable: false),
                    GroupSizeMax = table.Column<int>(type: "int", nullable: false),
                    SuitableFor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeetingPoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trips");
        }
    }
}

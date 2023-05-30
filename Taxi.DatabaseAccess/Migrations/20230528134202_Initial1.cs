using Microsoft.EntityFrameworkCore.Migrations;

namespace Taxi.DatabaseAccess.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maintenaces_Cars_CarId",
                table: "Maintenaces");

            migrationBuilder.DropForeignKey(
                name: "FK_Maintenaces_MaintenaceTypes_MaintenaceTypeId",
                table: "Maintenaces");

            migrationBuilder.DropForeignKey(
                name: "FK_Rides_Shifts_ShiftId1",
                table: "Rides");

            migrationBuilder.DropIndex(
                name: "IX_Rides_ShiftId1",
                table: "Rides");

            migrationBuilder.DropColumn(
                name: "ShiftId1",
                table: "Rides");

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenaces_Cars_CarId",
                table: "Maintenaces",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenaces_MaintenaceTypes_MaintenaceTypeId",
                table: "Maintenaces",
                column: "MaintenaceTypeId",
                principalTable: "MaintenaceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maintenaces_Cars_CarId",
                table: "Maintenaces");

            migrationBuilder.DropForeignKey(
                name: "FK_Maintenaces_MaintenaceTypes_MaintenaceTypeId",
                table: "Maintenaces");

            migrationBuilder.AddColumn<int>(
                name: "ShiftId1",
                table: "Rides",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rides_ShiftId1",
                table: "Rides",
                column: "ShiftId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenaces_Cars_CarId",
                table: "Maintenaces",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenaces_MaintenaceTypes_MaintenaceTypeId",
                table: "Maintenaces",
                column: "MaintenaceTypeId",
                principalTable: "MaintenaceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_Shifts_ShiftId1",
                table: "Rides",
                column: "ShiftId1",
                principalTable: "Shifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

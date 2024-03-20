using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheatreApp.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_TheatreUserId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Theatres_TheatreId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_TheatreId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "TheatreUserId",
                table: "Tickets",
                newName: "BoughtById");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_TheatreUserId",
                table: "Tickets",
                newName: "IX_Tickets_BoughtById");

            migrationBuilder.AlterColumn<Guid>(
                name: "TheatreId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ConcertId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ConcertId",
                table: "Tickets",
                column: "ConcertId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_BoughtById",
                table: "Tickets",
                column: "BoughtById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Theatres_ConcertId",
                table: "Tickets",
                column: "ConcertId",
                principalTable: "Theatres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_BoughtById",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Theatres_ConcertId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ConcertId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ConcertId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "BoughtById",
                table: "Tickets",
                newName: "TheatreUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_BoughtById",
                table: "Tickets",
                newName: "IX_Tickets_TheatreUserId");

            migrationBuilder.AlterColumn<Guid>(
                name: "TheatreId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TheatreId",
                table: "Tickets",
                column: "TheatreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_TheatreUserId",
                table: "Tickets",
                column: "TheatreUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Theatres_TheatreId",
                table: "Tickets",
                column: "TheatreId",
                principalTable: "Theatres",
                principalColumn: "Id");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheatreApp.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedTicketForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Theatres_ConcertId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ConcertId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ConcertId",
                table: "Tickets");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TheatreId",
                table: "Tickets",
                column: "TheatreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Theatres_TheatreId",
                table: "Tickets",
                column: "TheatreId",
                principalTable: "Theatres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Theatres_TheatreId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_TheatreId",
                table: "Tickets");

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
                name: "FK_Tickets_Theatres_ConcertId",
                table: "Tickets",
                column: "ConcertId",
                principalTable: "Theatres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservations.Application.Migrations
{
    /// <inheritdoc />
    public partial class NullableTenantRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ReservationEnd", "ReservationStart" },
                values: new object[] { new DateTime(2023, 4, 3, 17, 47, 3, 581, DateTimeKind.Utc).AddTicks(6355), new DateTime(2023, 4, 3, 17, 47, 3, 581, DateTimeKind.Utc).AddTicks(6366) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ReservationEnd", "ReservationStart" },
                values: new object[] { new DateTime(2023, 4, 3, 17, 47, 3, 581, DateTimeKind.Utc).AddTicks(6401), new DateTime(2023, 4, 3, 17, 47, 3, 581, DateTimeKind.Utc).AddTicks(6401) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ReservationEnd", "ReservationStart" },
                values: new object[] { new DateTime(2023, 3, 30, 17, 31, 33, 358, DateTimeKind.Utc).AddTicks(7392), new DateTime(2023, 3, 30, 17, 31, 33, 358, DateTimeKind.Utc).AddTicks(7394) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ReservationEnd", "ReservationStart" },
                values: new object[] { new DateTime(2023, 3, 30, 17, 31, 33, 358, DateTimeKind.Utc).AddTicks(7418), new DateTime(2023, 3, 30, 17, 31, 33, 358, DateTimeKind.Utc).AddTicks(7419) });
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetCoreTestWebProject.Migrations
{
    public partial class AllowNullInDeletedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Track",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 11, 32, 9, 189, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Track",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 11, 32, 9, 189, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "PlaylistTrack",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 11, 32, 9, 179, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "PlaylistTrack",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 11, 32, 9, 179, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Playlist",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 11, 32, 9, 169, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Playlist",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 11, 32, 9, 169, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "MediaType",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 11, 32, 9, 166, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "MediaType",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 11, 32, 9, 166, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "InvoiceLine",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 11, 32, 9, 163, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "InvoiceLine",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 11, 32, 9, 163, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Invoice",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 11, 32, 9, 156, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Invoice",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 11, 32, 9, 156, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Genre",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 11, 32, 9, 148, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Genre",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 11, 32, 9, 148, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Employee",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 11, 32, 9, 145, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Employee",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 11, 32, 9, 145, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Customer",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 11, 32, 9, 130, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Customer",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 11, 32, 9, 130, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Artist",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 11, 32, 9, 120, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Artist",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 11, 32, 9, 120, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Album",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 11, 32, 9, 109, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Album",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 11, 32, 9, 101, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Track",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 10, 12, 29, 977, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Track",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 10, 12, 29, 977, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "PlaylistTrack",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 10, 12, 29, 966, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "PlaylistTrack",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 10, 12, 29, 966, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Playlist",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 10, 12, 29, 956, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Playlist",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 10, 12, 29, 956, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "MediaType",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 10, 12, 29, 953, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "MediaType",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 10, 12, 29, 953, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "InvoiceLine",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 10, 12, 29, 950, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "InvoiceLine",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 10, 12, 29, 950, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Invoice",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 10, 12, 29, 942, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Invoice",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 10, 12, 29, 942, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Genre",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 10, 12, 29, 933, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Genre",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 10, 12, 29, 933, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Employee",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 10, 12, 29, 930, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Employee",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 10, 12, 29, 930, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Customer",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 10, 12, 29, 915, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Customer",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 10, 12, 29, 915, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Artist",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 10, 12, 29, 904, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Artist",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 10, 12, 29, 904, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Album",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 10, 12, 29, 893, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Album",
                nullable: false,
                defaultValue: new DateTime(2016, 8, 15, 10, 12, 29, 885, DateTimeKind.Local));
        }
    }
}

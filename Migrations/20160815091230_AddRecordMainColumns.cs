﻿using System;
using Core.Common.Utilities;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetCoreTestWebProject.Migrations
{
    public partial class AddRecordMainColumns : Migration
    {
        string[] tableNames = { "Album", "Artist", "Customer", "Employee", "Genre", "Invoice", "InvoiceLine", "MediaType", "Playlist", "PlaylistTrack", "Track" };
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            foreach (string tableName in tableNames)
            {
                migrationBuilder.AddColumn<DateTime>(name: "DateCreated", table: tableName, nullable: false, defaultValue: new DateTime(2016, 8, 15, 10, 12, 29, 904, DateTimeKind.Local));
                migrationBuilder.AddColumn<DateTime>(name: "DateModified", table: tableName, nullable: false, defaultValue: new DateTime(2016, 8, 15, 10, 12, 29, 904, DateTimeKind.Local));
                migrationBuilder.AddColumn<bool>(name: "Deleted", table: tableName, nullable: false, defaultValue: false);
                migrationBuilder.AddColumn<string>(name: "Guid", table: tableName, nullable: false, defaultValue: StringUtils.GenerateLowercase32DigitsGuid());
                migrationBuilder.AddColumn<byte[]>(name: "RowVersion", table: tableName, nullable: false, defaultValue: DateTime.Now.Millisecond);
            }
          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            foreach (string tableName in tableNames)
            {
                migrationBuilder.DropColumn("DateCreated", tableName);
                migrationBuilder.DropColumn("DateModified", tableName);
                migrationBuilder.DropColumn("Deleted", tableName);
                migrationBuilder.DropColumn("Guid", tableName);
                migrationBuilder.DropColumn("RowVersion", tableName);         
            }            
        }
    }
}

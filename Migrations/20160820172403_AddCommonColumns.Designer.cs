﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DotNetCoreTestWebProject.Data;

namespace DotNetCoreTestWebProject.Migrations
{
    [DbContext(typeof(ChinookSqliteDbContext))]
    [Migration("20160820172403_AddCommonColumns")]
    partial class AddCommonColumns
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("DotNetCoreTestWebProject.Models.Album", b =>
                {
                    b.Property<long>("AlbumId")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("ArtistId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<bool?>("Deleted");

                    b.Property<string>("Guid");

                    b.Property<int>("Id");

                    b.Property<int>("ObjectState");

                    b.Property<byte[]>("RowVersion");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(160)");

                    b.HasKey("AlbumId");

                    b.HasIndex("ArtistId")
                        .HasName("IFK_AlbumArtistId");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("DotNetCoreTestWebProject.Models.Artist", b =>
                {
                    b.Property<long>("ArtistId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<bool?>("Deleted");

                    b.Property<string>("Guid");

                    b.Property<int>("Id");

                    b.Property<string>("Name")
                        .HasColumnType("NVARCHAR(120)");

                    b.Property<int>("ObjectState");

                    b.Property<byte[]>("RowVersion");

                    b.HasKey("ArtistId");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("DotNetCoreTestWebProject.Models.Customer", b =>
                {
                    b.Property<long>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasColumnType("NVARCHAR(70)");

                    b.Property<string>("City")
                        .HasColumnType("NVARCHAR(40)");

                    b.Property<string>("Company")
                        .HasColumnType("NVARCHAR(80)");

                    b.Property<string>("Country")
                        .HasColumnType("NVARCHAR(40)");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<bool?>("Deleted");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(60)");

                    b.Property<string>("Fax")
                        .HasColumnType("NVARCHAR(24)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(40)");

                    b.Property<string>("Guid");

                    b.Property<int>("Id");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(20)");

                    b.Property<int>("ObjectState");

                    b.Property<string>("Phone")
                        .HasColumnType("NVARCHAR(24)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("NVARCHAR(10)");

                    b.Property<byte[]>("RowVersion");

                    b.Property<string>("State")
                        .HasColumnType("NVARCHAR(40)");

                    b.Property<long?>("SupportRepId");

                    b.HasKey("CustomerId");

                    b.HasIndex("SupportRepId")
                        .HasName("IFK_CustomerSupportRepId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("DotNetCoreTestWebProject.Models.Employee", b =>
                {
                    b.Property<long>("EmployeeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasColumnType("NVARCHAR(70)");

                    b.Property<string>("BirthDate")
                        .HasColumnType("DATETIME");

                    b.Property<string>("City")
                        .HasColumnType("NVARCHAR(40)");

                    b.Property<string>("Country")
                        .HasColumnType("NVARCHAR(40)");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<bool?>("Deleted");

                    b.Property<string>("Email")
                        .HasColumnType("NVARCHAR(60)");

                    b.Property<string>("Fax")
                        .HasColumnType("NVARCHAR(24)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(20)");

                    b.Property<string>("Guid");

                    b.Property<string>("HireDate")
                        .HasColumnType("DATETIME");

                    b.Property<int>("Id");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(20)");

                    b.Property<int>("ObjectState");

                    b.Property<string>("Phone")
                        .HasColumnType("NVARCHAR(24)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("NVARCHAR(10)");

                    b.Property<long?>("ReportsTo");

                    b.Property<byte[]>("RowVersion");

                    b.Property<string>("State")
                        .HasColumnType("NVARCHAR(40)");

                    b.Property<string>("Title")
                        .HasColumnType("NVARCHAR(30)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("ReportsTo")
                        .HasName("IFK_EmployeeReportsTo");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("DotNetCoreTestWebProject.Models.Genre", b =>
                {
                    b.Property<long>("GenreId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<bool?>("Deleted");

                    b.Property<string>("Guid");

                    b.Property<int>("Id");

                    b.Property<string>("Name")
                        .HasColumnType("NVARCHAR(120)");

                    b.Property<int>("ObjectState");

                    b.Property<byte[]>("RowVersion");

                    b.HasKey("GenreId");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("DotNetCoreTestWebProject.Models.Invoice", b =>
                {
                    b.Property<long>("InvoiceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BillingAddress")
                        .HasColumnType("NVARCHAR(70)");

                    b.Property<string>("BillingCity")
                        .HasColumnType("NVARCHAR(40)");

                    b.Property<string>("BillingCountry")
                        .HasColumnType("NVARCHAR(40)");

                    b.Property<string>("BillingPostalCode")
                        .HasColumnType("NVARCHAR(10)");

                    b.Property<string>("BillingState")
                        .HasColumnType("NVARCHAR(40)");

                    b.Property<long>("CustomerId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<bool?>("Deleted");

                    b.Property<string>("Guid");

                    b.Property<int>("Id");

                    b.Property<string>("InvoiceDate")
                        .IsRequired()
                        .HasColumnType("DATETIME");

                    b.Property<int>("ObjectState");

                    b.Property<byte[]>("RowVersion");

                    b.Property<string>("Total")
                        .IsRequired()
                        .HasColumnType("NUMERIC(10,2)");

                    b.HasKey("InvoiceId");

                    b.HasIndex("CustomerId")
                        .HasName("IFK_InvoiceCustomerId");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("DotNetCoreTestWebProject.Models.InvoiceLine", b =>
                {
                    b.Property<long>("InvoiceLineId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<bool?>("Deleted");

                    b.Property<string>("Guid");

                    b.Property<int>("Id");

                    b.Property<long>("InvoiceId");

                    b.Property<int>("ObjectState");

                    b.Property<long>("Quantity");

                    b.Property<byte[]>("RowVersion");

                    b.Property<long>("TrackId");

                    b.Property<string>("UnitPrice")
                        .IsRequired()
                        .HasColumnType("NUMERIC(10,2)");

                    b.HasKey("InvoiceLineId");

                    b.HasIndex("InvoiceId")
                        .HasName("IFK_InvoiceLineInvoiceId");

                    b.HasIndex("TrackId")
                        .HasName("IFK_InvoiceLineTrackId");

                    b.ToTable("InvoiceLine");
                });

            modelBuilder.Entity("DotNetCoreTestWebProject.Models.MediaType", b =>
                {
                    b.Property<long>("MediaTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<bool?>("Deleted");

                    b.Property<string>("Guid");

                    b.Property<int>("Id");

                    b.Property<string>("Name")
                        .HasColumnType("NVARCHAR(120)");

                    b.Property<int>("ObjectState");

                    b.Property<byte[]>("RowVersion");

                    b.HasKey("MediaTypeId");

                    b.ToTable("MediaType");
                });

            modelBuilder.Entity("DotNetCoreTestWebProject.Models.Playlist", b =>
                {
                    b.Property<long>("PlaylistId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<bool?>("Deleted");

                    b.Property<string>("Guid");

                    b.Property<int>("Id");

                    b.Property<string>("Name")
                        .HasColumnType("NVARCHAR(120)");

                    b.Property<int>("ObjectState");

                    b.Property<byte[]>("RowVersion");

                    b.HasKey("PlaylistId");

                    b.ToTable("Playlist");
                });

            modelBuilder.Entity("DotNetCoreTestWebProject.Models.PlaylistTrack", b =>
                {
                    b.Property<long>("PlaylistId");

                    b.Property<long>("TrackId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<bool?>("Deleted");

                    b.Property<string>("Guid");

                    b.Property<int>("Id");

                    b.Property<int>("ObjectState");

                    b.Property<byte[]>("RowVersion");

                    b.HasKey("PlaylistId", "TrackId")
                        .HasName("sqlite_autoindex_PlaylistTrack_1");

                    b.HasIndex("PlaylistId");

                    b.HasIndex("TrackId")
                        .HasName("IFK_PlaylistTrackTrackId");

                    b.ToTable("PlaylistTrack");
                });

            modelBuilder.Entity("DotNetCoreTestWebProject.Models.Track", b =>
                {
                    b.Property<long>("TrackId")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("AlbumId");

                    b.Property<long?>("Bytes");

                    b.Property<string>("Composer")
                        .HasColumnType("NVARCHAR(220)");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<bool?>("Deleted");

                    b.Property<long?>("GenreId");

                    b.Property<string>("Guid");

                    b.Property<int>("Id");

                    b.Property<long>("MediaTypeId");

                    b.Property<long>("Milliseconds");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(200)");

                    b.Property<int>("ObjectState");

                    b.Property<byte[]>("RowVersion");

                    b.Property<string>("UnitPrice")
                        .IsRequired()
                        .HasColumnType("NUMERIC(10,2)");

                    b.HasKey("TrackId");

                    b.HasIndex("AlbumId")
                        .HasName("IFK_TrackAlbumId");

                    b.HasIndex("GenreId")
                        .HasName("IFK_TrackGenreId");

                    b.HasIndex("MediaTypeId")
                        .HasName("IFK_TrackMediaTypeId");

                    b.ToTable("Track");
                });

            modelBuilder.Entity("DotNetCoreTestWebProject.Models.Album", b =>
                {
                    b.HasOne("DotNetCoreTestWebProject.Models.Artist", "Artist")
                        .WithMany("Album")
                        .HasForeignKey("ArtistId");
                });

            modelBuilder.Entity("DotNetCoreTestWebProject.Models.Customer", b =>
                {
                    b.HasOne("DotNetCoreTestWebProject.Models.Employee", "SupportRep")
                        .WithMany("Customer")
                        .HasForeignKey("SupportRepId");
                });

            modelBuilder.Entity("DotNetCoreTestWebProject.Models.Employee", b =>
                {
                    b.HasOne("DotNetCoreTestWebProject.Models.Employee", "ReportsToNavigation")
                        .WithMany("InverseReportsToNavigation")
                        .HasForeignKey("ReportsTo");
                });

            modelBuilder.Entity("DotNetCoreTestWebProject.Models.Invoice", b =>
                {
                    b.HasOne("DotNetCoreTestWebProject.Models.Customer", "Customer")
                        .WithMany("Invoice")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("DotNetCoreTestWebProject.Models.InvoiceLine", b =>
                {
                    b.HasOne("DotNetCoreTestWebProject.Models.Invoice", "Invoice")
                        .WithMany("InvoiceLine")
                        .HasForeignKey("InvoiceId");

                    b.HasOne("DotNetCoreTestWebProject.Models.Track", "Track")
                        .WithMany("InvoiceLine")
                        .HasForeignKey("TrackId");
                });

            modelBuilder.Entity("DotNetCoreTestWebProject.Models.PlaylistTrack", b =>
                {
                    b.HasOne("DotNetCoreTestWebProject.Models.Playlist", "Playlist")
                        .WithMany("PlaylistTrack")
                        .HasForeignKey("PlaylistId");

                    b.HasOne("DotNetCoreTestWebProject.Models.Track", "Track")
                        .WithMany("PlaylistTrack")
                        .HasForeignKey("TrackId");
                });

            modelBuilder.Entity("DotNetCoreTestWebProject.Models.Track", b =>
                {
                    b.HasOne("DotNetCoreTestWebProject.Models.Album", "Album")
                        .WithMany("Track")
                        .HasForeignKey("AlbumId");

                    b.HasOne("DotNetCoreTestWebProject.Models.Genre", "Genre")
                        .WithMany("Track")
                        .HasForeignKey("GenreId");

                    b.HasOne("DotNetCoreTestWebProject.Models.MediaType", "MediaType")
                        .WithMany("Track")
                        .HasForeignKey("MediaTypeId");
                });
        }
    }
}

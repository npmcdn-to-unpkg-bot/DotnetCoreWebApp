using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DotNetCoreTestWebProject.Data;

namespace DotNetCoreTestWebProject.Migrations
{
    [DbContext(typeof(ChinookSqlServer2008DbContext))]
    [Migration("20160815091230_AddRecordMainColumns")]
    partial class AddRecordMainColumns
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DotNetCoreTestWebProject.Models.Album", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("ArtistId");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2016, 8, 15, 10, 12, 29, 885, DateTimeKind.Local));

                    b.Property<DateTime>("DateModified")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2016, 8, 15, 10, 12, 29, 893, DateTimeKind.Local));

                    b.Property<bool?>("Deleted");

                    b.Property<string>("Guid")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 160);

                    b.HasKey("Id");

                    b.HasIndex("ArtistId")
                        .HasName("IFK_AlbumArtistId");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("DotNetCoreTestWebProject.Models.Artist", b =>
                {
                    b.Property<int>("Id");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2016, 8, 15, 10, 12, 29, 904, DateTimeKind.Local));

                    b.Property<DateTime>("DateModified")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2016, 8, 15, 10, 12, 29, 904, DateTimeKind.Local));

                    b.Property<bool?>("Deleted");

                    b.Property<string>("Guid")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 120);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken();

                    b.HasKey("Id");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("DotNetCoreTestWebProject.Models.Customer", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Address")
                        .HasAnnotation("MaxLength", 70);

                    b.Property<string>("City")
                        .HasAnnotation("MaxLength", 40);

                    b.Property<string>("Company")
                        .HasAnnotation("MaxLength", 80);

                    b.Property<string>("Country")
                        .HasAnnotation("MaxLength", 40);

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2016, 8, 15, 10, 12, 29, 915, DateTimeKind.Local));

                    b.Property<DateTime>("DateModified")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2016, 8, 15, 10, 12, 29, 915, DateTimeKind.Local));

                    b.Property<bool?>("Deleted");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 60);

                    b.Property<string>("Fax")
                        .HasAnnotation("MaxLength", 24);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 40);

                    b.Property<string>("Guid")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("Phone")
                        .HasAnnotation("MaxLength", 24);

                    b.Property<string>("PostalCode")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken();

                    b.Property<string>("State")
                        .HasAnnotation("MaxLength", 40);

                    b.Property<int?>("SupportRepId");

                    b.HasKey("Id");

                    b.HasIndex("SupportRepId")
                        .HasName("IFK_CustomerSupportRepId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("DotNetCoreTestWebProject.Models.Employee", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Address")
                        .HasAnnotation("MaxLength", 70);

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<string>("City")
                        .HasAnnotation("MaxLength", 40);

                    b.Property<string>("Country")
                        .HasAnnotation("MaxLength", 40);

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2016, 8, 15, 10, 12, 29, 930, DateTimeKind.Local));

                    b.Property<DateTime>("DateModified")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2016, 8, 15, 10, 12, 29, 930, DateTimeKind.Local));

                    b.Property<bool?>("Deleted");

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 60);

                    b.Property<string>("Fax")
                        .HasAnnotation("MaxLength", 24);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("Guid")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<DateTime?>("HireDate")
                        .HasColumnType("datetime");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("Phone")
                        .HasAnnotation("MaxLength", 24);

                    b.Property<string>("PostalCode")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<int?>("ReportsTo");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken();

                    b.Property<string>("State")
                        .HasAnnotation("MaxLength", 40);

                    b.Property<string>("Title")
                        .HasAnnotation("MaxLength", 30);

                    b.HasKey("Id");

                    b.HasIndex("ReportsTo")
                        .HasName("IFK_EmployeeReportsTo");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("DotNetCoreTestWebProject.Models.Genre", b =>
                {
                    b.Property<int>("Id");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2016, 8, 15, 10, 12, 29, 933, DateTimeKind.Local));

                    b.Property<DateTime>("DateModified")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2016, 8, 15, 10, 12, 29, 933, DateTimeKind.Local));

                    b.Property<bool?>("Deleted");

                    b.Property<string>("Guid")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 120);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken();

                    b.HasKey("Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("DotNetCoreTestWebProject.Models.Invoice", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("BillingAddress")
                        .HasAnnotation("MaxLength", 70);

                    b.Property<string>("BillingCity")
                        .HasAnnotation("MaxLength", 40);

                    b.Property<string>("BillingCountry")
                        .HasAnnotation("MaxLength", 40);

                    b.Property<string>("BillingPostalCode")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("BillingState")
                        .HasAnnotation("MaxLength", 40);

                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2016, 8, 15, 10, 12, 29, 942, DateTimeKind.Local));

                    b.Property<DateTime>("DateModified")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2016, 8, 15, 10, 12, 29, 942, DateTimeKind.Local));

                    b.Property<bool?>("Deleted");

                    b.Property<string>("Guid")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken();

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .HasName("IFK_InvoiceCustomerId");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("DotNetCoreTestWebProject.Models.InvoiceLine", b =>
                {
                    b.Property<int>("Id");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2016, 8, 15, 10, 12, 29, 950, DateTimeKind.Local));

                    b.Property<DateTime>("DateModified")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2016, 8, 15, 10, 12, 29, 950, DateTimeKind.Local));

                    b.Property<bool?>("Deleted");

                    b.Property<string>("Guid")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<int>("InvoiceId");

                    b.Property<int>("Quantity");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken();

                    b.Property<int>("TrackId");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId")
                        .HasName("IFK_InvoiceLineInvoiceId");

                    b.HasIndex("TrackId")
                        .HasName("IFK_InvoiceLineTrackId");

                    b.ToTable("InvoiceLine");
                });

            modelBuilder.Entity("DotNetCoreTestWebProject.Models.MediaType", b =>
                {
                    b.Property<int>("Id");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2016, 8, 15, 10, 12, 29, 953, DateTimeKind.Local));

                    b.Property<DateTime>("DateModified")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2016, 8, 15, 10, 12, 29, 953, DateTimeKind.Local));

                    b.Property<bool?>("Deleted");

                    b.Property<string>("Guid")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 120);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken();

                    b.HasKey("Id");

                    b.ToTable("MediaType");
                });

            modelBuilder.Entity("DotNetCoreTestWebProject.Models.Playlist", b =>
                {
                    b.Property<int>("Id");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2016, 8, 15, 10, 12, 29, 956, DateTimeKind.Local));

                    b.Property<DateTime>("DateModified")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2016, 8, 15, 10, 12, 29, 956, DateTimeKind.Local));

                    b.Property<bool?>("Deleted");

                    b.Property<string>("Guid")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 120);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken();

                    b.HasKey("Id");

                    b.ToTable("Playlist");
                });

            modelBuilder.Entity("DotNetCoreTestWebProject.Models.PlaylistTrack", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("TrackId");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2016, 8, 15, 10, 12, 29, 966, DateTimeKind.Local));

                    b.Property<DateTime>("DateModified")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2016, 8, 15, 10, 12, 29, 966, DateTimeKind.Local));

                    b.Property<bool?>("Deleted");

                    b.Property<string>("Guid")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken();

                    b.HasKey("Id", "TrackId")
                        .HasName("PK_PlaylistTrack");

                    b.HasIndex("Id");

                    b.HasIndex("TrackId")
                        .HasName("IFK_PlaylistTrackTrackId");

                    b.ToTable("PlaylistTrack");
                });

            modelBuilder.Entity("DotNetCoreTestWebProject.Models.Track", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int?>("AlbumId");

                    b.Property<int?>("Bytes");

                    b.Property<string>("Composer")
                        .HasAnnotation("MaxLength", 220);

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2016, 8, 15, 10, 12, 29, 977, DateTimeKind.Local));

                    b.Property<DateTime>("DateModified")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2016, 8, 15, 10, 12, 29, 977, DateTimeKind.Local));

                    b.Property<bool?>("Deleted");

                    b.Property<int?>("GenreId");

                    b.Property<string>("Guid")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<int>("MediaTypeId");

                    b.Property<int>("Milliseconds");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 200);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken();

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

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
                        .HasForeignKey("ArtistId")
                        .HasConstraintName("FK_AlbumArtistId");
                });

            modelBuilder.Entity("DotNetCoreTestWebProject.Models.Customer", b =>
                {
                    b.HasOne("DotNetCoreTestWebProject.Models.Employee", "SupportRep")
                        .WithMany("Customer")
                        .HasForeignKey("SupportRepId")
                        .HasConstraintName("FK_CustomerSupportRepId");
                });

            modelBuilder.Entity("DotNetCoreTestWebProject.Models.Employee", b =>
                {
                    b.HasOne("DotNetCoreTestWebProject.Models.Employee", "ReportsToNavigation")
                        .WithMany("InverseReportsToNavigation")
                        .HasForeignKey("ReportsTo")
                        .HasConstraintName("FK_EmployeeReportsTo");
                });

            modelBuilder.Entity("DotNetCoreTestWebProject.Models.Invoice", b =>
                {
                    b.HasOne("DotNetCoreTestWebProject.Models.Customer", "Customer")
                        .WithMany("Invoice")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_InvoiceCustomerId");
                });

            modelBuilder.Entity("DotNetCoreTestWebProject.Models.InvoiceLine", b =>
                {
                    b.HasOne("DotNetCoreTestWebProject.Models.Invoice", "Invoice")
                        .WithMany("InvoiceLine")
                        .HasForeignKey("InvoiceId")
                        .HasConstraintName("FK_InvoiceLineInvoiceId");

                    b.HasOne("DotNetCoreTestWebProject.Models.Track", "Track")
                        .WithMany("InvoiceLine")
                        .HasForeignKey("TrackId")
                        .HasConstraintName("FK_InvoiceLineTrackId");
                });

            modelBuilder.Entity("DotNetCoreTestWebProject.Models.PlaylistTrack", b =>
                {
                    b.HasOne("DotNetCoreTestWebProject.Models.Playlist", "IdNavigation")
                        .WithMany("PlaylistTrack")
                        .HasForeignKey("Id")
                        .HasConstraintName("FK_PlaylistTrackPlaylistId");

                    b.HasOne("DotNetCoreTestWebProject.Models.Track", "Track")
                        .WithMany("PlaylistTrack")
                        .HasForeignKey("TrackId")
                        .HasConstraintName("FK_PlaylistTrackTrackId");
                });

            modelBuilder.Entity("DotNetCoreTestWebProject.Models.Track", b =>
                {
                    b.HasOne("DotNetCoreTestWebProject.Models.Album", "Album")
                        .WithMany("Track")
                        .HasForeignKey("AlbumId")
                        .HasConstraintName("FK_TrackAlbumId");

                    b.HasOne("DotNetCoreTestWebProject.Models.Genre", "Genre")
                        .WithMany("Track")
                        .HasForeignKey("GenreId")
                        .HasConstraintName("FK_TrackGenreId");

                    b.HasOne("DotNetCoreTestWebProject.Models.MediaType", "MediaType")
                        .WithMany("Track")
                        .HasForeignKey("MediaTypeId")
                        .HasConstraintName("FK_TrackMediaTypeId");
                });
        }
    }
}

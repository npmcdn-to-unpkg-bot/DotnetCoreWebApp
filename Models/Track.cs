using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Models
{
    public partial class Track
    {
        public Track()
        {
            InvoiceLine = new HashSet<InvoiceLine>();
            PlaylistTrack = new HashSet<PlaylistTrack>();
        }

        public long TrackId { get; set; }
        [Required]
        [Column(TypeName = "NVARCHAR(200)")]
        public string Name { get; set; }
        public long? AlbumId { get; set; }
        public long MediaTypeId { get; set; }
        public long? GenreId { get; set; }
        [Column(TypeName = "NVARCHAR(220)")]
        public string Composer { get; set; }
        public long Milliseconds { get; set; }
        public long? Bytes { get; set; }
        [Required]
        [Column(TypeName = "NUMERIC(10,2)")]
        public string UnitPrice { get; set; }

        [InverseProperty("Track")]
        public virtual ICollection<InvoiceLine> InvoiceLine { get; set; }
        [InverseProperty("Track")]
        public virtual ICollection<PlaylistTrack> PlaylistTrack { get; set; }
        [ForeignKey("AlbumId")]
        [InverseProperty("Track")]
        public virtual Album Album { get; set; }
        [ForeignKey("GenreId")]
        [InverseProperty("Track")]
        public virtual Genre Genre { get; set; }
        [ForeignKey("MediaTypeId")]
        [InverseProperty("Track")]
        public virtual MediaType MediaType { get; set; }
    }
}

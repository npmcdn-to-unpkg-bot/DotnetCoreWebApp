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

        public int TrackId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        public int? AlbumId { get; set; }
        public int MediaTypeId { get; set; }
        public int? GenreId { get; set; }
        [MaxLength(220)]
        public string Composer { get; set; }
        public int Milliseconds { get; set; }
        public int? Bytes { get; set; }
        [Column(TypeName = "numeric")]
        public decimal UnitPrice { get; set; }

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

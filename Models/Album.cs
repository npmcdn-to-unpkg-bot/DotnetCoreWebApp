using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Models
{
    public partial class Album
    {
        public Album()
        {
            Track = new HashSet<Track>();
        }

        public long AlbumId { get; set; }
        [Required]
        [Column(TypeName = "NVARCHAR(160)")]
        public string Title { get; set; }
        public long ArtistId { get; set; }

        [InverseProperty("Album")]
        public virtual ICollection<Track> Track { get; set; }
        [ForeignKey("ArtistId")]
        [InverseProperty("Album")]
        public virtual Artist Artist { get; set; }
    }
}

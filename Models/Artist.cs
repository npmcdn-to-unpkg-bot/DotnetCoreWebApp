using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Models
{
    public partial class Artist
    {
        public Artist()
        {
            Album = new HashSet<Album>();
        }

        public int ArtistId { get; set; }
        [MaxLength(120)]
        public string Name { get; set; }

        [InverseProperty("Artist")]
        public virtual ICollection<Album> Album { get; set; }
    }
}

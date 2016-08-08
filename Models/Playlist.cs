using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Models
{
    public partial class Playlist
    {
        public Playlist()
        {
            PlaylistTrack = new HashSet<PlaylistTrack>();
        }

        public int PlaylistId { get; set; }
        [MaxLength(120)]
        public string Name { get; set; }

        [InverseProperty("Playlist")]
        public virtual ICollection<PlaylistTrack> PlaylistTrack { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Models
{
    public partial class PlaylistTrack
    {
        public long PlaylistId { get; set; }
        public long TrackId { get; set; }

        [ForeignKey("PlaylistId")]
        [InverseProperty("PlaylistTrack")]
        public virtual Playlist Playlist { get; set; }
        [ForeignKey("TrackId")]
        [InverseProperty("PlaylistTrack")]
        public virtual Track Track { get; set; }
    }
}

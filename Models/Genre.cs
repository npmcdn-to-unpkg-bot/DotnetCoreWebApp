using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Track = new HashSet<Track>();
        }

        public int GenreId { get; set; }
        [MaxLength(120)]
        public string Name { get; set; }

        [InverseProperty("Genre")]
        public virtual ICollection<Track> Track { get; set; }
    }
}

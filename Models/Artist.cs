using System;
using System.Collections.Generic;
using Core.Common.Data;

namespace TestProject.Models
{
    public partial class Artist : BaseObjectWithState, IObjectWithState
    {
        public Artist()
        {
            Album = new HashSet<Album>();
            Guid = System.Guid.NewGuid().ToString("N");
            DateCreated = DateTime.Now;
            DateModified = DateCreated;
        }

        public int ArtistId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Album> Album { get; set; }
    }
}

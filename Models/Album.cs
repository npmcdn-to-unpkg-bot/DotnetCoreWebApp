using System.Collections.Generic;
using Core.Common.Data;

namespace DotNetCoreTestWebProject.Models
{
    public partial class Album  : BaseObjectWithState, IObjectWithState
    {
        public Album()
        {
            Track = new HashSet<Track>();
        }


        public string Title { get; set; }
        public int ArtistId { get; set; }

        public virtual ICollection<Track> Track { get; set; }
        public virtual Artist Artist { get; set; }
    }
}

using System.Collections.Generic;
using Core.Common.Data;

namespace DotNetCoreTestWebProject.Models
{
    public partial class Playlist  : BaseObjectWithState, IObjectWithState
    {
        public Playlist()
        {
            PlaylistTrack = new HashSet<PlaylistTrack>();
        }

        public string Name { get; set; }

        public virtual ICollection<PlaylistTrack> PlaylistTrack { get; set; }
    }
}

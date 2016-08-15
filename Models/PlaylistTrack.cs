using Core.Common.Data;

namespace DotNetCoreTestWebProject.Models
{
    public partial class PlaylistTrack  : BaseObjectWithState, IObjectWithState
    {
        public int TrackId { get; set; }

        public virtual Playlist IdNavigation { get; set; }
        public virtual Track Track { get; set; }
    }
}

using System.Collections.Generic;
using Core.Common.Data;

namespace DotNetCoreTestWebProject.Models
{
    public partial class MediaType  : BaseObjectWithState, IObjectWithState
    {
        public MediaType()
        {
            Track = new HashSet<Track>();
        }

        public string Name { get; set; }

        public virtual ICollection<Track> Track { get; set; }
    }
}

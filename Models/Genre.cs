using System.Collections.Generic;
using Core.Common.Data;

namespace DotNetCoreTestWebProject.Models
{
    public partial class Genre  : BaseObjectWithState, IObjectWithState
    {
        public Genre()
        {
            Track = new HashSet<Track>();
        }

        public string Name { get; set; }

        public virtual ICollection<Track> Track { get; set; }
    }
}

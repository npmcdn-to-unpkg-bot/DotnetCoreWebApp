using System.Collections.Generic;
using Core.Common.Data;

namespace DotNetCoreTestWebProject.Models
{
    public partial class Artist : BaseObjectWithState, IObjectWithState
    {
        public Artist()
        {
            Album = new HashSet<Album>();
        }

        public string Name { get; set; }

        public virtual ICollection<Album> Album { get; set; }
    }
}

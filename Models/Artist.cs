using System;
using System.Collections.Generic;
using Core.Common.Data;
using Core.Common.Utilities;

namespace DotNetCoreTestWebProject.Models
{
    public partial class Artist : BaseObjectWithState, IObjectWithState
    {
        public Artist()
        {
            Album = new HashSet<Album>();
            Guid = StringUtils.GenerateLowercase32DigitsGuid();
            DateCreated = DateTime.Now;
            DateModified = DateCreated;
        }

        public string Name { get; set; }

        public virtual ICollection<Album> Album { get; set; }
    }
}

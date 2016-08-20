﻿using System;
using System.Collections.Generic;
using Core.Common.Data;
using Core.Common.Utilities;

namespace DotNetCoreTestWebProject.Models
{
    public partial class Playlist : BaseObjectWithState, IObjectWithState
    {
        public Playlist()
        {
            PlaylistTrack = new HashSet<PlaylistTrack>();
            Guid = StringUtils.GenerateLowercase32DigitsGuid();
            DateCreated = DateTime.Now;
            DateModified = DateCreated;
        }

        public long PlaylistId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PlaylistTrack> PlaylistTrack { get; set; }
    }
}

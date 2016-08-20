﻿using System;
using System.Collections.Generic;
using Core.Common.Data;
using Core.Common.Utilities;

namespace DotNetCoreTestWebProject.Models
{
    public partial class Track : BaseObjectWithState, IObjectWithState
    {
        public Track()
        {
            InvoiceLine = new HashSet<InvoiceLine>();
            PlaylistTrack = new HashSet<PlaylistTrack>();
            Guid = StringUtils.GenerateLowercase32DigitsGuid();
            DateCreated = DateTime.Now;
            DateModified = DateCreated;
        }

        public long TrackId { get; set; }
        public string Name { get; set; }
        public long? AlbumId { get; set; }
        public long MediaTypeId { get; set; }
        public long? GenreId { get; set; }
        public string Composer { get; set; }
        public long Milliseconds { get; set; }
        public long? Bytes { get; set; }
        public string UnitPrice { get; set; }

        public virtual ICollection<InvoiceLine> InvoiceLine { get; set; }
        public virtual ICollection<PlaylistTrack> PlaylistTrack { get; set; }
        public virtual Album Album { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual MediaType MediaType { get; set; }
    }
}

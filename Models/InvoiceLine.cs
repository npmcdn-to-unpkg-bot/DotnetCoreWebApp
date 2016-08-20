﻿using System;
using Core.Common.Data;
using Core.Common.Utilities;

namespace DotNetCoreTestWebProject.Models
{
    public partial class InvoiceLine : BaseObjectWithState, IObjectWithState
    {
        public InvoiceLine()
        {
            Guid = StringUtils.GenerateLowercase32DigitsGuid();
            DateCreated = DateTime.Now;
            DateModified = DateCreated;
        }
        public long InvoiceLineId { get; set; }
        public long InvoiceId { get; set; }
        public long TrackId { get; set; }
        public string UnitPrice { get; set; }
        public long Quantity { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual Track Track { get; set; }
    }
}

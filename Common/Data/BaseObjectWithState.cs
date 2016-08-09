﻿using System;

namespace Core.Common.Data
{
    public abstract class BaseObjectWithState
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public ObjectState ObjectState { get; set; }
        public byte[] RowVersion { get; set; }
        public bool? Deleted { get; set; }
    }
}
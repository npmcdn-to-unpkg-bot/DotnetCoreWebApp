using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Models
{
    public partial class InvoiceLine
    {
        public int InvoiceLineId { get; set; }
        public int InvoiceId { get; set; }
        public int TrackId { get; set; }
        [Column(TypeName = "numeric")]
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("InvoiceId")]
        [InverseProperty("InvoiceLine")]
        public virtual Invoice Invoice { get; set; }
        [ForeignKey("TrackId")]
        [InverseProperty("InvoiceLine")]
        public virtual Track Track { get; set; }
    }
}

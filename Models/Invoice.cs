using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            InvoiceLine = new HashSet<InvoiceLine>();
        }

        public long InvoiceId { get; set; }
        public long CustomerId { get; set; }
        [Required]
        [Column(TypeName = "DATETIME")]
        public string InvoiceDate { get; set; }
        [Column(TypeName = "NVARCHAR(70)")]
        public string BillingAddress { get; set; }
        [Column(TypeName = "NVARCHAR(40)")]
        public string BillingCity { get; set; }
        [Column(TypeName = "NVARCHAR(40)")]
        public string BillingState { get; set; }
        [Column(TypeName = "NVARCHAR(40)")]
        public string BillingCountry { get; set; }
        [Column(TypeName = "NVARCHAR(10)")]
        public string BillingPostalCode { get; set; }
        [Required]
        [Column(TypeName = "NUMERIC(10,2)")]
        public string Total { get; set; }

        [InverseProperty("Invoice")]
        public virtual ICollection<InvoiceLine> InvoiceLine { get; set; }
        [ForeignKey("CustomerId")]
        [InverseProperty("Invoice")]
        public virtual Customer Customer { get; set; }
    }
}

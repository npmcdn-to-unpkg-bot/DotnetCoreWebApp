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

        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime InvoiceDate { get; set; }
        [MaxLength(70)]
        public string BillingAddress { get; set; }
        [MaxLength(40)]
        public string BillingCity { get; set; }
        [MaxLength(40)]
        public string BillingState { get; set; }
        [MaxLength(40)]
        public string BillingCountry { get; set; }
        [MaxLength(10)]
        public string BillingPostalCode { get; set; }
        [Column(TypeName = "numeric")]
        public decimal Total { get; set; }

        [InverseProperty("Invoice")]
        public virtual ICollection<InvoiceLine> InvoiceLine { get; set; }
        [ForeignKey("CustomerId")]
        [InverseProperty("Invoice")]
        public virtual Customer Customer { get; set; }
    }
}

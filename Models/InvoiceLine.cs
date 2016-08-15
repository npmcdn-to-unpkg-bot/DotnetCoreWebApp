using Core.Common.Data;

namespace DotNetCoreTestWebProject.Models
{
    public partial class InvoiceLine  : BaseObjectWithState, IObjectWithState
    {
        public int InvoiceId { get; set; }
        public int TrackId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual Track Track { get; set; }
    }
}

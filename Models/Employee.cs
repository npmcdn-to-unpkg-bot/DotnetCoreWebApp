using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Customer = new HashSet<Customer>();
        }

        public int EmployeeId { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [MaxLength(30)]
        public string Title { get; set; }
        public int? ReportsTo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? BirthDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? HireDate { get; set; }
        [MaxLength(70)]
        public string Address { get; set; }
        [MaxLength(40)]
        public string City { get; set; }
        [MaxLength(40)]
        public string State { get; set; }
        [MaxLength(40)]
        public string Country { get; set; }
        [MaxLength(10)]
        public string PostalCode { get; set; }
        [MaxLength(24)]
        public string Phone { get; set; }
        [MaxLength(24)]
        public string Fax { get; set; }
        [MaxLength(60)]
        public string Email { get; set; }

        [InverseProperty("SupportRep")]
        public virtual ICollection<Customer> Customer { get; set; }
        [ForeignKey("ReportsTo")]
        [InverseProperty("InverseReportsToNavigation")]
        public virtual Employee ReportsToNavigation { get; set; }
        [InverseProperty("ReportsToNavigation")]
        public virtual ICollection<Employee> InverseReportsToNavigation { get; set; }
    }
}

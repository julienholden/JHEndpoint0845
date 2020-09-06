using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JHEndpoint0845.Models
{
    public partial class AllStaff
    {
        [Key]
        public int Id { get; set; }
        [Column("EmployeeID")]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string Surname { get; set; }
        [StringLength(50)]
        public string ReportsTo { get; set; }
        [Column("YTDSales")]
        public int? Ytdsales { get; set; }
    }
}

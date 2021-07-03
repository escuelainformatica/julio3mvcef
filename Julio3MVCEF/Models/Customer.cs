using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Julio3MVCEF.Models
{
    [Index(nameof(IdCity), Name = "Customers_fk1_idx")]
    public partial class Customer
    {
        [Key]
        [Column("idCustomer")]
        public int IdCustomer { get; set; }
        [Column("fullName")]
        [StringLength(200)]
        public string FullName { get; set; }
        [Column("address")]
        [StringLength(200)]
        public string Address { get; set; }
        [Column("idCity")]
        public int? IdCity { get; set; }
        [Column("email")]
        [StringLength(45)]
        public string Email { get; set; }
        [Column("isBusiness")]
        public byte? IsBusiness { get; set; }
        [Column("password")]
        [StringLength(64)]
        public string Password { get; set; }
        [Column("lastUpdate")]
        public DateTime? LastUpdate { get; set; }


        // Muchos es a uno. 
        // Si tengo un cliente, tengo que tener 1 ciudad.
        [ForeignKey(nameof(IdCity))]
        [InverseProperty(nameof(City.Customers))]
        public virtual City IdCityNavigation { get; set; }
    }
}

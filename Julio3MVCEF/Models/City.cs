using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Julio3MVCEF.Models
{
    [Index(nameof(IdCountry), Name = "idx_fk_idCountry")]
    public partial class City
    {
        public City()
        {
            Customers = new HashSet<Customer>();
        }

        [Key]
        [Column("idCity")]
        public int IdCity { get; set; }
        [Required]
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("idCountry")]
        public int IdCountry { get; set; }
        [Column("population")]
        public int? Population { get; set; }
        [Column("lastUpdate")]
        public DateTime LastUpdate { get; set; }

        // uno es a muchos
        // Si tengo una ciudad, puedo tener una lista de clientes
        [InverseProperty(nameof(Customer.IdCityNavigation))]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}

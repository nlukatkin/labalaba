using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Product
    {
        [Column("ProductId")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string NameProduct { get; set; }

        [Required(ErrorMessage = "Product cost is a required field.")]
        public int Cost { get; set; }

        public Guid AnimalId { get; set; }

        [Required(ErrorMessage = "Product cost is a required field.")]
        public int Quantity { get; set; }
    }
}

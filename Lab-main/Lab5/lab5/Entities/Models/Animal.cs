using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Animal
    {
        [Column("AnimalId")]
        public int Id { get; set; }
        public Guid guid { get; set; }

        [Required(ErrorMessage = "Animal name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string AnimalName { get; set; }

        [Required(ErrorMessage = "Animal Weight  is a required field.")]
       
        public int WeightKg { get; set; }
    }
}

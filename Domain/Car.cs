using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Car
    {
        public int CarId { get; set; }
        
        [Required]
        [MinLength(1)]
        [MaxLength(20)]
        public string CarBrand { get; set; }
        
        [Required]
        [MinLength(1)]
        [MaxLength(20)]
        public string CarModel { get; set; }

        [Required]
        public string ReleaseDate { get; set; }

        public string Owner { get; set; }

        public string CarBrandModel => CarBrand + " " + CarModel;

        public List<CarExpensesInCategory> CarExpensesInCategories { get; set; } = new List<CarExpensesInCategory>();
    }
}
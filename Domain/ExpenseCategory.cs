using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ExpenseCategory
    {
        public int ExpenseCategoryId { get; set; }
        
        [Required]
        [MinLength(1)]
        [MaxLength(20)]
        public string CategoryName { get; set; }
        
        public List<CarExpensesInCategory> CarsExpensesInCategory { get; set; } = new List<CarExpensesInCategory>();
    }
}
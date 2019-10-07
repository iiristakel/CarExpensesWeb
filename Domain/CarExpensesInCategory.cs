using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class CarExpensesInCategory
    {
        public int CarExpensesInCategoryId { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

        public int ExpenseCategoryId { get; set; }
        public ExpenseCategory ExpenseCategory { get; set; }

        [Required]
        [MinLength(1)]
        public string Expense { get; set; }
        
        public string Comments { get; set; }
        
        [Required]
        public DateTime DateTime { get; set; }
    }
}
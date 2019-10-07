using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL;
using Domain;

namespace WebApp.Pages_CarExpensesInCategories
{
    public class CreateModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public CreateModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "CarBrandModel");
        ViewData["ExpenseCategoryId"] = new SelectList(_context.ExpenseCategories, "ExpenseCategoryId", "CategoryName");
            return Page();
        }

        [BindProperty]
        public CarExpensesInCategory CarExpensesInCategory { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CarsExpensesInCategories.Add(CarExpensesInCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        
    }
}
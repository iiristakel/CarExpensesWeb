using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.Pages_CarExpensesInCategories
{
    public class EditModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public EditModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CarExpensesInCategory CarExpensesInCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarExpensesInCategory = await _context.CarsExpensesInCategories
                .Include(c => c.Car)
                .Include(c => c.ExpenseCategory).FirstOrDefaultAsync(m => m.CarExpensesInCategoryId == id);

            if (CarExpensesInCategory == null)
            {
                return NotFound();
            }
           ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "CarBrand");
           ViewData["ExpenseCategoryId"] = new SelectList(_context.ExpenseCategories, "ExpenseCategoryId", "CategoryName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CarExpensesInCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExpensesInCategoryExists(CarExpensesInCategory.CarExpensesInCategoryId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CarExpensesInCategoryExists(int id)
        {
            return _context.CarsExpensesInCategories.Any(e => e.CarExpensesInCategoryId == id);
        }
    }
}

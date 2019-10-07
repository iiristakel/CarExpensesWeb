using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.Pages_CarExpensesInCategories
{
    public class DeleteModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public DeleteModel(DAL.AppDbContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarExpensesInCategory = await _context.CarsExpensesInCategories.FindAsync(id);

            if (CarExpensesInCategory != null)
            {
                _context.CarsExpensesInCategories.Remove(CarExpensesInCategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

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
    public class DetailsModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public DetailsModel(DAL.AppDbContext context)
        {
            _context = context;
        }

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
    }
}

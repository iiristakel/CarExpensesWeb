using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;
using Microsoft.EntityFrameworkCore.Internal;

namespace WebApp.Pages_CarExpensesInCategories
{
    public class IndexModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public IndexModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public string SearchCar { get; set; }
        public string SearchCat { get; set; }
        
        public string Message { get; set; } = "";
        public IList<CarExpensesInCategory> CarExpensesInCategory { get; set; }

        //public IList<ExpenseCategory> Categories { get; set; }

        public List<Car> Cars { get; set; }

        public async Task OnGetAsync(string searchCar, string searchCat)
        {
            var carQuery = _context.Cars
                .Include(p => p.CarExpensesInCategories)
                .AsQueryable();
            
            var query =  _context.CarsExpensesInCategories
                .Include(p => p.ExpenseCategory)
                .Include(q=>q.Car)
                .AsQueryable();
            
            if (!string.IsNullOrEmpty(searchCar))
            {
                searchCar = searchCar.ToLower();
                
                query = query.Where(p =>
                    p.Car.CarBrandModel.ToLower().Contains(searchCar) 
                    || p.Car.Owner.ToLower().Contains(searchCar)
                    );
            }
            
            if (!string.IsNullOrEmpty(searchCat))
            {
                searchCat = searchCat.ToLower();
                
                query = query.Where(p =>
                    p.ExpenseCategory.CategoryName.ToLower().Contains(searchCat)
                );
            }
            
            Cars = await carQuery.ToListAsync();
            CarExpensesInCategory = await query.ToListAsync();
            
            if (CarExpensesInCategory.Count == 0)
            {
                Message = searchCar;
                Message += " " + searchCat;

            }

            SearchCar = searchCar;
            SearchCat = searchCat;

        }
    }
}

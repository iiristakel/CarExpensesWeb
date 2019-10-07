using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarExpensesInCategory> CarsExpensesInCategories { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

    }
}
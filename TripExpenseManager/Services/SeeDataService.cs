using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripExpenseManager.Models;

namespace TripExpenseManager.Services
{
    public class SeeDataService
    {
        private readonly DatabaseContext _context;

        public SeeDataService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task SeedDataAsync()
        {
            var foodCategory = await _context.FindAsync< ExpenseCategory>("Food");

            if(foodCategory is not null)
            {
                return;
            }

            var expenseCategories = new List<ExpenseCategory>
            {
                new("Food"), new("Fuel"), new("entratainment"), new("Shopping"), new("Others")
            };

            var locationCategories = new List<LocationCategory>
            {
                new LocationCategory("Beach", "/images/chair.png"),
                new LocationCategory("City", "/images/city.png")
            };

            foreach (var location in locationCategories)
            {
                await _context.AddItemAsync<LocationCategory>(location);
            }

            foreach (var expense in expenseCategories)
            {
                await _context.AddItemAsync<ExpenseCategory>(expense);
            }
        }
    }
}

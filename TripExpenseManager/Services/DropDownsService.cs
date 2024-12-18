﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripExpenseManager.Services
{
    public class DropDownsService
    {
        private readonly DatabaseContext _context;

        public DropDownsService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<LocationCategory[]> GetLocationCategoriesAsync()
        {
            return (await _context.GetAllAsync<LocationCategory>()).ToArray();
        }

        public string[] GetTripStatuses()
        {
            return Enum.GetNames<TripStatus>();
        }

        public async Task<string[]> GetExpenseCategoriesAsync() => (await _context.GetAllAsync<ExpenseCategory>()).Select(e => e.Name).ToArray();
    }
}


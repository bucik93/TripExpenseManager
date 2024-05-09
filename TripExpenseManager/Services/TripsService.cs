using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripExpenseManager.Services
{
    public class TripsService
    {
        private readonly DatabaseContext _context;

        public TripsService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Trip>> GetTripsAsync(int pageNo = 1, int count = 10)
        {
            var query = await _context.GetTableAsync<Trip>();
            return await query.OrderByDescending(t => t.AddedOn)
                .Skip((pageNo - 1) * count)
                .Take(count)
                .ToArrayAsync();
        }

        public async Task<MethodDataResult<Trip>> SaveTripAsync(Trip trip)
        {
            trip.Status = Enum.Parse<TripStatus>(trip.DisplayStatus);
            try
            {
                if (trip.Id == 0)
                {
                    //create
                    await _context.AddItemAsync<Trip>(trip);
                }
                else
                {
                    //modify
                    await _context.UpdateItemAsync<Trip>(trip);
                }
                return MethodDataResult<Trip>.Success(trip);
            }
            catch (Exception ex)
            {
                return MethodDataResult<Trip>.Fail(ex.Message);
            }
        }

        public async Task<Trip?> GetTripAsync(int tripId, bool includeExpense = false) 
        {
            var trip = await _context.FindAsync<Trip>(tripId);
            if (includeExpense)
            {
                trip.Expenses = await _context.GetFileteredAsync<Expense>(e => e.TripId == tripId)
                    ?? Enumerable.Empty<Expense>();
            }
            return trip;
        }
    }
}

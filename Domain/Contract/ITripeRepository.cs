using Domain.Enum;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract
{
    public interface ITripeRepository
    {
        public Task<IEnumerable<Trips>> GetAllTripsAsync();
        public Task<Trips> GetTripByIdAsync(int id);
        public Task<IEnumerable<Trips>> GetTripsByLocationAsync(Locations location);
        public Task<IEnumerable<Trips>> GetTripsByStatusAsync(Status status);
        public Task<IEnumerable<Trips>> GetTripsByPriceRangeAsync(decimal minPrice, decimal maxPrice);
        public Task<IEnumerable<Trips>> GetTripsByDateRangeAsync(DateTime startDate, DateTime endDate);
        public Task<int> AddTripAsync(Trips trip);
        public Task<int> UpdateTripAsync(Trips trip);
        public Task<bool> DeleteTripAsync(int id);

    }
}

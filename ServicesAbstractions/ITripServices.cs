using Domain.Enum;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesAbstractions
{
    public  interface ITripServices
    {
        public Task<int> AddTripAsync(TripsDto trip);
        public Task<int> UpdateTripAsync(TripsDto trip,int id);
        public Task<TripsDto> GetTripByIdAsync(int id);
        public Task<bool> DeleteTripAsync(int id);
        public Task<IEnumerable<TripsDto>> GetAllTripsAsync();
        public Task<IEnumerable<TripsDto>> GetTripsByDateRangeAsync(DateTime startDate, DateTime endDate);
        public Task<IEnumerable<TripsDto>> GetTripsByStatusAsync(Status status);
        public Task<IEnumerable<TripsDto>> GetTripsByLocationAsync(Locations location);
        public Task<IEnumerable<TripsDto>> GetTripsByPriceRangeAsync(decimal minPrice, decimal maxPrice);
        
    }
}

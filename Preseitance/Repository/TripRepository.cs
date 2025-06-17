using Domain.Contract;
using Domain.Enum;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class TripRepository(ApplicationDbContext _Context) : ITripeRepository
    {
        private readonly ApplicationDbContext _context = _Context;
        //Add Trip
        public async Task<int> AddTripAsync(Trips trip)
        {

            var addedTrip = await _context.Set<Trips>().AddAsync(trip);

            if (addedTrip == null)
            {
                throw new InvalidOperationException("Failed to add trip.");
            }
            return await _context.SaveChangesAsync();
        }
        //Update Trip
        public Task<int> UpdateTripAsync(Trips trip)
        {
            var updatedTrip = _context.Set<Trips>().Update(trip);
            if (updatedTrip == null)
            {
                throw new InvalidOperationException("Failed to update trip.");
            }
            return _context.SaveChangesAsync();
        }
        //Get Trip By Id
        public async Task<Trips> GetTripByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Trip ID must be greater than zero.", nameof(id));
            }
            var trip = _context.Set<Trips>().Find(id);
            if (trip == null)
            {
                throw new KeyNotFoundException($"Trip with ID {id} not found.");
            }
            return await Task.FromResult(trip);
        }
        // Delete Trip
        public async Task<bool> DeleteTripAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Trip ID must be greater than zero.", nameof(id));
            }

            var trip = _context.Set<Trips>().Find(id);
            if (trip == null)
            {
                throw new KeyNotFoundException($"Trip with ID {id} not found.");
            }

             _context.Set<Trips>().Remove(trip);
            return await _context.SaveChangesAsync().ContinueWith(t => t.Result > 0);
        }
        // Return All Trips
        public async Task<IEnumerable<Trips>> GetAllTripsAsync()
        {
            return await _context.Set<Trips>().ToListAsync();
        }
        // Get Trips By Location
        public async Task<IEnumerable<Trips>> GetTripsByLocationAsync(string location)
        {


          var result= await _context.Set<Trips>().Where(t => t.Location == location).ToListAsync().ContinueWith(t => (IEnumerable<Trips>)t.Result);
           
            return result!;
        }
        //Get Trips By Status
        public async Task<IEnumerable<Trips>> GetTripsByStatusAsync(string status)
        {
            var result = await _context.Set<Trips>().Where(t => t.Status == status).ToListAsync().ContinueWith(t => (IEnumerable<Trips>)t.Result);
           
            return result;
        }
        // Get Trips By Price Range
        public Task<IEnumerable<Trips>> GetTripsByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            return _context.Set<Trips>()
                .Where(t => t.Price >= minPrice && t.Price <= maxPrice)
                .ToListAsync()
                .ContinueWith(t => (IEnumerable<Trips>)t.Result);
        }
        // Get Trips By Date Range
        public Task<IEnumerable<Trips>> GetTripsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
           
            return _context.Set<Trips>()
                .Where(t => t.StartTripe >= startDate && t.EndTripe <= endDate)
                .ToListAsync()
                .ContinueWith(t => (IEnumerable<Trips>)t.Result);
        }
    }
}

using Domain.Contract;
using Domain.Enum;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicesAbstractions;
using Shared;
using Services.mapping;
using AutoMapper;
namespace Services
{
    public class TripServices(ITripeRepository  repository,IMapper mapper) : ITripServices

    {
        private readonly ITripeRepository _repository = repository;

        //Get all trips
        public async Task<IEnumerable<TripsDto>> GetAllTripsAsync()
        {
            var trips =await _repository.GetAllTripsAsync();

            var result = mapper.Map<IEnumerable<TripsDto>>(trips);
            return result;

        }
        //Get trips by user ID
        public async Task<TripsDto> GetTripByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Trip ID must be greater than zero.", nameof(id));
            }
            var trip = await _repository.GetTripByIdAsync(id);
            if (trip is null)
            {
                throw new Exception($"Trip with ID {id} not found.");
            }
            var result = mapper.Map<TripsDto>(trip);
            return result;
        }
        // Update Trip
        public async Task<int> UpdateTripAsync(TripsDto trip, int id)
        {
            if (trip == null)
            {
                throw new ArgumentNullException(nameof(trip), "Trip cannot be null.");
            }
            if (id <= 0)
            {
                throw new ArgumentException("Trip ID must be greater than zero.", nameof(id));
            }

            var tripEntity = mapper.Map<Trips>(trip);
            tripEntity.Id = id; // Ensure the ID is set for the update
            if(GetTripByIdAsync(id) is null)
            {
                throw new Exception($"Trip with ID {id} not found.");
            }
            return await _repository.UpdateTripAsync(tripEntity);

        }
        // Add Trip
        public async Task<int> AddTripAsync(TripsDto trip)
        {
           var result=await  _repository.AddTripAsync(mapper.Map<Trips>(trip));
           return result;
        }
        // Delete Trip
        public async Task<bool> DeleteTripAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Trip ID must be greater than zero.", nameof(id));
            }
            var trip = _repository.GetTripByIdAsync(id);
            if (trip is null)
            {
                throw new Exception($"Trip with ID {id} not found.");
            }
            return await _repository.DeleteTripAsync(id);
        }
        // Get Trips By Date Range
        public async Task<IEnumerable<TripsDto>> GetTripsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
           if(startDate > endDate)
            {
                throw new ArgumentException("Start date cannot be later than end date.");
            }
            return await _repository.GetTripsByDateRangeAsync(startDate, endDate)
                .ContinueWith(t => mapper.Map<List<TripsDto>>(t.Result));
        }
        // Get Trips By Status
        public async Task<IEnumerable<TripsDto>> GetTripsByStatusAsync(string status)
        {
            // convert status to enum
            if (string.IsNullOrEmpty(status))
            {
                throw new ArgumentException("Status cannot be null or empty.", nameof(status));
            }
            if (!Enum.TryParse<Status>(status, true, out var tripStatus))
            {
                throw new ArgumentException($"Invalid status value: {status}", nameof(status));
            }
            return await _repository.GetTripsByStatusAsync(tripStatus)
                .ContinueWith(t => mapper.Map<List<TripsDto>>(t.Result));
        }
        // Get Trips By Location
        public async Task<IEnumerable<TripsDto>> GetTripsByLocationAsync(string location)
        {
           if (string.IsNullOrEmpty(location))
            {
                throw new ArgumentException("Location cannot be null or empty.", nameof(location));
            }
            if (!Enum.TryParse<Locations>(location, true, out var tripLocation))
            {
                throw new ArgumentException($"Invalid location value: {location}", nameof(location));
            }
            return await _repository.GetTripsByLocationAsync(tripLocation)
                .ContinueWith(t => mapper.Map<IEnumerable<TripsDto>>(t.Result));
        }
        // Get Trips By Price Range
        public Task<IEnumerable<TripsDto>> GetTripsByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            if(minPrice < 0 || maxPrice < 0)
            {
                throw new ArgumentException("Price cannot be negative.");
            }
            if (minPrice > maxPrice)
            {
                throw new ArgumentException("Minimum price cannot be greater than maximum price.");
            }
            return _repository.GetTripsByPriceRangeAsync(minPrice, maxPrice)
                .ContinueWith(t => mapper.Map<IEnumerable<TripsDto>>(t.Result));
        }

       
    }
}

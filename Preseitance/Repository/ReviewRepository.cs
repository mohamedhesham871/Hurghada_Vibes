﻿using Domain.Contract;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class ReviewRepository(ApplicationDbContext context) : IReviewRepository
    {
        private readonly ApplicationDbContext _context = context;

        public Task<int> AddReviewAsync(Review review)
        {
            var addedReview = _context.Set<Review>().Add(review);
            if (addedReview == null)
            {
                throw new InvalidOperationException("Failed to add review.");
            }
            return _context.SaveChangesAsync();
        }

        public   bool DeleteReviewAsync(int id)
         {
           var  review = _context.Set<Review>().Find(id);
            if (review == null)
            {
                throw new KeyNotFoundException($"Review with ID {id} not found.");

            }
            var result = _context.Set<Review>().Remove(review);
            _context.SaveChanges();

            return true;
        }

        public async Task<IEnumerable<Review>> GetAllReviewsofTripAsync(int idTrip)
        {
           

            var result = await _context.Set<Review>().Where(r => r.TripId == idTrip).ToListAsync();
            return result;

        }

        public async Task<int> UpdateReviewAsync(Review review,int id)
        {
            if(_context.Set<Review>().Find(id) == null)
            {
                throw new KeyNotFoundException($"Review with ID {id} not found.");
            }
            var updatedReview =  _context.Set<Review>().Update(review);
            return await _context.SaveChangesAsync();
        }

        
    }
}

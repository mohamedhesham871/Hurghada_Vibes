using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract
{
    public  interface IReviewRepository
    {
        public Task<IEnumerable<Review>> GetAllReviewsofTripAsync(int idTrip);
        public Task<int> AddReviewAsync(Review review);
        public Task<int> UpdateReviewAsync(Review review,int id);
        public bool DeleteReviewAsync(int id);
    }
}

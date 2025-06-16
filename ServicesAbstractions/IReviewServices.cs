using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesAbstractions
{
    public interface IReviewServices
    {
        public Task<IEnumerable<ReviewDto>> GetAllReviewsOfTripAsync(int Tripid);
        public Task<int> AddReviewAsync(ReviewDto review);
        public Task<int> UpdateReviewAsync(ReviewDto review, int id);
        public bool DeleteReviewAsync(int id);
    }
}

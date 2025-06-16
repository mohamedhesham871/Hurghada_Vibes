using AutoMapper;
using Domain.Contract;
using Domain.Models;
using ServicesAbstractions;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ReviewServices(IReviewRepository repository,ITripeRepository tripeRepository,IMapper mapper) : IReviewServices
    {
        private readonly IReviewRepository _repository = repository;

        public async  Task<int> AddReviewAsync(ReviewDto review)
        {
            if(review == null)
            {
                throw new ArgumentNullException(nameof(review), "Review cannot be null.");
            }
            if (string.IsNullOrWhiteSpace(review.Description))
            {
                throw new ArgumentException("Review content cannot be empty.", nameof(review.Description));
            }
            if (review.Rate < 1 || review.Rate > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(review.Rate), "Rating must be between 1 and 5.");
            }

            var Review = mapper.Map<Reviews>(review);

            
            return  await _repository.AddReviewAsync(Review);


        }
        public bool DeleteReviewAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Review ID must be greater than zero.", nameof(id));
            }
            var result = _repository.DeleteReviewAsync(id);
            if (!result)
            {
                throw new KeyNotFoundException($"Review with ID {id} not found.");
            }
            return result;
        }
        public async Task<IEnumerable<ReviewDto>> GetAllReviewsOfTripAsync(int Tripid)
        {
            if(Tripid <= 0)
            {
                throw new ArgumentException("Trip ID must be greater than zero.", nameof(Tripid));
            }
            var reviews = await tripeRepository.GetTripByIdAsync(Tripid);
            if (reviews == null)
            {
                throw new KeyNotFoundException($"Trip with ID {Tripid} not found.");
            }
            var result = await _repository.GetAllReviewsofTripAsync(Tripid);
            return mapper.Map<IEnumerable<ReviewDto>>(result);
        }
        public Task<int> UpdateReviewAsync(ReviewDto review, int id)
        {
            if(id <= 0) { throw new ArgumentException("Review ID must be greater than zero.", nameof(id)); }
            if (review == null)
            {
                throw new ArgumentNullException(nameof(review), "Review cannot be null.");
            }
            var Review = mapper.Map<Reviews>(review);
            var result = _repository.UpdateReviewAsync(Review, id);
            return result;
        }
    }
}

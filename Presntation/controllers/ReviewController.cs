using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ServicesAbstractions;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.controllers
{
    public class ReviewController(IReviewServices services):ControllerBase
    {
        [HttpGet("Reviews")]

        public async Task<IActionResult> GetAllReviewsOfTripAsync([FromQuery]int Tripid)
        {
            try
            {
                var reviews = await services.GetAllReviewsOfTripAsync(Tripid);
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddReview")]
        public async Task<IActionResult> AddReviewAsync([FromBody] ReviewDto review)
        {
            try
            {
                if (review == null)
                {
                    return BadRequest("Review cannot be null.");
                }
                var result = await services.AddReviewAsync(review);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateReview")]
        public async Task<IActionResult> UpdateReviewAsync([FromBody] ReviewDto review,[FromQuery] int id)
        {
            try
            {
                if (review == null)
                {
                    return BadRequest("Review cannot be null.");
                }
                var result = await services.UpdateReviewAsync(review, id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteReview")]
        public IActionResult DeleteReviewAsync([FromQuery] int id)
        {
            try
            {
                
                var result = services.DeleteReviewAsync(id);
                if (!result)
                {
                    return NotFound($"Review with ID {id} not found.");
                }
                return Ok($"Review with ID {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
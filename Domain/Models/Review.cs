using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Review
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        [Range(1,5)]
        public required int Rate { get; set; }
        public required string Description { get; set; }
        //Foreign key
        public int TripId { get; set; }
        //navigation property
        public Trips? Trip { get; set; }
    }
}

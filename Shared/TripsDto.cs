using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public  class TripsDto
    {
        public required string Title { get; set; }
        public required string Description { get; set; } 
        public Locations Location { get; set; }
        public decimal Price { get; set; }      
        public DateTime? StartTripe { get; set; } 
        public DateTime? EndTripe { get; set; }  
        public string Duration { get; set; } = string.Empty;
        public List<string> AvailableDays { get; set; } = new List<string>();
        public string TimeOfDeparture { get; set; } = null!; 
        public bool IsChildrenAllowed { get; set; }
        public int GroupSizeMax { get; set; }
        public List<string> SuitableFor { get; set; } = new List<string>();
        public string MeetingPoint { get; set; } = string.Empty;
        public List<string> Images { get; set; } = new List<string>();
        public List<string> Tags { get; set; } = new List<string>();
        public Status? Status { get; set; }  
    }
}

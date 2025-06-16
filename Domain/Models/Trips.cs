using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Trips
    {
        public required int Id { get; set; } // 1
        public required string Title { get; set; } // "Hurghada Desert Safari"
        public required string Description { get; set; } // "Experience a thrilling jeep safari through the Hurghada desert."
        public Locations Location { get; set; }  //Cairo, Alexandria, Hurghada
        public decimal Price { get; set; }       // 600.00 EGP
        public DateTime? StartTripe { get; set; } //2025-7-5
        public DateTime? EndTripe { get; set; }  //2025-7-9
        public string Duration { get; set; } = string.Empty; //Four Days
        public List<string> AvailableDays { get; set; } = new List<string>();//["Monday", "Thursday", "Saturday"], #####
        public string TimeOfDeparture { get; set; } = null!; //"3:00 PM" // "3:00 PM"
        public bool IsChildrenAllowed { get; set; } // true
        public int GroupSizeMax { get; set; }
        public List<string> SuitableFor { get; set; } = new List<string>();//["Families", "Adventurers"],
        public string MeetingPoint { get; set; } = string.Empty; //"Hotel Pla Pla" 
        public List<string> Images { get; set; } = new List<string>();
        public List<string> Tags { get; set; } = new List<string>();
        public Status? Status { get; set; } // Active, Inactive, SoldOut, Upcoming
        public List<Reviews> Reviews { get; set; } = new List<Reviews>(); // List of reviews for the trip

    }
}
/*
 {
  "title": "Hurghada Desert Safari",
  "description": "Experience a thrilling jeep safari through the Hurghada desert.",
  "location": "Hurghada",
  "duration": "4 hours",
  "price": 600,
  "currency": "EGP",
  "available_days": 
  "time_of_departure": "3:00 PM",
  "group_size_max": 10,
  "suitable_for": ["Families", "Adventurers"],
  "meeting_point": "Hotel Pickup",
  "images": ["img1.jpg", "img2.jpg"],
  "tags": ["Desert", "Safari", "Adventure"],
  "status": "Active",
}
*/
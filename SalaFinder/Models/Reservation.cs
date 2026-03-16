using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalaFinder.Models
{
    public class Reservation
    {
        [Key] 
        public Guid id_reservation { get; set; } = Guid.NewGuid();

        [ForeignKey("Space")]
        public string spaceId { get; set; } 

        [ForeignKey("User")]
        public string userId { get; set; } 

        public DateTime date { get; set; }

        public TimeSpan startTime { get; set; }

        public TimeSpan endTime { get; set; }

        public string purpose { get; set; }

        public int attendeeCount { get; set; }

        public string status { get; set; }

        
    }
}

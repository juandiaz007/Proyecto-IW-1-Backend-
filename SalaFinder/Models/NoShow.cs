using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalaFinder.Models
{
    public class NoShow
    {
        [Key] 
        public Guid id { get; set; } = Guid.NewGuid();

        [ForeignKey("User")]
        public string userId { get; set; } 

        public int count { get; set; }

        public DateTime blockedUntil { get; set; }
    }
}

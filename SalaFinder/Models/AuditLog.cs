using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalaFinder.Models
{
    public class AuditLog
    {
        [Key] 
        public Guid id_log { get; set; } = Guid.NewGuid();

        [ForeignKey("User")]
        public string userId { get; set; } 

        public string action { get; set; }

        public string entity { get; set; }

        public DateTime timestamp { get; set; } = DateTime.UtcNow;
    }
}

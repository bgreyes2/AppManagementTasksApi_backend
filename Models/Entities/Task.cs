using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppManagementTaskApi.Net.Models.Entities
{
    public class TaskEntities
    {
        [Key]
        public int id_task { get; set; }

        [Required]
        [MaxLength(200)]
        public string title { get; set; } = string.Empty;

        [MaxLength(200)]
        public string description { get; set; } = string.Empty;

        [Required]
        public string status { get; set; } = "Pending";

        public DateTime create_date { get; set; } = DateTime.Now;

        [ForeignKey("User")]
        public int users_id { get; set; }

        public UserEntities User { get; set; } = null!;

        public string? additional_data { get; set; }
    }

}
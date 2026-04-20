using System.ComponentModel.DataAnnotations;
using AppManagementTaskApi.Net.Models.Entities;

namespace AppManagementTaskApi.Net.Models.Entities
{
    public class UserEntities
    {
        [Key]
        public int id_user { get; set; }

        [Required]
        [MaxLength(100)]
        public string name_user { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string email { get; set; } = string.Empty;

        public DateTime create_date { get; set; } = DateTime.UtcNow;

        public ICollection<TaskEntities> tasks { get; set; } = new List<TaskEntities>();
    }
}
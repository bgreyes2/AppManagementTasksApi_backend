namespace AppManagementTaskApi.DTOs
{
    public class TaskUserDto
    {
        public int id_task { get; set; }
        public int id_user { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public string? status { get; set; }
        public string name_user { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public int users_Id { get; set; }
    }
}

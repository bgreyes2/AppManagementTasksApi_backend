namespace AppManagementTaskApi.Net.DTOs
{
    public class TaskDto
    {
        public int id_task { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public string? status { get; set; }
        public int users_Id { get; set; }
        public DateTime create_date { get; set; }
        public string? additional_data { get; set; } // JSON
    }

}

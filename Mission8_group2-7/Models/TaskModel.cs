using System.ComponentModel.DataAnnotations;

namespace Mission8_group2_7.Models
{
    public class TaskModel
    {
            [Required]
            public string task { get; set; }
            public DateOnly? duedate { get; set; }
            public string quadrant { get; set; }
            public int? category { get; set; }
            public bool? completed { get; set; }
        
    }
}

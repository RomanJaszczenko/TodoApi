using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class TodoItem
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Title { get; set; } = string.Empty;

        public bool IsComplete { get; set; }
    }
}

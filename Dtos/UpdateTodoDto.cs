using System.ComponentModel.DataAnnotations;

namespace TodoApi.Dtos
{
    public class UpdateTodoDto
    {
        [Required]
        [MinLength(3)]
        public string Title { get; set; } = string.Empty;

        public bool IsComplete { get; set; }
    }
}

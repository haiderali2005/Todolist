using System.ComponentModel.DataAnnotations;

namespace WebApplication24.Models
{
    public class Todolist
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public bool iscomplete {  get; set; }
    }
}

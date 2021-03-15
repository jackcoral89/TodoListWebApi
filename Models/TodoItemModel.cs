using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class TodoItem
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public string FieldTest { get; set; }
        public bool IsComplete { get; set; }
    }
}
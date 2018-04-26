using System.ComponentModel.DataAnnotations;

namespace Minor.GenericCRUD.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace WorkPermit.DAL.Models
{
    public class Employee
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Role { get; set; }

    }
}

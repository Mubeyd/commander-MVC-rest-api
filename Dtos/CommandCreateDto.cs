using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos
{
    public class CommandCreateDto
    {
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }

        [Required]
        [MaxLength(250)]
        public string Line { get; set; }

        [Required]
        [MaxLength(250)]
        public string Platform { get; set; }
    }
}
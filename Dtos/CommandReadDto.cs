using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos
{
    public class CommandReadDto
    {
        [Key]
        public int Id { get; set; }

        public string HowTo { get; set; }

        public string Line { get; set; }

    }
}
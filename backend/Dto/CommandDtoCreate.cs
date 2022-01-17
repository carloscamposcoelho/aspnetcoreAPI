using System.ComponentModel.DataAnnotations;

namespace AspnetcoreAPI.Dto
{
    public class CommandDtoCreate
    {
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string Platform { get; set; }
    }
}
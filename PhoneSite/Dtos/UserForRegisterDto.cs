using System.ComponentModel.DataAnnotations;

namespace PhoneSite.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string UserName {get; set;}
        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage="Довжина не повинна бути менше 4 та більше 8")]
        public string Password {get; set;}
        public string Gender {get; set;}
        public int Age {get; set;}
    }
}
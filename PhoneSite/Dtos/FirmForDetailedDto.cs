using System.Collections.Generic;

namespace PhoneSite.Dtos
{
    public class FirmForDetailedDto
    {
        public int Id {get; set;}
        public string NameFirm {get; set;}
        public string ImageFirm { get; set; }
        public ICollection<ModelForDetailedDto> ModelPhones {get; set;}
    }
}
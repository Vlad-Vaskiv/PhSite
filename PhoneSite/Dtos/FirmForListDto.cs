using System.Collections.Generic;

namespace PhoneSite.Dtos
{
    public class FirmForListDto
    {
        public int Id {get; set;}
        public string NameFirm {get; set;}
        public string ImageFirm { get; set; }
        public ICollection<ModelForListDto> ModelPhones {get; set;}
    }
}
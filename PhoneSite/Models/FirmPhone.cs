using System.Collections.Generic;

namespace PhoneSite.Models
{
    public class FirmPhone
    {
        public int Id {get; set;}
        public string NameFirm {get; set;}
        public string ImageFirm { get; set; }
        public ICollection<ModelPhone> ModelPhones {get; set;}
    }
}
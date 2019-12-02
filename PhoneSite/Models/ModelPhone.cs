using System.Collections.Generic;

namespace PhoneSite.Models
{
    public class ModelPhone
    {
        public int Id { get; set; }   
        public string Model { get; set; }
        public FirmPhone FirmPhone { get; set; }
        public int FirmPhoneId { get; set; }
        public string Display { get; set; }
        public string Camera { get; set; }
        public string Processor { get; set; }
        public string Storage { get; set; }
        public string Battery { get; set; }
        public string Others { get; set; }
        public string Price { get; set; }
        public ICollection<ImagePhone> ImagePhones { get; set; }

    }
}
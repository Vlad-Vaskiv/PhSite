namespace PhoneSite.Models
{
    public class ImagePhone
    {
        public int Id { get; set; }
        public string ImageModelAddress { get; set; }      
        public ModelPhone ModelPhone { get; set; }
        public int ModelPhoneId { get; set; }
        public bool isMain { get; set; }
    }
}
using System.Collections.Generic;
using Newtonsoft.Json;
using PhoneSite.Models;

namespace PhoneSite.Data
{
    public class Seed
    {
        private readonly DataContext _context;

        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedFirms()
        {
            var firmData = System.IO.File.ReadAllText("Data/firmSeedData.json");
            var firms = JsonConvert.DeserializeObject<List<FirmPhone>>(firmData);
            foreach(var firm in firms)
            {
                _context.FirmPhones.Add(firm);
            }
            _context.SaveChanges();
        }
    }
}
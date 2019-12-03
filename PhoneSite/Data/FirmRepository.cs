using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneSite.Models;

namespace PhoneSite.Data
{
    public class FirmRepository : IFirmRepository
    {
        public readonly DataContext _context;

        public FirmRepository(DataContext context)
        {
            _context = context;
        }
       public async Task<FirmPhone> GetFirm(int id)
       {
           var firm = await _context.FirmPhones.Include(p => p.ModelPhones).FirstOrDefaultAsync(u => u.Id == id);
           return firm;
       } 

       public async Task<IEnumerable<FirmPhone>> GetFirms()
       {
           var firms = await _context.FirmPhones.Include(p => p.ModelPhones).ToListAsync();
           return firms;
       }

       public async Task<FirmPhone> RegisterFirm(FirmPhone firmPhone)
       {
           await _context.AddAsync(firmPhone);
           await _context.SaveChangesAsync();
           return firmPhone;

       }

       public async Task<bool> SaveAll()
       {
           return await _context.SaveChangesAsync() > 0;
       }
    }
}
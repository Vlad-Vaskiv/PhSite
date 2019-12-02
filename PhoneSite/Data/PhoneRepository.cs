using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneSite.Models;

namespace PhoneSite.Data
{
    public class PhoneRepository: IPhoneRepository
    {
       public readonly DataContext _context;

       public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

    public void Delete<T>(T entity) where T : class
    {
        _context.Remove(entity);
    }
       public async Task<ModelPhone> GetPhone(int id)
       {
           var phone = await _context.ModelPhones.Include(p => p.ImagePhones).FirstOrDefaultAsync(u => u.Id == id);
           return phone;
       } 

       public async Task<IEnumerable<ModelPhone>> GetPhones()
       {
           var phones = await _context.ModelPhones.Include(p => p.ImagePhones).ToListAsync();
           return phones;
       }

       public async Task<ModelPhone> RegisterPhone(ModelPhone modelPhone)
       {
           await _context.AddAsync(modelPhone);
           await _context.SaveChangesAsync();
           return modelPhone;

       }

       public async Task<bool> SaveAll()
       {
           return await _context.SaveChangesAsync() > 0;
       }
    }
}
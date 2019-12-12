using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneSite.Helpers;
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

     public PhoneRepository(DataContext context)
        {
            _context = context;
        }
       public async Task<ModelPhone> GetPhone(int id)
       {
           var phone = await _context.ModelPhones.Include(p => p.ImagePhones).FirstOrDefaultAsync(u => u.Id == id);
           return phone;
       } 

       public async Task<PagedList<ModelPhone>> GetPhones(PhoneParams phoneParams)
       {
           var phones = _context.ModelPhones.Include(p => p.ImagePhones);
           return await PagedList<ModelPhone>.CreateAsync(phones, phoneParams.PageNumber, phoneParams.PageSize);
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
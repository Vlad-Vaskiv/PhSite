using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneSite.Helpers;
using PhoneSite.Models;

namespace PhoneSite.Data
{
    public interface IPhoneRepository
    {
          void Add<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         Task<bool> SaveAll();
         Task<PagedList<ModelPhone>> GetPhones(PhoneParams phoneParams);
         Task<ModelPhone> GetPhone(int id);
         Task<ModelPhone> RegisterPhone(ModelPhone modelPhone);
         
    }
}
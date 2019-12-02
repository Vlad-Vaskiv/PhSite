using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneSite.Models;

namespace PhoneSite.Data
{
    public interface IFirmRepository
    {
         Task<bool> SaveAll();
         Task<IEnumerable<FirmPhone>> GetFirms();
         Task<FirmPhone> GetFirm(int id);
         Task<FirmPhone> RegisterFirm(FirmPhone firmPhone);
    }
}
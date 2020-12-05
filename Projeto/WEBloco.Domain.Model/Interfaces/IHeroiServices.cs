using System.Collections.Generic;
using System.Threading.Tasks;
using WEBloco.Domain.Model.Entities;

namespace WEBloco.Domain.Model.Interfaces
{
    public interface IHeroiService
    {
        Task<IEnumerable<Heroi>> GetAllAsync();
        Task<Heroi> GetByIdAsync(int id);
        Task InsertAsync(Heroi heroi);
    }
}

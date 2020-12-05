using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBloco.Domain.Model.Entities;
using WEBloco.Domain.Model.Interfaces;
using WEBloco.Infrastructure.Data.Context;

namespace WEBloco.Infrastructure.Data.Repositories
{
    public class HeroiRepository : IHeroiRepository
    {
        private readonly HeroiContext _context;

        public HeroiRepository(HeroiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Heroi>> GetAllAsync()
        {
            //return await _context.Amigo.ToListAsync();
            return await _context.Heroi.Include(x => x.Imagens).ToListAsync();
        }

        public async Task<Heroi> GetByIdAsync(int id)
        {
            return await _context.Heroi.AsNoTracking()
                                       .Where(x => x.HeroiId == id)
                                       .Include(x => x.Imagens)
                                       .FirstOrDefaultAsync();
        }

        public async Task InsertAsync(Heroi heroi)
        {
            _context.Add(heroi);
            await _context.SaveChangesAsync();
        }

    }
}

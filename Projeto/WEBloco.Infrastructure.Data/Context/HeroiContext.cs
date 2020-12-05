using Microsoft.EntityFrameworkCore;
using WEBloco.Domain.Model.Entities;

namespace WEBloco.Infrastructure.Data.Context
{
    public class HeroiContext : DbContext
    {
        public HeroiContext(DbContextOptions<HeroiContext> options) : base(options)
        {
        }

        public DbSet<Heroi> Heroi { get; set; }

        public DbSet<Imagem> Imagem { get; set; }
    }
}

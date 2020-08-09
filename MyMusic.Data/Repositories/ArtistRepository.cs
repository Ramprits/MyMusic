using Microsoft.EntityFrameworkCore;
using MyMusic.Core.Models;
using MyMusic.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Data.Repositories
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        private readonly MyMusicDbContext _dbContext;

        public ArtistRepository(MyMusicDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Artist>> GetAllWithMusicsAsync()
        {
            return await _dbContext.Artists
                 .Include(a => a.Musics)
                 .ToListAsync();
        }

        public async Task<Artist> GetWithMusicsByIdAsync(int id)
        {
            return await _dbContext.Artists
               .Include(a => a.Musics)
               .SingleOrDefaultAsync(a => a.Id == id);
        }
    }
}

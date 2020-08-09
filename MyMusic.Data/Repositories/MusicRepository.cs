using Microsoft.EntityFrameworkCore;
using MyMusic.Core.Models;
using MyMusic.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Data.Repositories
{
    public class MusicRepository : Repository<Music>, IMusicRepository
    {
        private readonly MyMusicDbContext _dbContext;

        public MusicRepository(MyMusicDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Music>> GetAllWithArtistAsync()
        {
            return await _dbContext.Musics.Include(x => x.Artist).ToListAsync();
        }

        public async Task<IEnumerable<Music>> GetAllWithArtistByArtistIdAsync(int artistId)
        {
            return await _dbContext.Musics.Include(x => x.Artist).Where(m => m.Id == artistId).ToListAsync();
        }

        public async Task<Music> GetWithArtistByIdAsync(int id)
        {
            return await _dbContext.Musics
               .Include(m => m.Artist)
               .SingleOrDefaultAsync(m => m.Id == id); ;
        }


    }
}

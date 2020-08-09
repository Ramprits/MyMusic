using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMusic.Core.Models;
using MyMusic.Core.Services;
using MyMusic.Resources;

namespace MyMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicsController : ControllerBase
    {
        private readonly IMusicService _musicService;
        private readonly IMapper _mapper;

        public MusicsController(IMusicService musicService, IMapper mapper)
        {
            _musicService = musicService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Music>>> GetAllMusics()
        {
            var musics = await _musicService.GetAllWithArtist();
            var musicResource = _mapper.Map<IEnumerable<Music>, IEnumerable<MusicResource>>(musics);
            return Ok(musicResource);
        }
    }
}

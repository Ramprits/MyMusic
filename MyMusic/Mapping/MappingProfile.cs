using AutoMapper;
using MyMusic.Core.Models;
using MyMusic.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusic.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Music, MusicResource>();
            CreateMap<Artist, ArtistResource>();

            // Resource to Domain
            CreateMap<MusicResource, Music>();
            CreateMap<ArtistResource, Artist>();
        }
    }
}

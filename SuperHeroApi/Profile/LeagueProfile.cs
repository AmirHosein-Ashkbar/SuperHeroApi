using AutoMapper;
using SuperHeroApi.DTO.LeageDtos;

public class LeagueProfile : Profile
{
    public LeagueProfile()
    {
        CreateMap<LeagueCreateDto, League>();
        CreateMap<League, LeagueResponseDto>();
        CreateMap<SuperHero, LeagueSuperHeroResponseDto>();

    }
}

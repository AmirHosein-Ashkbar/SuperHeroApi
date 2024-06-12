using AutoMapper;
using Microsoft.OpenApi.Validations;
using SuperHeroApi.DTO.LeageDtos;
using SuperHeroApi.DTO.PersonDtos;
using SuperHeroApi.DTO.SuperHeroDtos;
using SuperHeroApi.DTO.SuperPowersDtos;
using SuperHeroApi.Models;
using SuperHeroApi.Services.LeagueService;


public class SuperHeroProfile : Profile
{
    public SuperHeroProfile()
    {
        CreateMap<SuperHeroCreateDto, SuperHero>()
            .ForMember(dest => dest.Name , opt => opt.MapFrom(src => src.Name.Trim()))
            .ForMember(dest => dest.Leagues, opt => opt.Ignore())
            .AfterMap<SuperheroAfterMapAction>();


        CreateMap<SuperHero, SuperHeroCreateDto>();
        CreateMap<SuperHero, SuperHeroResponseDto>();
        
        CreateMap<League, LeagueResponseDto>();
        CreateMap<League, SuperHeroLeagueResponseDto>();
        CreateMap<Person, PersonResponseDto>();
        CreateMap<SuperPower, SuperPowerResponseDto>();

        CreateMap<PersonCreateDto, Person>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName.Trim()))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName.Trim()))
            .ForMember(dest => dest.BirthPlace, opt => opt.MapFrom(src => src.BirthPlace.Trim()));
        CreateMap<SuperPowerCreateDto, SuperPower>();

    }
}
public class SuperheroAfterMapAction : IMappingAction<SuperHeroCreateDto, SuperHero>
{
    private readonly ILeagueService _leagueService;

    public SuperheroAfterMapAction(ILeagueService leagueService)
    {
        _leagueService = leagueService;
    }

    public async void Process(SuperHeroCreateDto source, SuperHero destination, ResolutionContext context)
    {
        var leagues = await _leagueService.GetLeaguesByIds(source.LeagueIds);
        destination.Leagues = leagues;
    }
}

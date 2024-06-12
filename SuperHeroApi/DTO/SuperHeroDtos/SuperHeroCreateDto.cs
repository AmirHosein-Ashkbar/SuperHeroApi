using SuperHeroApi.DTO.PersonDtos;
using SuperHeroApi.DTO.SuperPowersDtos;

namespace SuperHeroApi.DTO.SuperHeroDtos;

public record SuperHeroCreateDto
    (
    string Name,
    PersonCreateDto Person,
    List<SuperPowerCreateDto>? SuperPowers,
    List<int> LeagueIds
    );


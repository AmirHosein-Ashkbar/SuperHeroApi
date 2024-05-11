using SuperHeroApi.DTO.SuperPowersDtos;

namespace SuperHeroApi.DTO.SuperHeroDtos;

public record SuperHeroCreateDto(string Name, string FirstName, string LastName, string Place, List<SuperPowerCreateDto>? SuperPowers);


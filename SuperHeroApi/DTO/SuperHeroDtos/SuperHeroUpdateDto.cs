using SuperHeroApi.DTO.SuperPowersDtos;

namespace SuperHeroApi.DTO.SuperHeroDtos;

public record SuperHeroUpdateDto(int Id, string Name, string FirstName, string LastName, string Place, List<SuperPowerCreateDto>? SuperPowers);


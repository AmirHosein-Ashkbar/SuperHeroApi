using SuperHeroApi.DTO.PersonDtos;
using SuperHeroApi.DTO.SuperPowersDtos;

namespace SuperHeroApi.DTO.SuperHeroDtos;

public record SuperHeroUpdateDto(int Id, string Name, PersonCreateDto Person, List<SuperPowerCreateDto>? SuperPowers);


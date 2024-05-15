using SuperHeroApi.DTO.PersonDtos;
using SuperHeroApi.DTO.SuperPowersDtos;

namespace SuperHeroApi.DTO.SuperHeroDtos;

public record SuperHeroResponseDto(int id, string Name, PersonResponseDto Person, List<SuperPowerResponseDto>? SuperPowers);

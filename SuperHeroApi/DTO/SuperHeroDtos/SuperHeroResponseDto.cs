using SuperHeroApi.DTO.SuperPowersDtos;

namespace SuperHeroApi.DTO.SuperHeroDtos;

public record SuperHeroResponseDto(int id, string Name, string FullName, string Place, List<SuperPowerResponseDto>? SuperPowers);

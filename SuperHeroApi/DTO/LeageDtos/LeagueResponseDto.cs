using SuperHeroApi.DTO.SuperHeroDtos;

namespace SuperHeroApi.DTO.LeageDtos;

public record LeagueResponseDto(string Name, List<LeagueSuperHeroResponseDto> SuperHeroes);

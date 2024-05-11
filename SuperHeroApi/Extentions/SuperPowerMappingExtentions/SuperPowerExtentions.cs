using SuperHeroApi.DTO.SuperHeroDtos;
using SuperHeroApi.DTO.SuperPowersDtos;

namespace SuperHeroApi.Extentions.SuperPowerMappingExtentions;

public static class SuperPowerExtentions
{
    public static SuperPower MapSuperPowerCreateToSuperPower(this SuperPowerCreateDto powerCreate)
    {
        var superPower = new SuperPower() 
        {
            Name = powerCreate.Name,
            Description = powerCreate.Description,
        };
        return superPower;
    }
    public static SuperPowerResponseDto MapSuperPowerToSuperPowerResponse(this SuperPower power)
    {
        var powerResponse = new SuperPowerResponseDto(power.Name, power.Description);
        return powerResponse;
    }
}

using SuperHeroApi.DTO.PersonDtos;
using SuperHeroApi.DTO.SuperPowersDtos;

namespace SuperHeroApi.Extentions.PersonMappingExtentions;

public static class PersonExtentions
{
   
    public static Person MapPersonCreateToPerson(this PersonCreateDto personCreate)
    {
        var person = new Person()
        {
            FirstName = personCreate.FirstName.Trim(),
            LastName = personCreate.LastName.Trim(),
            BirthPlace = personCreate.BirthPlace.Trim(),
        };
        return person;
    }
    public static PersonResponseDto MapPersonToPersonResponse(this Person person)
    {
        var personResponse = new PersonResponseDto(person.FirstName, person.LastName, person.BirthPlace);
        return personResponse;
    }
}


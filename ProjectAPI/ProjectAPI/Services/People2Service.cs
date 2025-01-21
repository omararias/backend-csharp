using static ProjectAPI.Controllers.PeopleController;

namespace ProjectAPI.Services
{
    public class People2Service : IPeopleService
    {
        public bool Validate(People persona)
        {
            if (string.IsNullOrEmpty(persona.Name)||
                    persona.Name.Length>100|| persona.Name.Length < 3)

            {
                return false;
            }
            return true;
        }

    }
}

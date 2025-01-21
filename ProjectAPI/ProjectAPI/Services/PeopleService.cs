using static ProjectAPI.Controllers.PeopleController;

namespace ProjectAPI.Services
{
    public class PeopleService : IPeopleService
    {
        public bool Validate(People persona)
        {
            if (string.IsNullOrEmpty(persona.Name))
            {
                return false;
            }
            return true;
        }

    }
}

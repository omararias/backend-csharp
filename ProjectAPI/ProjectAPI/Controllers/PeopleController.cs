using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectAPI.Services;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleService _peopleService;
        public PeopleController([FromKeyedServices("people")]IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }


        [HttpGet("all")]
        public List<People> GetPeople() => Repository.People;

        //metodo concebido sin sugerencias, por razonamiento propio donde
        //devuelva las personas nacidas en el año que se pasa por parametro o en años posteriores
        [HttpGet("year/{year}")]
        public List<People> GetPeopleByYear(int year) => Repository.People.Where(p => p.Birthdate.Year > year).ToList();
        //hacemos uso de una funcion anonima para filtrar las personas que cumplan con la condicion de nacimiento en el año que se pasa por parametro

        //AGREGAMOS AL METODO DE BUSQUEDA POR ID UNA VALIDACION PARA QUE NOS RETORNE UNA RESPUESTA 404 SI NO EXISTE ESE ID
        [HttpGet("{id}")]
        public ActionResult<People> Get(int id)
        {
            var people = Repository.People.FirstOrDefault(p => p.Id == id);
            if (people == null)
            {
                return NotFound();
            }
            return people;

        }

        /*CREAMOS UN METODO QUE NOS PERMITA BUSCAR UNA PERSONA POR ALGUNA PIEZA DE SU NOMBRE
         * SIN IMPORTAR SI ESTA EN MAYUSCULAS O MINUSCULAS
         */
        [HttpGet("search/{search}")]
        public List<People> Search(string search) => Repository.People.Where(p => p.Name.ToUpper().Contains(search.ToUpper())).ToList();

        [HttpPost]
        public IActionResult Add(People persona)
        {
            if (! _peopleService.Validate(persona))
            {
                return BadRequest();
            }
            Repository.People.Add(persona);
            return NoContent();

        }



        public class Repository
        {
            public static List<People> People = new List<People>
        {
            new People()
            {
                Id = 1,
                Name = "Omar",
                Birthdate = new DateTime(2002, 10, 10)
            },
            new People()
            {
                Id = 2,
                Name = "Juan",
                Birthdate = new DateTime(1990, 10, 10)
            },
            new People()
            {
                Id = 3,
                Name = "Pedro",
                Birthdate = new DateTime(1965, 10, 10)
            },
            new People()
            {
                Id = 4,
                Name = "Maria",
                Birthdate = new DateTime(2010, 10, 10)
            }
        };
        }

        public class People
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public DateTime Birthdate { get; set; }
        }
    }
}
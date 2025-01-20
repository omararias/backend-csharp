using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [HttpGet("all")]
        public List<People> GetPeople()=>Repository.People;


        //AGREGAMOS AL METODO DE BUSQUEDA POR ID UNA VALIDACION PARA QUE NOS RETORNE UNA RESPUESTA 404 SI NO EXISTE ESE ID
        [HttpGet("{id}")]
        public ActionResult<People> Get(int id)
        {
            var people = Repository.People.FirstOrDefault(p => p.id == id);
            if (people == null)
            {
                return NotFound();
            }
            return people;

        }

        /*CREAMOS UN METODO QUE NOS PERMITA BUSCAR UNA PERSONA POR ALGUNA PIEZA DE SU NOMBRE
         * SIN IMPORTAR SI ESTA EN MAYUSCULAS O MINUSCULAS
         */
        [HttpGet ("search/{search}")]
        public List<People> Search(string search) => Repository.People.Where(p => p.name.ToUpper().Contains(search.ToUpper())).ToList();

    }



    public class Repository
    {
        public static List<People> People = new List<People>
        {
            new People()
            {
                id = 1,
                name = "Omar",
                Birthdate = new DateTime(1990, 10, 10)
            },
            new People()
            {
                id = 2,
                name = "Juan",
                Birthdate = new DateTime(1990, 10, 10)
            }
        };
    }

    public class People {   public int id { get; set; }
        public string name { get; set; }

        public DateTime Birthdate { get; set; }
    }
}

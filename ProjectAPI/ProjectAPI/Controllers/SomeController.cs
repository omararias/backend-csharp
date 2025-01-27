using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeController : ControllerBase
    {
        [HttpGet ("sync")]
        public IActionResult GetSync()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();


            Thread.Sleep(2000);
            Console.WriteLine("conexion a la BD realizada");

            Thread.Sleep(2000);
            Console.WriteLine("Envío de mail realizado");

            Console.WriteLine("Todo listo");

            stopwatch.Stop();

            return Ok(stopwatch.Elapsed);

        }
    }
}

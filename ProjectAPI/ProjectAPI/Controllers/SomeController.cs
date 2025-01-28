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


            Thread.Sleep(1000);
            Console.WriteLine("conexion a la BD realizada");

            Thread.Sleep(1000);
            Console.WriteLine("Envío de mail realizado");

            Console.WriteLine("Todo listo");

            stopwatch.Stop();

            return Ok(stopwatch.Elapsed);

        }

        [HttpGet("async")]
        public async Task<IActionResult> GetAsync()
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var task1 = new Task<int>(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("conexion a la BD realizada");

                return 1;


            });

            var task2 = new Task<int>(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Envio de mensaje whatsapp realizado");

                return 2;


            });

            task1.Start();
            task2.Start();
            Console.WriteLine("impresion asincrona");

            var resultado1=await task1;
            var resultado2 = await task2;

            Console.WriteLine("final de la ejecucion");

            stopwatch.Stop();

            return Ok(resultado1+" tiempo transcurrido"+stopwatch.Elapsed+"  --"+resultado2);
        }
    }
}

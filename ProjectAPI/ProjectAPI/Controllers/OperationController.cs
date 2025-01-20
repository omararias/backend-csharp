using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        [HttpGet]
        public decimal Add(decimal a, decimal b)
        {
            decimal resultado = a + b;
            return resultado;
        }

        [HttpPost]
        //en el metodo post enviamos numbers.A y number.B en el body de la solicitud
        //obtenemos del header el host y el postman-token, para imprimirlo en consola posteriormente
        public decimal Resta(Numbers numbers, [FromHeader] string Host, [FromHeader (Name ="Postman-Token") ] string postmantoken, [FromHeader(Name ="X-OmarCustom") ]string omi)
        {
            Console.WriteLine(Host);
            Console.WriteLine(postmantoken);
            Console.WriteLine(omi);
            return numbers.A - numbers.B;
        }
        [HttpPut]
        public decimal Edit(decimal a, decimal b)
        {
            decimal resultado = a * b;
            return resultado;
        }

        [HttpDelete]
        public decimal Delete(decimal a, decimal b)
        {
            decimal resultado = a / b;
            return resultado;
        }
    }


    public class Numbers
    {
        public decimal A { get; set; }
        public decimal B { get; set; }

    }


}

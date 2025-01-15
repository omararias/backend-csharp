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
        public decimal Resta(decimal a, decimal b)
        {
            decimal resultado = a - b;
            return resultado;
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
}

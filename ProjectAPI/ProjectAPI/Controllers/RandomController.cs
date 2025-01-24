using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectAPI.Services;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController : ControllerBase
    {
        private IRandomService _randomServiceSingleton;
        private IRandomService _randomServiceTransient;
        private IRandomService _randomServiceScoped;

        private IRandomService _randomService2Singleton;
        private IRandomService _randomService2Transient;
        private IRandomService _randomService2Scoped;

        public RandomController(
            [FromKeyedServices("randomSingleton")] IRandomService randomServiceSingleton,
            [FromKeyedServices("randomSingleton")] IRandomService randomService2Singleton,
            [FromKeyedServices("randomTransient")] IRandomService randomServiceTransient,
            [FromKeyedServices("randomTransient")] IRandomService randomService2Transient,
            [FromKeyedServices("randomScoped")] IRandomService randomServiceScoped,
            [FromKeyedServices("randomScoped")] IRandomService randomService2Scoped)

        {
            _randomServiceSingleton = randomServiceSingleton;
            _randomServiceTransient = randomServiceTransient;
            _randomServiceScoped = randomServiceScoped;
            _randomService2Singleton = randomService2Singleton;
            _randomService2Transient = randomService2Transient;
            _randomService2Scoped = randomService2Scoped;

        }


        [HttpGet]
        public ActionResult<Dictionary<string,int>>Get()
        {
            //prueba para testear en ejecucion como se manejan los distintos tipos de inyeccion
            var result = new Dictionary<string,int>();
            result.Add("Singleton1", _randomServiceSingleton.Value);
            result.Add("Singleton2", _randomService2Singleton.Value);
            result.Add("Transient1", _randomServiceTransient.Value);
            result.Add("Transient2", _randomService2Transient.Value);
            result.Add("Scoped1", _randomServiceScoped.Value);
            result.Add("Scoped2", _randomService2Scoped.Value);


            return result;


        }


    }
}

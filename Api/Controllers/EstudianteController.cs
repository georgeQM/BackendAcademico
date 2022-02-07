using Infrastructure.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/Estudiante")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        [HttpGet]
        [Route("GetEstudiantes")]
        public IActionResult GetEstudiantes()
        {
            var rep = new Repository().GetEstudiantes();
            return Ok(rep);
        }
    }
}

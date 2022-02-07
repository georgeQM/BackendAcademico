using Infrastructure.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/Materia")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        [HttpGet]
        [Route("GetMaterias")]
        public IActionResult GetMaterias()
        {
            var rep = new Repository().GetMaterias();
            return Ok(rep);
        }

    }
}

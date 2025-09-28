using LearnDapper.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo repo;
        public EmployeeController(IEmployeeRepo repo) {
            this.repo = repo;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var _list = await repo.GetAll();
            if(_list != null)
            {
                return Ok(_list);
            }
            else
            {
              return NotFound();
            }
        }
    }
}

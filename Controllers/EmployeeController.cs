﻿using LearnDapper.Model;
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
            var _list = await this.repo.GetAll();
            if(_list != null)
            {
                return Ok(_list);
            }
            else
            {
              return NotFound();
            }
        }

        [HttpGet("GetAllByRole/{role}")]
        public async Task<IActionResult> GetAllByRole(string role)
        {
            var _list = await this.repo.GetAllByRole(role);
            if (_list != null)
            {
                return Ok(_list);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("GetByCode/{code}")]
        public async Task<IActionResult> GetByCode(int code)
        {
            var _list = await this.repo.GetByCode(code);
            if (_list != null)
            {
                return Ok(_list);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Employee employee)
        {
            var _result = await this.repo.Create(employee);
            return Ok(_result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Employee employee, int code)
        {
            var _result = await this.repo.Update(employee, code);
            return Ok(_result);
        }
        
        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove(int code)
        {
            var _result = await this.repo.Remove(code);
            return Ok(_result);
        }
    }
}

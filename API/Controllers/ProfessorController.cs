using System.Linq;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        public readonly IRepository _repo;

        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllProfessores(true);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessorById(id);
            if (professor == null) return BadRequest("Professor não Encontrado");
            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            };
            return BadRequest("Erro ao Cadastrar o Professor");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var _professor = _repo.GetProfessorById(id);
            if (_professor == null) return BadRequest("Professor não Encontrado");
            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Erro ao Atualizar o Professor");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var _professor = _repo.GetProfessorById(id);
            if (_professor == null) return BadRequest("Professor não Encontrado");
            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Erro ao Atualizar o Professor");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _repo.GetProfessorById(id);
            if (professor == null) return BadRequest("Professor não Encontrado");
            _repo.Delete(professor);
            if (_repo.SaveChanges())
            {
                return Ok("Professor Deletado");
            }
            return BadRequest("Erro ao Deletar o Professor");
        }

    }
}
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public readonly IRepository _repo;

        public AlunoController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllAlunos(true);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null) return BadRequest("Aluno não Encontrado");
            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            };
            return BadRequest("Erro ao Cadastrar o Aluno");

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var _aluno = _repo.GetAlunoById(id);
            if (_aluno == null) return BadRequest("Aluno não Encontrado");
            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            };
            return BadRequest("Erro ao Atualizar o Aluno");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var _aluno = _repo.GetAlunoById(id);
            if (_aluno == null) return BadRequest("Aluno não Encontrado");
            _repo.Add(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            };
            return BadRequest("Erro ao Atualizar o Aluno");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null) return BadRequest("Aluno não Encontrado");
            _repo.Delete(aluno);
            if (_repo.SaveChanges())
            {
                return Ok("Aluno Deletado");
            };
            return BadRequest("Erro ao Deletar o Aluno");
        }

    }
}
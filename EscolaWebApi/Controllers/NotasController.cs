using EscolaWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EscolaWebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/v1/notas")]
    public class NotasController : ApiController
    {
        readonly static List<Nota> _notas = new List<Nota>();
        readonly static List<Disciplina> _disciplinas = new List<Disciplina>()
    {
        new Disciplina { Id = 1, Nome = "Matemática" },
        new Disciplina { Id = 2, Nome = "Português" },
        new Disciplina { Id = 3, Nome = "História" },
    };
        readonly static List<Aluno> _alunos = new List<Aluno>()
    {
        new Aluno { Id = 1, Nome = "João" },
        new Aluno { Id = 2, Nome = "Jorge" },
        new Aluno { Id = 3, Nome = "Lucas" },
    };

        /// <summary>
        /// Realiza o envio de notas
        /// </summary>
        /// <param name="nota">entidade nota</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult EnviarNotas(Nota nota)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            nota.Aprovado = nota.Pontos >= 7;

            _notas.Add(nota);

            return Ok();
        }

        [HttpGet]
        [Route("alunos")]
        public List<Aluno> GetAlunos()
        {
            return _alunos;
        }

        [HttpGet]
        [Route("disciplinas")]
        public List<Disciplina> GetDisciplinas()
        {
            return _disciplinas;
        }
    }
}

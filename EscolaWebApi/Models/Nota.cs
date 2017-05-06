using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EscolaWebApi.Models
{
    public class Nota
    {
        [Required]
        public int AlunoId { get; set; }

        [Required]
        public int DisciplinaId { get; set; }

        [Required]
        public decimal Pontos { get; set; }

        [JsonIgnore]
        public bool Aprovado { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyControl.Models
{
    public class Usuario
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Compare("Senha")]
        [DataType(DataType.Password)]
        public string Confirma { get; set; }
    }
}
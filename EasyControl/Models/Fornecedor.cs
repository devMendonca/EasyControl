using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyControl.Models
{
    public class Fornecedor
    {
        public int FornecedorId { get; set; }
        public string Nome { get; set; }
        public string Ocorrencias { get; set; }
        public IList<Produto> Produtos { get; set; }
    }
}
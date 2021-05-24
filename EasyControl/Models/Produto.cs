using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyControl.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public int Preco { get; set; }
        public int FornecedorId { get; set; }
        public int FilialId { get; set; }

        public virtual Fornecedor Fornecedor { get; set; }
        public virtual Filial Filial { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EasyControl.Data
{
    public class EasyControlContext : DbContext
    {
        public EasyControlContext() : base("EasyDB")
        {

        }

        public System.Data.Entity.DbSet<EasyControl.Models.Filial> Filials { get; set; }

        public System.Data.Entity.DbSet<EasyControl.Models.Fornecedor> Fornecedors { get; set; }

        public System.Data.Entity.DbSet<EasyControl.Models.Produto> Produtoes { get; set; }
    }
}
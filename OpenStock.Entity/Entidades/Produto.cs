using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenStock.Entity.Base;

namespace OpenStock.Entity.Entidades
{
    public class Produto : Cadastro
    {
        public decimal Peso { get; set; }
    }
}

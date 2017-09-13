using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenStock.Entity.Base
{
    /// <summary>
    /// Essa classe deverá ser herdada por outras classes que necessite registrar qualquer tipo de cadastro e edição.
    /// </summary>
    public class Cadastro
    {
        public string CadastradoPor { get; set; }
        public string EditadoPor { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataEdicao { get; set; }
    }
}

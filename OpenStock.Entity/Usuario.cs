using OpenStock.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenStock.Entity
{
    public class Usuario: Cadastro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Foto { get; set; }

        public Usuario()
        {

        }

        public Usuario(int id, string nome, string login, string senha, string foto)
        {
            Id = id;
            Nome = nome;
            Login = login;
            Senha = senha;
            Foto = foto;
        }

        public override string ToString()
        {
            return $"Nome: {Nome} Data de Cadastro: {DataCadastro}";
        }
    }
}

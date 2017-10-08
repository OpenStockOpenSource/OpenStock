using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using MySql.Data.Entity;
using System.Security.Claims;
using OpenStock.DataAccess.Context;


namespace OpenStock.DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Conexao>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySqlMigrationSqlGenerator());
            CodeGenerator = new MySqlMigrationCodeGenerator();
        }

        protected override void Seed(Conexao context)
        {
           // inicializar o BD
        }
    }
}

using System;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using MySql.Data.Entity;
using System.Web;
using OpenStock.DataAccess.EntityConfig;
using OpenStock.DataAccess.Migrations;
using OpenStock.Entity.Entidades;

namespace OpenStock.DataAccess.Context
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class Conexao : DbContext
    {
        public Conexao()
            : base("ConnDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Conexao, Configuration>());
        }

        static Conexao()
        {
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
        }

        public static Conexao Create()
        {
            return new Conexao();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // Atributo ID é chave
            modelBuilder.Properties()
                .Where(
                    properties =>
                        properties.ReflectedType != null && properties.Name ==/* properties.ReflectedType.Name + */"Id")
                .Configure(properties => properties.IsKey());
            modelBuilder.Properties<string>().Configure(properties => properties.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(properties => properties.HasMaxLength(200));

            modelBuilder.Configurations.Add(new ProdutoConfig());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            /*
            #region data de registro - insercao
            foreach (
                var entry in
                    ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DtRegistro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DtRegistro").CurrentValue = DateTime.Now;
                }
            }
            #endregion

            #region data de modificação - alteração
            foreach (
                var entry in
                    ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DtModificacao") != null))
            {
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DtModificacao").CurrentValue = DateTime.Now;
                }
            }
            #endregion

            #region status - inserção
            foreach (
                var entry in
                    ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Status") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("Status").CurrentValue = true;
                }
            }
            #endregion

            #region código do usuário - inserção e alteração
            foreach (
                var entry in
                    ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("UserIdInclusao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    if (HttpContext.Current?.User != null)
                    {
                        entry.Property("UserIdInclusao").CurrentValue = HttpContext.Current.User.Identity.GetUserId<int>();
                    }
                }
            }

            foreach (
                var entry in
                    ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("UserIdAlteracao") != null)
                )
            {
                if (entry.State == EntityState.Modified)
                {
                    if (HttpContext.Current?.User != null)
                    {
                        entry.Property("UserIdAlteracao").CurrentValue = HttpContext.Current.User.Identity.GetUserId<int>();
                    }
                }
            }

            #endregion
            */
            return base.SaveChanges();
        }
    }
}
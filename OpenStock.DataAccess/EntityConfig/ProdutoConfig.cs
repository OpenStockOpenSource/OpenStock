using System.Data.Entity.ModelConfiguration;
using OpenStock.Entity.Entidades;


namespace OpenStock.DataAccess.EntityConfig
{
    class ProdutoConfig : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfig()
        {
            //HasKey(c => c.InventorId);
        }
    }
}

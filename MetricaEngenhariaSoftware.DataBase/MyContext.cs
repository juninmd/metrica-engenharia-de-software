using System.Data.Entity;
using MetricaEngenhariaSoftware.Entity.Entidade.MES;

namespace MetricaEngenhariaSoftware.DataBase
{
    public class MyContext : DbContext
    {
        public MyContext() : base("ConectionDB")
        {

        }

        protected void OnModelCreating()
        {
        }

        public virtual DbSet<MES_FA> MES_FA { get; set; }
        public virtual DbSet<MES_ISO> MES_ISO { get; set; }
        public virtual DbSet<MES_LINGUAGEM_PROGRAMACAO> MES_LINGUAGEM_PROGRAMACAO { get; set; }
        public virtual DbSet<MES_TIPO_SISTEMA> MES_TIPO_SISTEMA { get; set; }
    }

}

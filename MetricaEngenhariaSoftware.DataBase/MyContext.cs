using System.Data.Common;
using System.Data.Entity;
using MetricaEngenhariaSoftware.Entity.Entidade;
using MetricaEngenhariaSoftware.Entity.Entidade.MES;

namespace MetricaEngenhariaSoftware.DataBase
{
    public class MyContext : DbContext
    {
        public MyContext() : base("name=AAA")
        {
            
        }

        protected void OnModelCreating()
        {
            
        }

        public virtual DbSet<MES_TIPO_SISTEMA> MES_TIPO_SISTEMA { get; set; }
    }

}

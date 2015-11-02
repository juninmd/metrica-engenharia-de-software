using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MetricaEngenhariaSoftware.Entity.Entidade.MES;

namespace MetricaEngenhariaSoftware.DataBase
{
    public class MyContext : DbContext
    {
        public MyContext() : base("ConectionDB")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

        /*    modelBuilder.Properties()
                .Where(p => p.Name == "IntId" + p.ReflectedType.Name)
                .Configure(p =>p.IsKey());*/
 

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(50));

        }

        public virtual DbSet<MES_FA> MES_FA { get; set; }
        public virtual DbSet<MES_ISO> MES_ISO { get; set; }
        public virtual DbSet<MES_LINGUAGEM_PROGRAMACAO> MES_LINGUAGEM_PROGRAMACAO { get; set; }
        public virtual DbSet<MES_TIPO_SISTEMA> MES_TIPO_SISTEMA { get; set; }
    }

}

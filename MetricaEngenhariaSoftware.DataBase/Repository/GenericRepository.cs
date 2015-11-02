namespace MetricaEngenhariaSoftware.DataBase.Repository
{
    public class GenericRepository<T>  : BaseRepository<T> where T : class
    {
        static readonly MyContext MyContext = new MyContext();

        public GenericRepository() : base(MyContext)
        {
        }
    }
}

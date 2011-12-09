namespace Fifa.Repositories
{
    public class Repository
    {
        public static IRepository Instance { get; set; }

        static Repository()
        {
            Instance = new EfRepository();
        }
    }
}
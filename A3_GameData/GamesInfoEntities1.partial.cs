using System.Data.Entity;

namespace A3_GameData 
{
    public partial class GamesInfoEntities1 : DbContext
    {
        public GamesInfoEntities1(string connectionString) : base(connectionString)
        {
        }
    }
}

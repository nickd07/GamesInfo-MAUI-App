namespace A3_nickdamor  
{
    public static class EFConnection
    {
        public static string ConnectionString =
            "metadata=res://*/GamesInfo.csdl|res://*/GamesInfo.ssdl|res://*/GamesInfo.msl;" +
            "provider=System.Data.SqlClient;" +
            "provider connection string=\"data source=.\\SQLEXPRESS;initial catalog=GamesInfo;" +
            "integrated security=True;encrypt=False;MultipleActiveResultSets=True;App=EntityFramework\"";
    }
}

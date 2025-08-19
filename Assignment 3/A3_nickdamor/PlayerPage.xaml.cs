using A3_GameData;

namespace A3_nickdamor;

public partial class PlayerPage : ContentPage
{
    public PlayerPage()
    {
        InitializeComponent();
        LoadPlayers();
    }

    void LoadPlayers()
    {
        string EFConnection = "metadata=res://*/GamesInfo.csdl|res://*/GamesInfo.ssdl|res://*/GamesInfo.msl;" +
                              "provider=System.Data.SqlClient;" +
                              "provider connection string='data source=.\\SQLEXPRESS;initial catalog=GamesInfo;integrated security=True;encrypt=False;MultipleActiveResultSets=True;App=EntityFramework'";

        using (var db = new GamesInfoEntities1(EFConnection))
        {
            var players = db.Players.ToList();
            playersList.ItemsSource = players;
        }
    }
}

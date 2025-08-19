using A3_GameData;

namespace A3_nickdamor;

public partial class GamesPlayersPage : ContentPage
{
    public GamesPlayersPage()
    {
        InitializeComponent();
        LoadGamePlayers();
    }

    void LoadGamePlayers()
    {
        string conn = "metadata=res://*/GamesInfo.csdl|res://*/GamesInfo.ssdl|res://*/GamesInfo.msl;" +
                      "provider=System.Data.SqlClient;" +
                      "provider connection string='data source=.\\SQLEXPRESS;initial catalog=GamesInfo;integrated security=True;encrypt=False;MultipleActiveResultSets=True;App=EntityFramework'";

        using (var db = new GamesInfoEntities1(conn))
        {
            var players = db.Players.ToList();

            foreach (var p in players)
            {
                // Show player nickname
                var playerLabel = new Label
                {
                    Text = p.Nickname,
                    FontSize = 30,
                    TextColor = Colors.Black
                };

                playersStack.Children.Add(playerLabel);

                // Get GameIds from GamePlayers where PlayerId matches
                var gameIds = db.GamePlayers
                                .Where(gp => gp.PlayerId == p.Id)
                                .Select(gp => gp.GameId)
                                .ToList();

                // Load game details using those GameIds
                foreach (var gameId in gameIds)
                {
                    var g = db.Games.FirstOrDefault(x => x.Id == gameId);

                    if (g != null)
                    {
                        var gameRow = new HorizontalStackLayout { Spacing = 10 };

                        var gameLogo = new Image
                        {
                            Source = g.Icon,
                            WidthRequest = 80,
                            HeightRequest = 60
                        };

                        var gameName = new Label
                        {
                            Text = g.Name,
                            TextColor = Colors.LightBlue,
                            FontSize = 25
                        };

                        gameRow.Children.Add(gameLogo);
                        gameRow.Children.Add(gameName);

                        playersStack.Children.Add(gameRow);
                    }
                }
            }
        }
    }
}

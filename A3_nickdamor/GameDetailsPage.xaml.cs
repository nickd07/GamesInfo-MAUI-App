using A3_GameData;

namespace A3_nickdamor;

public partial class GameDetailsPage : ContentPage
{
    Game selectedGame;
    string conn;

    public GameDetailsPage(Game game)
    {
        InitializeComponent(); 

        selectedGame = game;

        conn = "metadata=res://*/GamesInfo.csdl|res://*/GamesInfo.ssdl|res://*/GamesInfo.msl;" +
               "provider=System.Data.SqlClient;" +
               "provider connection string='data source=.\\SQLEXPRESS;initial catalog=GamesInfo;integrated security=True;encrypt=False;MultipleActiveResultSets=True;App=EntityFramework'";

       
        entryName.Text = game.Name;
        entryDeveloper.Text = game.Developer;
        entryIcon.Text = game.Icon;
        entryBlurb.Text = game.GameBlurb;
    }

    private void OnUpdateClicked(object sender, EventArgs e)
    {
        using (var db = new GamesInfoEntities1(conn))
        {
            var g = db.Games.Find(selectedGame.Id);
            if (g != null)
            {
                g.Name = entryName.Text;
                g.Developer = entryDeveloper.Text;
                g.Icon = entryIcon.Text;
                g.GameBlurb = entryBlurb.Text;
                db.SaveChanges();
            }
        }

        DisplayAlert("Success", "Game updated!", "OK");
        Navigation.PopAsync(); // Go back
    }

    private void OnDeleteClicked(object sender, EventArgs e)
    {
        using (var db = new GamesInfoEntities1(conn))
        {
            var g = db.Games.Find(selectedGame.Id);
            if (g != null)
            {
                db.Games.Remove(g);
                db.SaveChanges();
            }
        }

        DisplayAlert("Deleted", "Game removed", "OK");
        Navigation.PopAsync();
    }
}

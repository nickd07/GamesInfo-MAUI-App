using A3_GameData;

namespace A3_nickdamor;

public partial class AddGamePage : ContentPage

{
    public AddGamePage()
    {
        InitializeComponent();
    }

    private void OnSaveClicked(object sender, EventArgs e)
    {
        string conn = "metadata=res://*/GamesInfo.csdl|res://*/GamesInfo.ssdl|res://*/GamesInfo.msl;" +
                      "provider=System.Data.SqlClient;" +
                      "provider connection string='data source=.\\SQLEXPRESS;initial catalog=GamesInfo;integrated security=True;encrypt=False;MultipleActiveResultSets=True;App=EntityFramework'";

        using (var db = new GamesInfoEntities1(conn))
        {
            var game = new Game
            {
                Name = entryName.Text,
                Developer = entryDeveloper.Text,
                GameBlurb = entryBlurb.Text,
                Icon = entryIcon.Text
            };

            db.Games.Add(game);
            db.SaveChanges();
        }

        DisplayAlert("Success", "Game added!", "OK");
        Navigation.PopAsync(); // return back
    }
}

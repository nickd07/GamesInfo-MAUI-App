using A3_GameData;

namespace A3_nickdamor;

public partial class AddPlayerPage : ContentPage
{
    public AddPlayerPage()
    {
        InitializeComponent();
    }

    private void OnAddPlayerClicked(object sender, EventArgs e)
    {
        var newPlayer = new Player
        {
            Nickname = entryNickname.Text,
            Name = entryName.Text,
            Surname = entrySurname.Text
        };


        string conn = "metadata=res://*/GamesInfo.csdl|res://*/GamesInfo.ssdl|res://*/GamesInfo.msl;" +
                      "provider=System.Data.SqlClient;" +
                      "provider connection string='data source=.\\SQLEXPRESS;initial catalog=GamesInfo;integrated security=True;encrypt=False;MultipleActiveResultSets=True;App=EntityFramework'";

        using (var db = new GamesInfoEntities1(conn))
        {
            db.Players.Add(newPlayer);
            db.SaveChanges();
        }

        DisplayAlert("Success", "Player Added!", "OK");
        Navigation.PopAsync();
    }
}
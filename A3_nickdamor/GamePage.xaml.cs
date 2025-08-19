using Microsoft.Maui.Controls;
using System;
using System.Linq;
using A3_GameData; 

namespace A3_nickdamor
{
    public partial class GamePage : ContentPage
    {
        public GamePage()
        {
            InitializeComponent();
            LoadGames();
        }

        void LoadGames()
        {
            try
            {
                var db = new GamesInfoEntities1(EFConnection.ConnectionString);

                var gameList = db.Games.ToList();
                gamesList.ItemsSource = gameList;
                gamesList.SelectionChanged += async (s, e) =>
                {
                    var selected = e.CurrentSelection.FirstOrDefault() as Game;
                    if (selected != null)
                    {
                        await Navigation.PushAsync(new GameDetailsPage(selected)); // Await here
                    }

                    gamesList.SelectedItem = null;
                };



            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}

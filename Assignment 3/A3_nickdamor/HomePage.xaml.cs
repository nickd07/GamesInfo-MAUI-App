namespace A3_nickdamor;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }
        private async void OnAddGameClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddGamePage());
    }

}
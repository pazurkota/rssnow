using rssnow;

namespace rssnow.Views;

public partial class RssChannelsPage : ContentPage
{
    RssLinkRepository _repository;
    
    public RssChannelsPage()
    {
        InitializeComponent();
    }

    async void AddRssLinkClicked(object sender, EventArgs e)
    {
        string link = await DisplayPromptAsync("Add RSS Link", "Put RSS Channel link below:");

        if (link == null)
            return;
        
        App.Repository.AddNewLink(link);
        await DisplayAlert("Status", $"{App.Repository.StatusMessage}", "OK");
    }
}


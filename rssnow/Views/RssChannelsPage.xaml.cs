using rssnow.Model;

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

    async void ShowAllChannelsClicked(object sender, EventArgs e)
    {
        List<RssLink> links = await App.Repository.GetAllLinks();
        Channels.ItemsSource = links;
    }
}


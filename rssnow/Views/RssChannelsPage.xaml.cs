using rssnow.Model;
using rssnow.ViewModel;

namespace rssnow.Views;

public partial class RssChannelsPage : ContentPage
{
    public RssChannelsPage()
    {
        InitializeComponent();
        BindingContext = new RssChannelsViewModel();
    }

    async void AddRssLinkClicked(object sender, EventArgs e)
    {
        string link = await DisplayPromptAsync("Add RSS Link", "Put RSS Channel link below:");

        if (link == null)
            return;
        
        App.Repository.AddNewLink(link);
        await DisplayAlert("Status", $"{App.Repository.StatusMessage}", "OK");
    }

    void ShowAllChannelsClicked(object sender, EventArgs e)
    {
        var viewModel = (RssChannelsViewModel)BindingContext;
        
        viewModel.GetAllChannels();
    }

    async void UpdateChannelClicked(object sender, EventArgs e)
    {
        int id = Int32.Parse(await DisplayPromptAsync("Edit RSS Channel", "Insert ID of the channel"));
        string newLink = await DisplayPromptAsync("Edit RSS Channel", "Insert a new link:");

        List<RssLink> links = await App.Repository.GetAllLinks();
        string link = links.Find(x => x.Id == id).Link;

        App.Repository.EditLink(link, newLink);
    }

    async void DeleteChannelClicked(object sender, EventArgs e)
    {
        int id = int.Parse(await DisplayPromptAsync("Delete RSS Channel", "Insert ID of the channel"));
        
        App.Repository.DeleteLink(id);
    }
}


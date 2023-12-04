using rssnow.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace rssnow.ViewModel;

public partial class RssChannelsViewModel : ObservableObject
{
    [ObservableProperty] List<RssLink> links;

    public async void GetAllChannels()
    {
        Links = await App.Repository.GetAllLinks();
    }

    [RelayCommand]
    void ShowAllChannels()
    {
        GetAllChannels();
    }

    [RelayCommand]
    async Task AddChannel()
    {
        string link = await Shell.Current.DisplayPromptAsync("Add RSS Link", "Put RSS Channel link below:");

        if (link == null)
            return;
        
        App.Repository.AddNewLink(link);
    }
    
    [RelayCommand]
    async Task UpdateChannel()
    {
        int id = Int32.Parse(await Shell.Current.DisplayPromptAsync("Edit RSS Channel", "Insert ID of the channel"));
        string newLink = await Shell.Current.DisplayPromptAsync("Edit RSS Channel", "Insert a new link:");

        List<RssLink> links = await App.Repository.GetAllLinks();
        string link = links.Find(x => x.Id == id).Link;

        App.Repository.EditLink(link, newLink);
    }

    [RelayCommand]
    async Task DeleteChannel()
    {
        int id = int.Parse(await Shell.Current.DisplayPromptAsync("Delete RSS Channel", "Insert ID of the channel"));
        
        App.Repository.DeleteLink(id);
    }
}

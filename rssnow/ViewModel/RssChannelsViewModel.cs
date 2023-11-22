using rssnow.Model;
using CommunityToolkit.Mvvm.ComponentModel;

namespace rssnow.ViewModel;

public partial class RssChannelsViewModel : ObservableObject
{
    [ObservableProperty] List<RssLink> links;

    public async void GetAllChannels()
    {
        Links = await App.Repository.GetAllLinks();
    }
}

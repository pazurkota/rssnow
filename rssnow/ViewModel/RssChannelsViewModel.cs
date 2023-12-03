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
}

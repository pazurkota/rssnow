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

    async void NewsContentButton(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("contentpage");
    }
}


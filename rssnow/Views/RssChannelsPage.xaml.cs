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
}


namespace CaliburnUniversalTemplate.ViewModels
{
    using Features.Navigation;

    public class MainPageViewModel: ViewModelBase
    {
        protected MainPageViewModel(IPageNavigationService pageNavigationService) : base(pageNavigationService)
        {
        }
    }
}
namespace CaliburnUniversalTemplate.ViewModels
{
    using Caliburn.Micro;

    using Features.Navigation;


    public class ViewModelBase: Screen
    {
        protected readonly IPageNavigationService PageNavigationService;

        protected ViewModelBase(IPageNavigationService pageNavigationService)
        {
            PageNavigationService = pageNavigationService;
        }

        protected void NavigateTo<T>()
        {
            PageNavigationService.NavigateTo<T>();
        }
    }
}
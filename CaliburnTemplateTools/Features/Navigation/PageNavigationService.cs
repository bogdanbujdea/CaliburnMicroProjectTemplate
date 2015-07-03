using CaliburnTemplateTools.Features.Navigation;

namespace CaliburnUniversalTemplate.Features.Navigation
{
    using System;
    using System.Collections.Generic;

    using Caliburn.Micro;

    public class PageNavigationService : IPageNavigationService
    {
        private readonly INavigationService _navigationService;

        public PageNavigationService(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigationData = new Dictionary<NavigationKey, object>();
        }

        /// <summary>
        /// This dictionary will be used for sending data when navigation from one page to another
        /// </summary>
        public Dictionary<NavigationKey, object> NavigationData { get; set; }

        /// <summary>
        /// Sets the navigation data. If you need to communicate with a view model without navigating to it, use IEventAggregator
        /// </summary>
        /// <param name="key">The key which identifies the data</param>
        /// <param name="data">The data to be sent</param>
        public void SetNavigationData(NavigationKey key, object data)
        {
            NavigationData[key] = data;
        }

        /// <summary>
        /// Retrieves the data that was sent to the view model casted to the required type. If nothing was sent or the type requested is wrong, a default value will be provided
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetParameter<T>(NavigationKey key)
        {
            try
            {                
                return (T)NavigationData[key];
            }
            catch ( Exception )
            {
                return default(T);
            }
        }

        public void NavigateTo<T>()
        {
            _navigationService.NavigateToViewModel<T>();
        }

        public bool CanGoBack
        {
            get { return _navigationService.CanGoBack; }
        }

        public void GoBack()
        {
            if ( CanGoBack )
                _navigationService.GoBack();
        }

        public void ClearBackStack()
        {
            _navigationService.BackStack.Clear();
        }

        public void RemoveParameter(NavigationKey navigationKey)
        {
            try
            {
                NavigationData.Remove(navigationKey);
            }
            catch ( Exception )
            {
            }
        }
    }
}
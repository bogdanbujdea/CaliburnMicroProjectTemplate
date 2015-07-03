using System.Collections.Generic;
using System.Threading.Tasks;
using CaliburnTemplateTools.Features.Dialogs;

namespace CaliburnUniversalTemplate.ViewModels
{
    using CaliburnTemplateTools.Features.Navigation;

    public class MainPageViewModel: ViewModelBase
    {
        private readonly IUserNotificationService _userNotificationService;
        private string _userChoice;

        public MainPageViewModel(IPageNavigationService pageNavigationService, IUserNotificationService userNotificationService) : base(pageNavigationService)
        {
            _userNotificationService = userNotificationService;
        }

        public async Task ShowMessageDialog()
        {
            await _userNotificationService.ShowMessageDialogAsync("This is a message dialog sample!");
        }

        public async Task ShowQuestion()
        {
            var userSaidYes =
                await _userNotificationService.AskQuestion("Do you like Caliburn.Micro?", "Caliburn.Micro");
            if (userSaidYes)
                UserChoice = "You like Caliburn.Micro";
            else UserChoice = "You don't like Caliburn.Micro";
        }

        public async Task ShowQuestionWithOptions()
        {
            var answer = await _userNotificationService.ShowOptions("1 + 1 equals...", new List<Option>
            {
                new Option("1", 1),
                new Option("2", 2),
                new Option("3", 3)
            });
            int result = (int) answer;
            if(result == 2)
                UserChoice = "Correct";
            else
                UserChoice = "No, try again. 1 + 1 does not equal " + result;
        }

        public string UserChoice
        {
            get { return _userChoice; }
            set
            {
                if ( value == _userChoice )
                    return;
                _userChoice = value;
                NotifyOfPropertyChange(() => UserChoice);
            }
        }
    }
}
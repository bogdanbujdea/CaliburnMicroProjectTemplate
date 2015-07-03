using System.Collections.Generic;

namespace CaliburnTemplateTools.Features.Dialogs
{
    using System.Threading.Tasks;

    public interface IUserNotificationService
    {
        Task ShowMessageDialogAsync(string message, string title = null);
        Task ShowErrorMessageDialogAsync(string errorMessage, string title = null);
        Task<bool> AskQuestion(string question, string title = null);
        Task<bool> ShowOptions(string question, string firstOption, string secondOption, string title = null);
        Task<object>  ShowOptions(string question, List<Option> options, string title = null);
    }
}
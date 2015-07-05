namespace CaliburnUniversalTemplate.Tools.Dialogs
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Windows.UI.Popups;

    public class UserNotificationService : IUserNotificationService
    {
        /// <summary>
        /// Shows the standard MessageDialog
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public async Task ShowMessageDialogAsync(string message, string title = null)
        {
            MessageDialog messageDialog = title == null ? new MessageDialog(message) : new MessageDialog(message, title);
            await messageDialog.ShowAsync();
        }

        /// <summary>
        /// The same as ShowMessageDialogAsync. In the future there may be a difference so choose the right one
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public async Task ShowErrorMessageDialogAsync(string errorMessage, string title = null)
        {
            try
            {
                MessageDialog messageDialog = title == null ? new MessageDialog(errorMessage) : new MessageDialog(errorMessage, title);
                await messageDialog.ShowAsync();
            }
            catch ( Exception )
            {
            }
        }

        /// <summary>
        /// Asks the user a yes/no question
        /// </summary>
        /// <param name="question"></param>
        /// <param name="title"></param>
        /// <returns>Returns true for yes and false for no</returns>
        public async Task<bool> AskQuestion(string question, string title = null)
        {
            MessageDialog messageDialog;
            messageDialog = string.IsNullOrEmpty(title) ? new MessageDialog(question) : new MessageDialog(question, title);
            var result = false;
            messageDialog.Commands.Add(new UICommand { Id = "yes", Label = "Yes", Invoked = delegate { result = true; } });
            messageDialog.Commands.Add(new UICommand { Id = "no", Label = "No", Invoked = delegate { result = false; } });
            await messageDialog.ShowAsync();
            return result;
        }

        /// <summary>
        /// Asks the user to choose between two options
        /// </summary>
        /// <param name="question"></param>
        /// <param name="firstOption"></param>
        /// <param name="secondOption"></param>
        /// <param name="title"></param>
        /// <returns>Returns true for first option or false for the second one</returns>
        public async Task<bool> ShowOptions(string question, string firstOption, string secondOption, string title = null)
        {
            MessageDialog messageDialog;
            messageDialog = string.IsNullOrEmpty(title) ? new MessageDialog(question) : new MessageDialog(question, title);
            var result = false;
            messageDialog.Commands.Add(new UICommand { Id = firstOption, Label = firstOption, Invoked = delegate { result = true; } });
            messageDialog.Commands.Add(new UICommand { Id = secondOption, Label = secondOption, Invoked = delegate { result = false; } });
            await messageDialog.ShowAsync();
            return result;
        }

        /// <summary>
        /// Shows a list of options to the user
        /// </summary>
        /// <param name="question"></param>
        /// <param name="options">List of options. You can't add more than 3 options</param>
        /// <param name="title"></param>
        /// <returns>Returns the result of the selected option</returns>
        public async Task<object> ShowOptions(string question, List<Option> options, string title = null)
        {
            if(string.IsNullOrWhiteSpace(question))
                throw new ArgumentException("The question can't be empty");
            if ( options == null )
                throw new ArgumentException("The list of options can't be null");
            if ( options.Count > 3 )
                throw new ArgumentException("You can't send more than 3 options");
            var messageDialog = string.IsNullOrEmpty(title) ? new MessageDialog(question) : new MessageDialog(question, title);
            object result = null;
            foreach ( var option in options )
            {
                if ( option.Id == null || string.IsNullOrWhiteSpace(option.Text) )
                    throw new ArgumentException("Id and Text properties are mandatory for an option");
                messageDialog.Commands.Add(new UICommand { Id = option.Id, Label = option.Text, Invoked = delegate { result = option.Result; } });
            }
            await messageDialog.ShowAsync();
            return result;
        }
    }
}
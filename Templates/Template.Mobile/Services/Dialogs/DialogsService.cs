using System;
using System.Threading;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Shiny;
using Xamarin.Forms;

namespace Template.Mobile.Services.Dialogs
{
    public class DialogsService : IDialogService
    {
        public static IDialogService Current { get; } = ShinyHost.Resolve<IDialogService>();

        public IDisposable Alert(string message, string title = null, string okText = null) =>
            UserDialogs.Instance.Alert(message, title, okText);

        public IDisposable Alert(AlertConfig config) => UserDialogs.Instance.Alert(config);

        public Task AlertAsync(string message, string title = null, string okText = null, CancellationToken? cancelToken = null) =>
            UserDialogs.Instance.AlertAsync(message, title, okText, cancelToken);

        public Task AlertAsync(AlertConfig config, CancellationToken? cancelToken = null) =>
            UserDialogs.Instance.AlertAsync(config, cancelToken);

        public IDisposable ActionSheet(ActionSheetConfig config) => 
            UserDialogs.Instance.ActionSheet(config);

        public Task<string> ActionSheetAsync(string title, string cancel, string destructive, CancellationToken? cancelToken = null, params string[] buttons) =>
            UserDialogs.Instance.ActionSheetAsync(title, cancel, destructive, cancelToken, buttons);

        public IDisposable Confirm(ConfirmConfig config) => 
            UserDialogs.Instance.Confirm(config);

        public Task<bool> ConfirmAsync(string message, string title = null, string okText = null, string cancelText = null, CancellationToken? cancelToken = null) =>
            UserDialogs.Instance.ConfirmAsync(message, title, okText, cancelText, cancelToken);

        public Task<bool> ConfirmAsync(ConfirmConfig config, CancellationToken? cancelToken = null) => 
            UserDialogs.Instance.ConfirmAsync(config, cancelToken);

        public IDisposable DatePrompt(DatePromptConfig config) => UserDialogs.Instance.DatePrompt(config);

        public Task<DatePromptResult> DatePromptAsync(DatePromptConfig config, CancellationToken? cancelToken = null) => 
            UserDialogs.Instance.DatePromptAsync(config, cancelToken);

        public Task<DatePromptResult> DatePromptAsync(string title = null, DateTime? selectedDate = null, CancellationToken? cancelToken = null) => 
            UserDialogs.Instance.DatePromptAsync(title, selectedDate, cancelToken);

        public IDisposable TimePrompt(TimePromptConfig config) => 
            UserDialogs.Instance.TimePrompt(config);

        public Task<TimePromptResult> TimePromptAsync(TimePromptConfig config, CancellationToken? cancelToken = null) =>
            UserDialogs.Instance.TimePromptAsync(config, cancelToken);

        public Task<TimePromptResult> TimePromptAsync(string title = null, TimeSpan? selectedTime = null, CancellationToken? cancelToken = null) =>
            UserDialogs.Instance.TimePromptAsync(title, selectedTime, cancelToken);

        public IDisposable Prompt(PromptConfig config) => UserDialogs.Instance.Prompt(config);

        public Task<PromptResult> PromptAsync(string message, string title = null, string okText = null, string cancelText = null,
            string placeholder = "", InputType inputType = InputType.Default, CancellationToken? cancelToken = null) =>
            UserDialogs.Instance.PromptAsync(message, title, okText, cancelText, placeholder, inputType, cancelToken);

        public Task<PromptResult> PromptAsync(PromptConfig config, CancellationToken? cancelToken = null) =>
            UserDialogs.Instance.PromptAsync(config, cancelToken);

        public IDisposable Login(LoginConfig config) => 
            UserDialogs.Instance.Login(config);

        public Task<LoginResult> LoginAsync(string title = null, string message = null, CancellationToken? cancelToken = null) => 
            UserDialogs.Instance.LoginAsync(title, message, cancelToken);

        public Task<LoginResult> LoginAsync(LoginConfig config, CancellationToken? cancelToken = null) =>
            UserDialogs.Instance.LoginAsync(config, cancelToken);

        public IProgressDialog Progress(ProgressDialogConfig config) => 
            UserDialogs.Instance.Progress(config);

        public IProgressDialog Loading(string title = null, Action onCancel = null, string cancelText = null, bool show = true, MaskType? maskType = null) => 
            UserDialogs.Instance.Loading(title, onCancel, cancelText, show, MaskType.Black);

        public IProgressDialog Progress(string title = null, Action onCancel = null, string cancelText = null, bool show = true, MaskType? maskType = null) =>
            UserDialogs.Instance.Progress(title, onCancel, cancelText, show, MaskType.Black);

        public IDisposable Toast(string title, TimeSpan? dismissTimer = null) =>
            UserDialogs.Instance.Toast(title, dismissTimer);

        public IDisposable Toast(ToastConfig cfg) =>
            UserDialogs.Instance.Toast(cfg);

        private Task _loadingTask;
        private int _loadingCounter;
        private int LoadingCounter
        {
            get => _loadingCounter;
            set
            {
                if (_loadingCounter != value)
                {
                    _loadingCounter = Math.Max(value, 0);
                    if (_loadingCounter > 0 && _loading == null)
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            _loading = UserDialogs.Instance.Loading(_loadingTitle, maskType: MaskType.Black);
                            _loadingTask = Task.Delay(500);
                        });
                    }
                    else if (_loadingCounter == 0)
                    {
                        Task.Run(async () =>
                        {
                            if(_loadingTask != null && !_loadingTask.IsCompleted && !_loadingTask.IsCompletedSuccessfully)
                                await _loadingTask;

                            Device.BeginInvokeOnMainThread(() =>
                            {
                                _loading?.Dispose();
                                _loading = null;
                            });
                        });
                    }
                }
            }
        }

        private string _loadingTitle;
        private IProgressDialog _loading;
        public void ShowLoading(string title = null, MaskType? maskType = null)
        {
            _loadingTitle = title;

            LoadingCounter++;
        }

        public void HideLoading()
        {
            LoadingCounter--;
        }
    }
}

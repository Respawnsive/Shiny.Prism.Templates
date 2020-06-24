using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using Prism.Navigation;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Shiny;
using Shiny.Push;
using Template.Mobile.Services;
using Template.Mobile.ViewModels;


namespace Template.Mobile.ViewModels
{
    public class PushSetupViewModel : ViewModelBase
    {
        private readonly IPushManager? _pushManager;
        //readonly IDialogService dialogs;


        public PushSetupViewModel(INavigationService navigationService, IPushManager? pushManager = null) : base(navigationService)
        {
            this._pushManager = pushManager;

            this.RequestAccess = ReactiveCommand.CreateFromTask(
                () => this.Do(async () =>
                {
                    var result = await _pushManager.RequestAccess();
                    this.AccessStatus = result.Status;
                })
            );

            this.UnRegister = ReactiveCommand.CreateFromTask(
                () => this.Do(async () =>
                {
                    await _pushManager.UnRegister();
                    this.AccessStatus = AccessState.Disabled;
                }),
                this.WhenAny(
                    x => x.RegToken,
                    x => !x.GetValue().IsEmpty()
                )
            );

            this.UpdateTag = ReactiveCommand.CreateFromTask(
                () => this.Do(() => _pushManager.TryUpdateTags(this.Tag)),
                this.WhenAny(
                    x => x.Tag,
                    x => x.RegToken,
                    (tag, token) =>
                        (_pushManager?.IsTagsSupport() ?? false) &&
                        !tag.GetValue().IsEmpty() &&
                        !token.GetValue().IsEmpty()
                )
            );
        }


        public ICommand RequestAccess { get; }
        public ICommand UnRegister { get; }
        public ICommand UpdateTag { get; }

        public bool IsTagsSupported => _pushManager?.IsTagsSupport() ?? false;
        public string Implementation => _pushManager?.GetType().FullName ?? "None";
        [Reactive] public string Tag { get; set; }
        [Reactive] public string RegToken { get; private set; }
        [Reactive] public DateTime? RegDate { get; 
            private set; }
        [Reactive] public DateTime? ExpiryDate { get; private set; }
        [Reactive] public AccessState AccessStatus { get; private set; } = AccessState.Unknown;


        public override void OnAppearing()
        {
            base.OnAppearing();
            Refresh();
        }


        void Refresh()
        {
            RegToken = _pushManager?.CurrentRegistrationToken ?? "-";
            Console.WriteLine("REGTOKEN : " + RegToken);
            RegDate = _pushManager?.CurrentRegistrationTokenDate?.ToLocalTime();
            ExpiryDate = _pushManager?.CurrentRegistrationExpiryDate?.ToLocalTime();
            Tag = _pushManager?.TryGetTags()?.FirstOrDefault() ?? String.Empty;
        }


        async Task Do(Func<Task> task)
        {
            if (_pushManager == null)
                return;

            //await this.dialogs.LoadingTask(task, "Updating Push Details");
            //await this.dialogs.Snackbar("Push Details Updated");

            UserDialogs.Instance.ShowLoading("Updating Push Details");
            await Task.Run(task);
            UserDialogs.Instance.HideLoading();
            UserDialogs.Instance.Toast("Push Details Updated");


            this.Refresh();
        }
    }
}

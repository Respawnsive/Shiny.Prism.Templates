using System;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.AppModel;
using Prism.Commands;
using Prism.Navigation;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Shiny;
using Shiny.Localization;
using Template.Mobile.Services.Dialogs;
using Template.Mobile.Services.Settings;

namespace Template.Mobile.ViewModels
{
    public abstract class ViewModelBase : ReactiveObject,
                                      IAutoInitialize,
                                      IInitialize,
                                      IInitializeAsync,
                                      INavigatedAware,
                                      IPageLifecycleAware,
                                      IDestructible,
                                      IConfirmNavigationAsync
    {
        protected ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
            SettingsService = ShinyHost.Resolve<ISettingsService>();
            //DialogsService = ShinyHost.Resolve<IDialogService>();
            LocalizationManager = ShinyHost.Resolve<ILocalizationManager>();

            NavigateBackCommand = ExecutionAwareCommand.FromTask(NavigateBackAsync)
                .OnIsExecutingChanged(OnIsExecutingChanged);
        }

        #region Services

        protected INavigationService NavigationService { get; }

        protected IDialogService DialogsService { get; }

        protected ISettingsService SettingsService { get; }

        protected ILocalizationManager LocalizationManager { get; }

        #endregion

        #region Properties

        public string this[string name] => LocalizationManager.GetText(name);

        private int _busyCounter;
        protected int BusyCounter
        {
            get => _busyCounter;
            set
            {
                _busyCounter = Math.Max(value, 0);
                IsBusy = _busyCounter > 0;
            }
        }

        [Reactive] 
        public bool IsBusy { get; private set; }

        [Reactive] 
        public string Title { get; protected set; }

        #endregion

        #region Commands

        public ICommand NavigateBackCommand { get; }

        #endregion

        #region Methods

        private void OnIsExecutingChanged(bool isExecuting)
        {
            if (isExecuting)
                BusyCounter++;
            else
                BusyCounter--;
        }

        #endregion

        #region Lifecycle

        private CompositeDisposable _deactivateWith;
        protected CompositeDisposable DeactivateWith => _deactivateWith ??= new CompositeDisposable();

        protected CompositeDisposable DestroyWith { get; } = new CompositeDisposable();

        protected virtual void Deactivate()
        {
            _deactivateWith?.Dispose();
            _deactivateWith = null;
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters) => this.Deactivate();

        public virtual void Initialize(INavigationParameters parameters) { }

        public virtual Task InitializeAsync(INavigationParameters parameters) => Task.CompletedTask;

        public virtual void OnNavigatedTo(INavigationParameters parameters) { }

        public virtual void OnAppearing() { }

        public virtual void OnDisappearing() { }

        public virtual void Destroy() => this.DestroyWith?.Dispose();

        public virtual Task<bool> CanNavigateAsync(INavigationParameters parameters) => Task.FromResult(true);

        public virtual Task NavigateBackAsync() => NavigationService.GoBackAsync(); 

        #endregion
    }
}

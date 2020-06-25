using System;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using System.Windows.Input;
using Localizr;
using Prism.AppModel;
using Prism.Commands;
using Prism.Navigation;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Shiny;
using Template.Mobile.Helpers;
using Template.Mobile.Services;

namespace Template.Mobile.ViewModels
{
    public abstract class ViewModelBase : ReactiveObject,
                                      IAutoInitialize,
                                      IInitialize,
                                      INavigatedAware,
                                      IPageLifecycleAware,
                                      IDestructible
    {
        protected ViewModelBase(INavigationService navigationService)
        {
            try
            {
                NavigationService = navigationService;
                SettingsService = ShinyHost.Resolve<ISettingsService>();
                LocalizationManager = ShinyHost.Resolve<ILocalizrManager>();
                DialogsService = ShinyHost.Resolve<IDialogService>();
            }
            catch(Exception ex)
            {
                Logger.Write(ex);
            }
        }


        #region Services

        protected INavigationService NavigationService { get; }

        protected IDialogService DialogsService { get; }

        protected ISettingsService SettingsService { get; }

        protected ILocalizrManager LocalizationManager { get; }

        #endregion

        
        #region Properties

        /// <summary>
        /// Useful for localization -> in xaml just bind a TextProperty={binding [key]}
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string this[string name] => LocalizationManager.GetText(name);

        /// <summary>
        /// Useful for managing IsBusy with potential multiple calls (background thread) and automaticaly managed with "OnIsExecutingChanged" methods
        /// </summary>
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


        #endregion

        
        #region Commands



        #endregion

        
        #region Methods

        protected void SetIsExecuting(bool isExecuting)
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
        public virtual void Destroy() => this.DestroyWith?.Dispose();

        protected virtual void Deactivate()
        {
            _deactivateWith?.Dispose();
            _deactivateWith = null;
        }

        public virtual void Initialize(INavigationParameters parameters) { }

        public virtual void OnNavigatedFrom(INavigationParameters parameters) => this.Deactivate();

        public virtual void OnNavigatedTo(INavigationParameters parameters) { }

        public virtual void OnAppearing() 
        {
            try
            {
                Console.WriteLine("PRISM GetNavigationUriPath() : ");
                Console.WriteLine(NavigationService.GetNavigationUriPath());
            }
            catch (Exception ex)
            {
            }
        }

        public virtual void OnDisappearing() { }

        public virtual void OnRotationChanged() { }


        #endregion
    }
}

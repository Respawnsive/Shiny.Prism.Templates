using System;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using $safeprojectname$.Models;
using $safeprojectname$.Views;
using Xamarin.Forms;

namespace $safeprojectname$.ViewModels
{
    public class WalkThroughViewModel : ViewModelBase
    {

        #region Lifecycle

        public WalkThroughViewModel(INavigationService navigationService) : base(navigationService)
        {
            NavigateOutCommand = ExecutionAwareCommand.FromTask(NavigateOutAsync)
                .OnIsExecutingChanged(SetIsExecuting);

            InitWT();

            this.WhenAnyValue(x => x.IndicatorPosition).Subscribe(EvaluatePosition).DisposeWith(DestroyWith);
        }

        #endregion

        #region Bindables

        [Reactive] public ObservableCollection<WalkThroughItemModel> WTItems { get; set; } = new ObservableCollection<WalkThroughItemModel>();
        public ICommand NavigateOutCommand { get; }

        [Reactive] public int IndicatorPosition { get; set; }

        [Reactive] public bool IsLastPosition { get;
            private set; }


        #endregion

        #region Methods

        private void EvaluatePosition(int value)
        {
            IsLastPosition = IndicatorPosition == WTItems.Count-1;
        }

        private async Task NavigateOutAsync()
        {
            string sQueryString;
            if (Device.RuntimePlatform == Device.iOS)
            {
                sQueryString = $"///{nameof(MDPage)}/{nameof(NavigationPage)}/{nameof(HomePage)}";
            }
            else
            {
                sQueryString = $"///{nameof(MDPage)}/{nameof(NavigationPage)}/{nameof(HomePage)}";
            }
            await NavigationService.NavigateAsync(sQueryString);
        }

        public void InitWT()
        {
            WTItems.Clear();
            WTItems.Add(new WalkThroughItemModel { Title = "Title1", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat."});
            WTItems.Add(new WalkThroughItemModel { Title = "Title2", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." });
            WTItems.Add(new WalkThroughItemModel { Title = "Title3", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." });
            WTItems.Add(new WalkThroughItemModel { Title = "Title4", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." });
        } 

        #endregion
    }

}

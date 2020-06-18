using Prism.Commands;
using Prism.Navigation;
using ReactiveUI.Fody.Helpers;
using Shiny;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Template.Mobile.Models.SampleApi;
using Template.Mobile.Services;
using Xamarin.Forms;

namespace Template.Mobile.ViewModels
{
    public class Debug_SamplesViewModel : ViewModelBase
    {
        public Debug_SamplesViewModel(INavigationService navigationService, ISampleApiService sampleApiService) : base(navigationService)
        {
            _sampleApiService = sampleApiService;

            //Create commands
            //LoadCommand = ExecutionAwareCommand.FromTask(GetUsersAsync).OnIsExecutingChanged(OnIsExecutingChanged);

            //Subscribe to Properties changes
            //this.WhenAnyValue(x => x.Users).Subscribe(methodX).DisposeWith(DestroyWith);
        }


        #region Services

        private readonly ISampleApiService _sampleApiService;

        #endregion


        #region Properties

        [Reactive]
        public ObservableCollection<User> Users { get; set; }

        #endregion


        #region Commands

        //public ICommand LoadCommand { get; }

        #endregion


        #region Methods

        private async Task GetUsersAsync()
        {
            var userList = await _sampleApiService.GetUsersAsync(0);
            if (!userList.Data.IsEmpty())
                Users = new ObservableCollection<User>(userList.Data);
        }

        #endregion


        #region LifeCycle

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
            Device.InvokeOnMainThreadAsync(GetUsersAsync);
        }


        #endregion


    }
}

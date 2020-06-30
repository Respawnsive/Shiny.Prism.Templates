using Prism.Navigation;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using System.Windows.Input;
using $safeprojectname$.Helpers;

namespace $safeprojectname$.ViewModels
{
    public class Debug_ThemesViewModel : ViewModelBase
    {
        public Debug_ThemesViewModel(INavigationService navigationService) : base(navigationService)
        {
            //Create commands
            //LoadCommand = ExecutionAwareCommand.FromTask(LoadDatas).OnIsExecutingChanged(OnIsExecutingChanged);

            //Subscribe to Properties changes
            this.WhenAnyValue(x => x.SelectedTheme).Subscribe(LoadTheme).DisposeWith(DestroyWith);
        }

        
        #region Services



        #endregion


        #region Properties

        [Reactive]
        public string SelectedTheme { get; set; }

        [Reactive]
        public int TestValue { get; set; }

        public ObservableCollection<string> Themes { get; set; }

        #endregion


        #region Commands

        //public ICommand LoadCommand { get; }

        #endregion


        #region Methods

        private void LoadDatas()
        {
            try
            {
                //Load data for this ViewModel (fake)
                Themes = new ObservableCollection<string>(new List<string>()
                {
                    "Acrylic",
                    "AcrylicBlur",
                    "AcrylicDarkBlur",
                    "Dark",
                    "Light"
                });
                TestValue = 2;
                SelectedTheme = Enum.GetName(typeof(AppTheme), ThemeHelper.GetCurrentTheme());

            }
            catch (Exception ex)
            {
                DialogsService?.Toast(this["Msg_RedToast_Error_Unknown"]);
                Logger.Write(ex);
            }
            finally
            {

            }
            
        }

        private void LoadTheme(string themename)
        {
            if (!String.IsNullOrWhiteSpace(themename))
            {
                switch (themename)
                {
                    case "Acrylic":
                        ThemeHelper.ApplyTheme(AppTheme.Acrylic);
                        break;
                    case "AcrylicBlur":
                        ThemeHelper.ApplyTheme(AppTheme.AcrylicBlur);
                        break;
                    case "AcrylicDarkBlur":
                        ThemeHelper.ApplyTheme(AppTheme.AcrylicDarkBlur);
                        break;
                    case "Dark":
                        ThemeHelper.ApplyTheme(AppTheme.Dark);
                        break;
                    case "Light":
                        ThemeHelper.ApplyTheme(AppTheme.Light);
                        break;
                }
            }
        }

        #endregion


        #region LifeCycle

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
            Task.Run(() => LoadDatas());
        }

        #endregion


    }
}

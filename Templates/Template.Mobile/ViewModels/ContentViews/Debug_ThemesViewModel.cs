using Prism.Commands;
using Prism.Navigation;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using System.Windows.Input;
using Template.Mobile.Helpers;

namespace Template.Mobile.ViewModels
{
    public class Debug_ThemesViewModel : ViewModelBase
    {
        public Debug_ThemesViewModel(INavigationService navigationService) : base(navigationService)
        {
            //Subscribe
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

        #endregion

        #region Methods

        private void LoadDatas()
        {
            Themes = new ObservableCollection<string>(new List<string>()
                {
                    "Acrylic",
                    "AcrylicBlur",
                    "AcrylicDarkBlur",
                    "Dark",
                    "Light"
                });
            TestValue = 2;
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

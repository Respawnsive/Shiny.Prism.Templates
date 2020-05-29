using Prism.Commands;
using Prism.Navigation;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Windows.Input;
using Template.Mobile.Helpers;

namespace Template.Mobile.ViewModels
{
    public class Debug_ThemingPageViewModel : ViewModelBase
    {
        public Debug_ThemingPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            try
            {
                //Title = this["MainView_Title"];

                Themes = new ObservableCollection<string>(new List<string>() 
                {
                    "Acrylic",
                    "AcrylicBlur",
                    "AcrylicDarkBlur",
                    "Dark",
                    "Light"
                });
                //Subscribe
                this.WhenAnyValue(x => x.SelectedTheme).Subscribe(LoadTheme).DisposeWith(DestroyWith);

                TestValue = 2;
            }
            catch(Exception ex)
            {
                Logger.Write(ex);
            }
        }

        [Reactive]
        public string SelectedTheme { get; set; }

        [Reactive]
        public int TestValue { get; set; }

        public ObservableCollection<string> Themes { get; set; }

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

    }
}

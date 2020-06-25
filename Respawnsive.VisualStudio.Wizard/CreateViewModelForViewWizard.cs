using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

namespace Respawnsive.VisualStudio.Wizard
{
    public class CreateViewModelForViewWizard : IWizard
    {
        //private readonly string ViewFolderName = "Views";
        //private readonly string ViewModelFolderName = "ViewModels";
        //private DTE _dte;
        //private string _viewName;
        //private string _viewModelName;
        //private string _templatesDirectory;
        //private string _rootNamespace;
        //private string _platform;

        public void BeforeOpeningFile(ProjectItem projectItem)
        {

        }

        public void ProjectFinishedGenerating(Project project)
        {
            
        }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
            
        }

        public void RunFinished()
        {
            //if (!this._rootNamespace.Contains(this.ViewFolderName))
            //    return;
            //string str = Path.Combine(Path.GetDirectoryName(this._templatesDirectory.Replace(this._platform.Equals("xf") ? "Xamarin.Forms" : "WPF", "Code")), "PrismViewModel.zip\\PrismViewModel.vstemplate");
            //IEnumerator enumerator = ((Project)((Array)((_DTE)this._dte).get_ActiveSolutionProjects()).GetValue(0)).get_ProjectItems().GetEnumerator();
            //try
            //{
            //    while (enumerator.MoveNext())
            //    {
            //        ProjectItem current = (ProjectItem)enumerator.Current;
            //        if (current.get_Name() == this.ViewModelFolderName && current.get_Kind() == "{6BB5F8EF-4483-11D3-8BCF-00C04F8EC28C}")
            //            current.get_ProjectItems().AddFromTemplate(str, this._viewModelName + ".cs");
            //        if (this._platform.Equals("xf"))
            //        {
            //            if (current.get_Name() == "App.xaml")
            //                this.EditAppRegisterTypesForNavigation(current.get_ProjectItems().Item((object)1).get_FileCodeModel().get_CodeElements());
            //            if (current.get_Name() == "App.cs")
            //                this.EditAppRegisterTypesForNavigation(current.get_FileCodeModel().get_CodeElements());
            //        }
            //    }
            //}
            //finally
            //{
            //    if (enumerator is IDisposable disposable)
            //        disposable.Dispose();
            //}
        }

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            //this._dte = automationObject as DTE;
            //this._platform = replacementsDictionary["$platform$"];
            //this._rootNamespace = replacementsDictionary["$rootnamespace$"];
            string ViewName = replacementsDictionary["$safeitemname$"];
            string ViewModelName = ViewName.Replace(".xaml", "").Replace("View", "ViewModel").Replace("Page", "ViewModel");
            //MessageBox.Show($"###RESPAWNSIVE### CreateViewModelForViewWizard(ViewName={ViewName} ViewModelName={ViewModelName})");
            replacementsDictionary.Add("$viewmodelName$", ViewModelName);
            //this._viewModelName = this._viewName + "ViewModel";
            //this._templatesDirectory = Path.GetDirectoryName(customParams[0] as string);
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }
    }
}

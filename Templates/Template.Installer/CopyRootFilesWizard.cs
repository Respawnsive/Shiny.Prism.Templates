using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

namespace Template.Installer
{
    public class CopyRootFilesWizard : IWizard
    {
        DTE _dte;

        // This method is called before opening any item that
        // has the OpenInEditor attribute.
        public void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        public void ProjectFinishedGenerating(Project project)
        {
        }

        // This method is only called for item templates,
        // not for project templates.
        public void ProjectItemFinishedGenerating(ProjectItem
            projectItem)
        {
        }

        // This method is called after the project is created.
        public void RunFinished()
        {
            try
            {

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            try
            {
                string SolutionPath = replacementsDictionary["$solutiondirectory$"];
                CopyRootFile(SolutionPath, "README.md");
                CopyRootFile(SolutionPath, "azure-pipelines.yml");
                CopyRootFile(SolutionPath, "Clean Bin-Obj.bat");
                CopyRootFile(SolutionPath, "Settings.XamlStyler");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // This method is only called for item templates,
        // not for project templates.
        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }

        private void CopyRootFile(string TargetFolderPath, string filename)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream($"Template.Installer.RootFiles.{filename}");
            if (stream != null)
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    var content = sr.ReadToEnd();
                    using (StreamWriter sw = new StreamWriter(Path.Combine(TargetFolderPath, filename)))
                    {
                        sw.Write(content);
                    }
                }
            }
        }
    }
}

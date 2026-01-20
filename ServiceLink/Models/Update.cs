using MahApps.Metro.Controls;
using System;
using System.Deployment.Application;
using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls.Dialogs;

namespace ServiceLink.Models
{
    internal class Update
    {
        public async Task RunUpdate()
        {
            VersionInfo versionInfo = new VersionInfo();
            string currentVersion = versionInfo.GetPublishedVersion();
            ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
            MetroWindow metroWindow = (MetroWindow)System.Windows.Application.Current.MainWindow;
            ProgressDialogController controller = null;

            try
            {
                UpdateCheckInfo info = await Task.Run(() => ad.CheckForDetailedUpdate());

                if (info.UpdateAvailable)
                {
                    bool doUpdate = true;
                    //if (!info.IsUpdateRequired)
                    //{
                    //    var settings = new MetroDialogSettings
                    //    {
                    //        AffirmativeButtonText = "Yes",
                    //        NegativeButtonText = "No",
                    //        DefaultButtonFocus = MessageDialogResult.Negative
                    //    };
                    //    var result = await metroWindow.ShowMessageAsync("Update Available", "An update is available. Would you like to update the application now?",
                    //        MessageDialogStyle.AffirmativeAndNegative, settings);

                    //    if (result != MessageDialogResult.Affirmative)
                    //        doUpdate = false;
                    //}
                    //else
                    //{
                    //    await metroWindow.ShowMessageAsync("Mandatory Update", $"This application requires an update to version {info.MinimumRequiredVersion}. The application will now update and restart.",
                    //        MessageDialogStyle.Affirmative);
                    //}

                    if (doUpdate)
                    {
                        controller = await metroWindow.ShowProgressAsync("Updating Application", "Please wait...");
                        controller.SetIndeterminate();
                        try
                        {
                            await Task.Run(() => ad.Update());
                            await controller.CloseAsync();
                            await metroWindow.ShowMessageAsync("Update Complete", "The application has been updated and will now restart.",
                            MessageDialogStyle.Affirmative);

                            System.Windows.Application.Current.Shutdown();
                            System.Windows.Forms.Application.Restart();

                        }
                        catch (DeploymentDownloadException dde)
                        {
                            await metroWindow.ShowMessageAsync("Update Failed", $"Cannot install the latest version. Please check your network connection and try again.\n\nError: {dde.Message}",
                            MessageDialogStyle.Affirmative);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await metroWindow.ShowMessageAsync("Update Error", $"An error occurred while checking for updates.\n\nError: {ex.Message}",
                MessageDialogStyle.Affirmative);
            }
        }
    }
}

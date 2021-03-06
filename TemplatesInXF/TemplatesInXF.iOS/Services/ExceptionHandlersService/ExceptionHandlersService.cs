﻿[assembly: Xamarin.Forms.Dependency(typeof(TemplatesInXF.iOS.Services.ExceptionHandlersService))]
namespace TemplatesInXF.iOS.Services
{
    using System;
    using System.IO;
    using TemplatesInXF.Services;
    using UIKit;

    public class ExceptionHandlersService : IExceptionHandlersService
    {
        public void ShowExceptionFile()
        {
            const string errorFilename = "Fatal.log";
            string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Resources);
            string errorFilePath = Path.Combine(libraryPath, errorFilename);

            if (!File.Exists(errorFilePath))
            {
                return;
            }

            string errorText = File.ReadAllText(errorFilePath);
            UIAlertController alertController = UIAlertController.Create("Crash Report", errorText, UIAlertControllerStyle.Alert);
            alertController.AddAction(UIAlertAction.Create("Clear", UIAlertActionStyle.Default, alert => { File.Delete(errorFilePath); }));
            alertController.AddAction(UIAlertAction.Create("Close", UIAlertActionStyle.Cancel, alert => { }));

            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alertController, true, null);
        }
    }
}
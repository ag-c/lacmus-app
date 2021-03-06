using System;
using System.IO;
using System.Reactive;
using Avalonia.Controls;
using LacmusApp.Services;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Validation.Extensions;
using ReactiveUI.Validation.Helpers;
using Serilog;

namespace LacmusApp.ViewModels
{
    public class SecondWizardViewModel : ReactiveValidationObject<SecondWizardViewModel>, IRoutableViewModel
    {
        public IScreen HostScreen { get; }
        public string UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);
        public ReactiveCommand<Unit, Unit> SavePhotos { get; }

        [Reactive] public string OutputPath { get; set; }
        [Reactive] public LocalizationContext LocalizationContext { get; set; }

        public SecondWizardViewModel(IScreen screen, LocalizationContext localizationContext)
        {
            HostScreen = screen;
            LocalizationContext = localizationContext;
            this.ValidationRule(
                viewModel => viewModel.OutputPath,
                Directory.Exists,
                path => $"Incorrect path {path}");
            
            SavePhotos = ReactiveCommand.Create(Save);
        }
        private async void Save()
        {
            try
            {
                var dig = new OpenFolderDialog()
                {
                    //TODO: Multi language support
                    Title = "Select folder to save"
                };
                var dirPath = await dig.ShowAsync(new Window());
                OutputPath = dirPath;
            }
            catch (Exception e)
            {
                Log.Error("Unable to setup input path.", e);
            }
        }
    }
}
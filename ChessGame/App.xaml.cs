using ChessGame.Extensions;
using ChessGame.Model;
using ChessGame.Services;
using ChessGame.Services.Interfaces;
using ChessGame.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace ChessGame
{
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; }

        public App()
        {
            var services = new ServiceCollection();

            services.AddAppServices();
            services.AddFactories();
            services.AddMoveStrategies();
            services.AddGameRules();
            services.AddMessageHandlers();
            services.AddViewModels();

            ServiceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var settingsService = ServiceProvider.GetRequiredService<ISettingsService>();
            var settings = settingsService.Load();

            var mainWindow = new MainWindow();
            ApplySettings(mainWindow, settings);

            var mainVM = ServiceProvider.GetRequiredService<MainViewModel>();
            mainWindow.DataContext = mainVM;

            mainWindow.Show();

            var nav = ServiceProvider.GetRequiredService<INavigationService>();
            nav.NavigateTo<MenuViewModel>();
        }

        private void ApplySettings(Window window, SettingsData settings)
        {
            if (settings.IsFullScreen)
            {
                window.WindowStyle = WindowStyle.None;
                window.WindowState = WindowState.Maximized;
            }
            else
            {
                window.WindowStyle = WindowStyle.SingleBorderWindow;
                window.WindowState = WindowState.Normal;
                window.Width = settings.Width;
                window.Height = settings.Height;
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }
        }
    }
}
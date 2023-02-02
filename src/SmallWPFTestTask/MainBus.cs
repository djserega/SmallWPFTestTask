using Microsoft.Extensions.DependencyInjection;
using System;

namespace SmallWPFTestTask
{
    /// <summary>
    /// Class MVVM-connector
    /// </summary>
    public class MainBus
    {
        private static readonly IServiceProvider _busProvider;

        static MainBus()
        {
            ServiceCollection services = new();

            services.AddSingleton<ViewModels.MainWindow>();
            
            _busProvider = services.BuildServiceProvider();
        }

        public static T? Resolve<T>() => _busProvider.GetService<T>();

        public ViewModels.MainWindow? MainWindowViewModel { get => Resolve<ViewModels.MainWindow>(); }
    }
}

using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Notebook.Data.Abstract;
using Notebook.Data.Implemetion;
using Notebook.Domain;
using Notebook.Models;
using Notebook.ViewModels;

namespace Notebook
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ApplicationContext>().AsSelf();
            builder.RegisterType<EFUserRepository>().As<IRepository<User>>();
            builder.RegisterType<AuthViewModel>().AsSelf();
            var container = builder.Build();
            var authViewModel = container.Resolve<AuthViewModel>();
            var authWindow = new AuthWindow{ DataContext = authViewModel };
            authWindow.Show();
        }
    }
}

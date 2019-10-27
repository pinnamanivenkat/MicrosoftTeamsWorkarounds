using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TeamsContactsGroupCreator
{
    /// <summary>
    /// Interaction logic for App.xaml3+
    /// </summary>
    public partial class App : Application
    {
        public static MainWindow ParentWindow;

        internal static string ClientId = "0b8b0665-bc13-4fdc-bd72-e0227b9fc011";
        static string Tenant = "common";

        static App()
        {
            PublicClientApp = PublicClientApplicationBuilder.Create(ClientId).WithAuthority(AzureCloudInstance.AzurePublic, Tenant).Build();
        }


        public static IPublicClientApplication PublicClientApp { get; private set; }
    }
}

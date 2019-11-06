using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPClient.WCFBackgroundService;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string serviceName = "bthserv";
        private LocalServiceClient client = new LocalServiceClient();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void StopButton_Click(object sender, RoutedEventArgs e)
        {
            var status = await client.StopServiceAsync(serviceName);
            textBlockStatus.Text = status.ToString();
        }

        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            var status = await client.StartServiceAsync(serviceName);
            textBlockStatus.Text = status.ToString();
        }

        private async void QueryButton_Click(object sender, RoutedEventArgs e)
        {
            var status = await client.GetServiceStatusAsync(serviceName);
            textBlockStatus.Text = status.ToString();
        }

        private async void RunWCFService_Click(object sender, RoutedEventArgs e)
        {
            if (ApiInformation.IsApiContractPresent("Windows.ApplicationModel.FullTrustAppContract", 1, 0))
            {
                await FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync();
            }
        }
    }
}

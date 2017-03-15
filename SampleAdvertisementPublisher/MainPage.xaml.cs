using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SampleAdvertisementPublisher
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private BluetoothLEAdvertisementPublisher publisher;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Initialize
            publisher = new BluetoothLEAdvertisementPublisher();
            var manufacturerData = new BluetoothLEManufacturerData();
            manufacturerData.CompanyId = 0xFFFE;

            var writer = new DataWriter();
            writer.WriteUInt64(0x1234567812345678);

            manufacturerData.Data = writer.DetachBuffer();

            publisher.Advertisement.ManufacturerData.Add(manufacturerData);

            publisher?.Start();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            publisher?.Stop();
        }
    }
}

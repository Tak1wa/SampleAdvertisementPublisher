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
            manufacturerData.CompanyId = 0x004c;
            byte[] dataArray = new byte[] {
                // お決まり
                0x02, 0x15,
                // UUID
                0x93, 0xBE, 0xB3, 0xD9,
                0x31, 0x60, 0x4B, 0xB9,
                0xB5, 0xB0, 0xB7, 0xB1,
                0xF6, 0x14, 0x15, 0xD8,
                // Major
                0x01, 0x00,
                // Minor
                0x00, 0x01,
                // TX power
                0xc5
            };

            manufacturerData.Data = dataArray.AsBuffer();
            publisher.Advertisement.ManufacturerData.Add(manufacturerData);

            publisher?.Start();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            publisher?.Stop();
        }
    }
}

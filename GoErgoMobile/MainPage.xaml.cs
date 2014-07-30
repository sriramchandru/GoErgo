using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using GoErgoMobile.Resources;
using Windows.Networking.Proximity;
using Windows.Networking.Sockets;
using Windows.Foundation;
using Windows.Storage.Streams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
//using SimpleAccelerometerSensor.Resources;
using Microsoft.Devices.Sensors;
using Microsoft.Xna.Framework;
using System.Threading;
using Microsoft.Phone.Tasks;
using Windows.Networking.Proximity;
using Windows.Networking.Sockets;
using Windows.Foundation;
using Windows.Storage.Streams;
using System.Collections.ObjectModel;
using System.Windows.Input;


namespace GoErgoMobile
{
    public partial class MainPage : PhoneApplicationPage
    {
        ObservableCollection<PairedDeviceInfo> _pairedDevices;  // a local copy of paired device information
        StreamSocket _socket; // socket object used to communicate with the device

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            // Bluetooth is not available in the emulator. 
            if (Microsoft.Devices.Environment.DeviceType == Microsoft.Devices.DeviceType.Emulator)
            {
                MessageBox.Show(AppResources.Msg_EmulatorMode,"Warning",MessageBoxButton.OK);
            }

            _pairedDevices = new ObservableCollection<PairedDeviceInfo>();
            PairedDevicesList.ItemsSource = _pairedDevices;




        }

        private void FindPairedDevices_Tap(object sender, GestureEventArgs e)
        {
            RefreshPairedDevicesList();
        }

        /// <summary>
        /// Asynchronous call to re-populate the ListBox of paired devices.
        /// </summary>
        private async void RefreshPairedDevicesList()
        {
            try
            {
                // Search for all paired devices
                PeerFinder.AlternateIdentities["Bluetooth:Paired"] = "";
                var peers = await PeerFinder.FindAllPeersAsync();

                // By clearing the backing data, we are effectively clearing the ListBox
                _pairedDevices.Clear();

                if (peers.Count == 0)
                {
                    MessageBox.Show(AppResources.Msg_NoPairedDevices);
                }
                else
                {
                    // Found paired devices.
                    foreach (var peer in peers)
                    {
                        _pairedDevices.Add(new PairedDeviceInfo(peer));
                    }
                }
            }
            catch (Exception ex)
            {
                if ((uint)ex.HResult == 0x8007048F)
                {
                    var result = MessageBox.Show(AppResources.Msg_BluetoothOff, "Bluetooth Off", MessageBoxButton.OKCancel);
                    if (result == MessageBoxResult.OK)
                    {
                        ShowBluetoothcControlPanel();
                    }
                }
                else if ((uint)ex.HResult == 0x80070005)
                {
                    MessageBox.Show(AppResources.Msg_MissingCaps);
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ConnectToSelected_Tap_1(object sender, GestureEventArgs e)
        {
            // Because I enable the ConnectToSelected button only if the user has
            // a device selected, I don't need to check here whether that is the case.

            // Connect to the device
            PairedDeviceInfo pdi = PairedDevicesList.SelectedItem as PairedDeviceInfo;
            PeerInformation peer = pdi.PeerInfo;

            // Asynchronous call to connect to the device
            //MessageBox.Show("Tapped connect");
            ConnectToDevice(peer);
        }
        DataWriter dw; 
        private async void ConnectToDevice(PeerInformation peer)
        {
            if (_socket != null)
            {
                // Disposing the socket with close it and release all resources associated with the socket
                _socket.Dispose();
            }

            try
            {
                _socket = new StreamSocket();
                string serviceName = (String.IsNullOrWhiteSpace(peer.ServiceName)) ? tbServiceName.Text : peer.ServiceName;

                // Note: If either parameter is null or empty, the call will throw an exception
                await _socket.ConnectAsync(peer.HostName, "{00001101-0000-1000-8000-00805f9b34fb}");

                // If the connection was successful, the RemoteAddress field will be populated
               MessageBox.Show(String.Format(AppResources.Msg_ConnectedTo, _socket.Information.RemoteAddress.DisplayName));

               dw = new DataWriter(_socket.OutputStream);
                
               dw.WriteString("hello World!\n");
               await dw.StoreAsync();

               goAccelerometer(dw);
               



                
            }
            catch (Exception ex)
            {
                // In a real app, you would want to take action dependent on the type of 
                // exception that occurred.
                MessageBox.Show(ex.Message);

                _socket.Dispose();
                _socket = null;
            }
        }

        private void PairedDevicesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Check whether the user has selected a device
            if (PairedDevicesList.SelectedItem == null)
            {
                // No - hide these fields
                ConnectToSelected.IsEnabled = false;
                ServiceNameInput.Visibility = Visibility.Collapsed;
            }
            else
            {
                // Yes - enable the connect button
                ConnectToSelected.IsEnabled = true;

                // Show the service name field, if the ServiceName associated with this device is currently empty
                PairedDeviceInfo pdi = PairedDevicesList.SelectedItem as PairedDeviceInfo;
                ServiceNameInput.Visibility = (String.IsNullOrWhiteSpace(pdi.ServiceName)) ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private void ShowBluetoothcControlPanel()
        {
            ConnectionSettingsTask connectionSettingsTask = new ConnectionSettingsTask();
            connectionSettingsTask.ConnectionSettingsType = ConnectionSettingsType.Bluetooth;
            connectionSettingsTask.Show();
        }

        Accelerometer accelerometer;

        public void goAccelerometer(DataWriter dw1)
        {
             if (!Accelerometer.IsSupported)
            {
                MessageBox.Show("Accelerometer Not Supported.");
            }
            //PeerFinder.ConnectionRequested += PeerFinder_connexionRequested;
            try
            {
                //AppToDevice();
            }
            catch
            {
                MessageBox.Show("Accelerometer Failed");
            }
        }

        private void startAcc_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (accelerometer == null)
            {
                // Instantiate the Accelerometer.
                accelerometer = new Accelerometer();
                accelerometer.TimeBetweenUpdates = TimeSpan.FromMilliseconds(500);
                accelerometer.CurrentValueChanged +=
                    new EventHandler<SensorReadingEventArgs<AccelerometerReading>>(accelerometer_CurrentValueChanged);
            }


            try
            {
                MessageBox.Show("starting accelerometer.");
                accelerometer.Start();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("unable to start accelerometer.");
            }
        }

        private void stopAcc_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (accelerometer != null)
            {
                accelerometer.Stop();
            }
        }

        void accelerometer_CurrentValueChanged(object sender, SensorReadingEventArgs<AccelerometerReading> e)
        {
            // Call UpdateUI on the UI thread and pass the AccelerometerReading.
            Dispatcher.BeginInvoke(() => UpdateUI(e.SensorReading));
        }

        async private void UpdateUI(AccelerometerReading accelerometerReading)
        {           
            Vector3 acceleration = accelerometerReading.Acceleration;

            float angle = 90 - (float)acceleration.Y * 90;
            //item1text.Text = "Inclination angle = " + angle.ToString()+ "\n\n X value" + acceleration.X.ToString() + "\nY value" + acceleration.Y.ToString() + "\nZ value" + acceleration.Z.ToString();
            dw.WriteString(angle.ToString() + "\n");
            await dw.StoreAsync();
            //Thread.Sleep(1000);
        }












    }

    /// <summary>
    ///  Class to hold all paired device information
    /// </summary>
    public class PairedDeviceInfo
    {
        internal PairedDeviceInfo(PeerInformation peerInformation)
        {
            this.PeerInfo = peerInformation;
            this.DisplayName = this.PeerInfo.DisplayName;
            this.HostName = this.PeerInfo.HostName.DisplayName;
            this.ServiceName = this.PeerInfo.ServiceName;
        }

        public string DisplayName { get; private set; }
        public string HostName { get; private set; }
        public string ServiceName { get; private set; }
        public PeerInformation PeerInfo { get; private set; }
    }






















}

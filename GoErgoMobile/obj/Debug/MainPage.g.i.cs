﻿#pragma checksum "C:\Users\sriramch\Documents\GitHub\GoErgo\GoErgo\GoErgoMobile\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F5D90CCE764F5AE2600A9E7E7032C38D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace GoErgoMobile {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Button FindPairedDevices;
        
        internal System.Windows.Controls.ListBox PairedDevicesList;
        
        internal System.Windows.Controls.StackPanel ServiceNameInput;
        
        internal System.Windows.Controls.TextBox tbServiceName;
        
        internal System.Windows.Controls.Button ConnectToSelected;
        
        internal System.Windows.Controls.Button stopAcc;
        
        internal System.Windows.Controls.Button startAcc;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/GoErgoMobile;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.FindPairedDevices = ((System.Windows.Controls.Button)(this.FindName("FindPairedDevices")));
            this.PairedDevicesList = ((System.Windows.Controls.ListBox)(this.FindName("PairedDevicesList")));
            this.ServiceNameInput = ((System.Windows.Controls.StackPanel)(this.FindName("ServiceNameInput")));
            this.tbServiceName = ((System.Windows.Controls.TextBox)(this.FindName("tbServiceName")));
            this.ConnectToSelected = ((System.Windows.Controls.Button)(this.FindName("ConnectToSelected")));
            this.stopAcc = ((System.Windows.Controls.Button)(this.FindName("stopAcc")));
            this.startAcc = ((System.Windows.Controls.Button)(this.FindName("startAcc")));
        }
    }
}


﻿#pragma checksum "..\..\CustomerWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0C0C2FD1598EF319C34327A0D10D84395DA259CA3BEFA1D26C90FF3248653D1A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ProjectBookStoreHw;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ProjectBookStoreHw {
    
    
    /// <summary>
    /// CustomerWindow
    /// </summary>
    public partial class CustomerWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\CustomerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCustomer_Id;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\CustomerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCustomer_Name;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\CustomerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAddress;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\CustomerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonAddCustomer;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\CustomerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonDeleteCustomer;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\CustomerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView customersListView;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\CustomerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonSearchCustomers;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\CustomerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonUpdateCustomer;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\CustomerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtEmail;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ProjectBookStoreHw;component/customerwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CustomerWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtCustomer_Id = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtCustomer_Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtAddress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.ButtonAddCustomer = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\CustomerWindow.xaml"
            this.ButtonAddCustomer.Click += new System.Windows.RoutedEventHandler(this.ButtonAddCustomer_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.buttonDeleteCustomer = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\CustomerWindow.xaml"
            this.buttonDeleteCustomer.Click += new System.Windows.RoutedEventHandler(this.buttonDeleteCustomer_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.customersListView = ((System.Windows.Controls.ListView)(target));
            
            #line 22 "..\..\CustomerWindow.xaml"
            this.customersListView.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.customersListView_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ButtonSearchCustomers = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\CustomerWindow.xaml"
            this.ButtonSearchCustomers.Click += new System.Windows.RoutedEventHandler(this.ButtonSearchCustomers_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ButtonUpdateCustomer = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\CustomerWindow.xaml"
            this.ButtonUpdateCustomer.Click += new System.Windows.RoutedEventHandler(this.ButtonUpdateCustomer_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.txtEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


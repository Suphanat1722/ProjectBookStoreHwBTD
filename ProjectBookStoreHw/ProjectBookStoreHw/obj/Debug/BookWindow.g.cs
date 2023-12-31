﻿#pragma checksum "..\..\BookWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "63288C264C41C9D92E193961E92C01FA5D38C64740E6A320F7975689CAD9C8B3"
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
    /// BookWindow
    /// </summary>
    public partial class BookWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\BookWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTitleBook;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\BookWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDescriptionBook;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\BookWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPriceBook;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\BookWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonAddBook;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\BookWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonDeleteBook;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\BookWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView booksListView;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\BookWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonSearchBook;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\BookWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonUpdateBook;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\BookWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtIsbn;
        
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
            System.Uri resourceLocater = new System.Uri("/ProjectBookStoreHw;component/bookwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\BookWindow.xaml"
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
            this.txtTitleBook = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtDescriptionBook = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtPriceBook = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.ButtonAddBook = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\BookWindow.xaml"
            this.ButtonAddBook.Click += new System.Windows.RoutedEventHandler(this.ButtonAddBook_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.buttonDeleteBook = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\BookWindow.xaml"
            this.buttonDeleteBook.Click += new System.Windows.RoutedEventHandler(this.buttonDeleteBook_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.booksListView = ((System.Windows.Controls.ListView)(target));
            
            #line 22 "..\..\BookWindow.xaml"
            this.booksListView.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.booksListView_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ButtonSearchBook = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\BookWindow.xaml"
            this.ButtonSearchBook.Click += new System.Windows.RoutedEventHandler(this.ButtonSearchBook_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ButtonUpdateBook = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\BookWindow.xaml"
            this.ButtonUpdateBook.Click += new System.Windows.RoutedEventHandler(this.ButtonUpdateBook_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.txtIsbn = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "..\..\KlijentHomePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5B78F665009A03927BDC7B22EA2D2057CB95BF3B5CA0C77C74DD45105643FE1D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using Teretana;


namespace Teretana {
    
    
    /// <summary>
    /// KlijentHomePage
    /// </summary>
    public partial class KlijentHomePage : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\KlijentHomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClanarina;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\KlijentHomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnProdavnica;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\KlijentHomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNalog;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\KlijentHomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuLogOut;
        
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
            System.Uri resourceLocater = new System.Uri("/Teretana;component/klijenthomepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\KlijentHomePage.xaml"
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
            this.btnClanarina = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\KlijentHomePage.xaml"
            this.btnClanarina.Click += new System.Windows.RoutedEventHandler(this.btnClanarina_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnProdavnica = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\KlijentHomePage.xaml"
            this.btnProdavnica.Click += new System.Windows.RoutedEventHandler(this.btnProdavnica_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnNalog = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\KlijentHomePage.xaml"
            this.btnNalog.Click += new System.Windows.RoutedEventHandler(this.btnNalog_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.menuLogOut = ((System.Windows.Controls.MenuItem)(target));
            
            #line 14 "..\..\KlijentHomePage.xaml"
            this.menuLogOut.Click += new System.Windows.RoutedEventHandler(this.menuLogOut_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

﻿#pragma checksum "..\..\..\..\Miscellaneous\ViewCharter.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "68A31211B1826CCF84FFD9F83E6BC393"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
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
using System.Windows.Forms.Integration;
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


namespace TransportCompany.Miscellaneous {
    
    
    /// <summary>
    /// ViewCharter
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class ViewCharter : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\Miscellaneous\ViewCharter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ViewRequestForm;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Miscellaneous\ViewCharter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCustomerId;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Miscellaneous\ViewCharter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chbxViewAll;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Miscellaneous\ViewCharter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnViewCharter;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Miscellaneous\ViewCharter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblViewCharterRequest;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Miscellaneous\ViewCharter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid SearchCharterDataGrid;
        
        #line default
        #line hidden
        
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
            System.Uri resourceLocater = new System.Uri("/TransportCompany;component/miscellaneous/viewcharter.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Miscellaneous\ViewCharter.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ViewRequestForm = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.txtCustomerId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.chbxViewAll = ((System.Windows.Controls.CheckBox)(target));
            
            #line 26 "..\..\..\..\Miscellaneous\ViewCharter.xaml"
            this.chbxViewAll.Checked += new System.Windows.RoutedEventHandler(this.chbxViewAll_Checked);
            
            #line default
            #line hidden
            
            #line 26 "..\..\..\..\Miscellaneous\ViewCharter.xaml"
            this.chbxViewAll.Unchecked += new System.Windows.RoutedEventHandler(this.chbxViewAll_UnChecked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnViewCharter = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\..\Miscellaneous\ViewCharter.xaml"
            this.btnViewCharter.Click += new System.Windows.RoutedEventHandler(this.btnViewCharter_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.lblViewCharterRequest = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.SearchCharterDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


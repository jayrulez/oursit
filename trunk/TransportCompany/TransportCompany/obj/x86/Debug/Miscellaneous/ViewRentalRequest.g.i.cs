﻿#pragma checksum "..\..\..\..\Miscellaneous\ViewRentalRequest.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0C5CF12A1CEF7E05E99831C8D6E12D3E"
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
using TransportCompany;
using TransportCompany.CustomControls;


namespace TransportCompany.Miscellaneous {
    
    
    /// <summary>
    /// ViewRentalRequest
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class ViewRentalRequest : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\Miscellaneous\ViewRentalRequest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ViewRequestForm;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Miscellaneous\ViewRentalRequest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCustomerId;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Miscellaneous\ViewRentalRequest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chbxViewAll;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Miscellaneous\ViewRentalRequest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnViewRental;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Miscellaneous\ViewRentalRequest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblViewRentalRequest;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Miscellaneous\ViewRentalRequest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid SearchRentalDataGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/TransportCompany;component/miscellaneous/viewrentalrequest.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Miscellaneous\ViewRentalRequest.xaml"
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
            
            #line 26 "..\..\..\..\Miscellaneous\ViewRentalRequest.xaml"
            this.chbxViewAll.Checked += new System.Windows.RoutedEventHandler(this.chbxViewAll_Checked);
            
            #line default
            #line hidden
            
            #line 26 "..\..\..\..\Miscellaneous\ViewRentalRequest.xaml"
            this.chbxViewAll.Unchecked += new System.Windows.RoutedEventHandler(this.chbxViewAll_UnChecked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnViewRental = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\..\Miscellaneous\ViewRentalRequest.xaml"
            this.btnViewRental.Click += new System.Windows.RoutedEventHandler(this.btnViewRental_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.lblViewRentalRequest = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.SearchRentalDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


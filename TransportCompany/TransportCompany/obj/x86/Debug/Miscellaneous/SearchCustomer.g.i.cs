﻿#pragma checksum "..\..\..\..\Miscellaneous\SearchCustomer.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "872D1A11F720952F359E80230DAF7EE9"
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
using System.Windows.Forms;
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
    /// SearchCustomer
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class SearchCustomer : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\Miscellaneous\SearchCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid SearchCustomerForm;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Miscellaneous\SearchCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtId;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\Miscellaneous\SearchCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtFirstName;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Miscellaneous\SearchCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtLastName;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Miscellaneous\SearchCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtEmailAddress;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Miscellaneous\SearchCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSearchCustomer;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Miscellaneous\SearchCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblSearchStatus;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\Miscellaneous\SearchCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid SearchCustomerDataGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/TransportCompany;component/miscellaneous/searchcustomer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Miscellaneous\SearchCustomer.xaml"
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
            this.SearchCustomerForm = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.txtId = ((System.Windows.Controls.TextBox)(target));
            
            #line 28 "..\..\..\..\Miscellaneous\SearchCustomer.xaml"
            this.txtId.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.SearchCustomerForm_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtFirstName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtLastName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtEmailAddress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.btnSearchCustomer = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\..\Miscellaneous\SearchCustomer.xaml"
            this.btnSearchCustomer.Click += new System.Windows.RoutedEventHandler(this.btnSearchCustomer_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.lblSearchStatus = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.SearchCustomerDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 42 "..\..\..\..\Miscellaneous\SearchCustomer.xaml"
            this.SearchCustomerDataGrid.CellEditEnding += new System.EventHandler<System.Windows.Controls.DataGridCellEditEndingEventArgs>(this.SearchCustomerDataGrid_CellEditEnding);
            
            #line default
            #line hidden
            
            #line 42 "..\..\..\..\Miscellaneous\SearchCustomer.xaml"
            this.SearchCustomerDataGrid.CurrentCellChanged += new System.EventHandler<System.EventArgs>(this.SearchCustomerDataGrid_CurrentCellChanged);
            
            #line default
            #line hidden
            
            #line 42 "..\..\..\..\Miscellaneous\SearchCustomer.xaml"
            this.SearchCustomerDataGrid.BeginningEdit += new System.EventHandler<System.Windows.Controls.DataGridBeginningEditEventArgs>(this.SearchCustomerDataGrid_BeginningEdit);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "..\..\..\..\Miscellaneous\InquiryReview.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "85E7E7FA7ABF05519F83CFDB238ED43A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
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
    /// InquiryReview
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class InquiryReview : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\Miscellaneous\InquiryReview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid InquiryReviewForm;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Miscellaneous\InquiryReview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCustomerId;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Miscellaneous\InquiryReview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtInquiryDate;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Miscellaneous\InquiryReview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnViewInquiry;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Miscellaneous\InquiryReview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblViewInquiryStatus;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Miscellaneous\InquiryReview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid SearchInquiryDataGrid;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\Miscellaneous\InquiryReview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblReason;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Miscellaneous\InquiryReview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtReason;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\Miscellaneous\InquiryReview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPostFeedback;
        
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
            System.Uri resourceLocater = new System.Uri("/TransportCompany;component/miscellaneous/inquiryreview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Miscellaneous\InquiryReview.xaml"
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
            this.InquiryReviewForm = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.txtCustomerId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtInquiryDate = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btnViewInquiry = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\..\Miscellaneous\InquiryReview.xaml"
            this.btnViewInquiry.Click += new System.Windows.RoutedEventHandler(this.btnViewInquiry_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.lblViewInquiryStatus = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.SearchInquiryDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 7:
            this.lblReason = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.txtReason = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.btnPostFeedback = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\..\Miscellaneous\InquiryReview.xaml"
            this.btnPostFeedback.Click += new System.Windows.RoutedEventHandler(this.PostFeedback_click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "..\..\tablebooked.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FC99482964C2ED3FFB3640D1B38D8F5F92E5A7985C22FFB911AE82989C833C15"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.IconPacks;
using MahApps.Metro.IconPacks.Converter;
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
using loginPage;


namespace loginPage {
    
    
    /// <summary>
    /// tablebooked
    /// </summary>
    public partial class tablebooked : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 51 "..\..\tablebooked.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Tang1Btn;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\tablebooked.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Tang2Btn;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\tablebooked.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button doanhthuBtn;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\tablebooked.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button logoutBtn;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\tablebooked.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridShowTable;
        
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
            System.Uri resourceLocater = new System.Uri("/loginPage;component/tablebooked.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\tablebooked.xaml"
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
            this.Tang1Btn = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\tablebooked.xaml"
            this.Tang1Btn.Click += new System.Windows.RoutedEventHandler(this.Tang1Btn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Tang2Btn = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\tablebooked.xaml"
            this.Tang2Btn.Click += new System.Windows.RoutedEventHandler(this.Tang2Btn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.doanhthuBtn = ((System.Windows.Controls.Button)(target));
            
            #line 65 "..\..\tablebooked.xaml"
            this.doanhthuBtn.Click += new System.Windows.RoutedEventHandler(this.doanhthuBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.logoutBtn = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\tablebooked.xaml"
            this.logoutBtn.Click += new System.Windows.RoutedEventHandler(this.logoutBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.gridShowTable = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

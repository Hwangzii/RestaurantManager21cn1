﻿#pragma checksum "..\..\testpopup.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "94C91B97287C695AF8E7D82B4F09F61F2DFC222B870598FD6074FAE396748430"
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
using loginPage;


namespace loginPage {
    
    
    /// <summary>
    /// testpopup
    /// </summary>
    public partial class testpopup : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\testpopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid formthanhtoan;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\testpopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Hienthi;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\testpopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Thoigian;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\testpopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Ban;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\testpopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView foodLV;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\testpopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TongTien;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\testpopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tenktTxtBox;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\testpopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox sdtkhTxtBox;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\testpopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button huythanhtoanBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/loginPage;component/testpopup.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\testpopup.xaml"
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
            this.formthanhtoan = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.Hienthi = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.Thoigian = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.Ban = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.foodLV = ((System.Windows.Controls.ListView)(target));
            return;
            case 6:
            this.TongTien = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.tenktTxtBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.sdtkhTxtBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.huythanhtoanBtn = ((System.Windows.Controls.Button)(target));
            
            #line 118 "..\..\testpopup.xaml"
            this.huythanhtoanBtn.Click += new System.Windows.RoutedEventHandler(this.huythanhtoanBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "..\..\phieuhoadon.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "269717148C1A7C991D19F4CB40C86B3BB2ED3CEDC53BC0135E48130967D952D9"
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
    /// phieuhoadon
    /// </summary>
    public partial class phieuhoadon : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\phieuhoadon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid formthanhtoan;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\phieuhoadon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView foodLV;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\phieuhoadon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tenktTxtBox;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\phieuhoadon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox sdtkhTxtBox;
        
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
            System.Uri resourceLocater = new System.Uri("/loginPage;component/phieuhoadon.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\phieuhoadon.xaml"
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
            
            #line 21 "..\..\phieuhoadon.xaml"
            this.formthanhtoan.Loaded += new System.Windows.RoutedEventHandler(this.formthanhtoan_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.foodLV = ((System.Windows.Controls.ListView)(target));
            return;
            case 3:
            this.tenktTxtBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.sdtkhTxtBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            
            #line 85 "..\..\phieuhoadon.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


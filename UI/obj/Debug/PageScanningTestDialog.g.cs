﻿#pragma checksum "..\..\PageScanningTestDialog.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "AA4C133DDCAE390539F143BDCCE8873D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
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


namespace YellowstonePathology.UI {
    
    
    /// <summary>
    /// PageScanningTestDialog
    /// </summary>
    public partial class PageScanningTestDialog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\PageScanningTestDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton SourceFromTwainUI;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\PageScanningTestDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button selectSourceButton;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\PageScanningTestDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton SourceUserSelected;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\PageScanningTestDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ManualSource;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\PageScanningTestDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button scanButton;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\PageScanningTestDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox useTwainUICheckBox;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\PageScanningTestDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox useAdfCheckBox;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\PageScanningTestDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button saveButton;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\PageScanningTestDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image1;
        
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
            System.Uri resourceLocater = new System.Uri("/UserInterface;component/pagescanningtestdialog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PageScanningTestDialog.xaml"
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
            this.SourceFromTwainUI = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 2:
            this.selectSourceButton = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\PageScanningTestDialog.xaml"
            this.selectSourceButton.Click += new System.Windows.RoutedEventHandler(this.selectSourceButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.SourceUserSelected = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 4:
            this.ManualSource = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.scanButton = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\PageScanningTestDialog.xaml"
            this.scanButton.Click += new System.Windows.RoutedEventHandler(this.scanButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.useTwainUICheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 7:
            this.useAdfCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 8:
            this.saveButton = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\PageScanningTestDialog.xaml"
            this.saveButton.Click += new System.Windows.RoutedEventHandler(this.saveButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.image1 = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "..\..\..\Test\MLH1MethalationAnalysisResultPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5DAE52BCBB2F685850DB990C1A93C045"
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
using YellowstonePathology.UI.Test;


namespace YellowstonePathology.UI.Test {
    
    
    /// <summary>
    /// MLH1MethalationAnalysisResultPage
    /// </summary>
    public partial class MLH1MethalationAnalysisResultPage : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 123 "..\..\..\Test\MLH1MethalationAnalysisResultPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal YellowstonePathology.UI.Test.ReferenceLabFinalControl ReferenceLabFinalControl;
        
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
            System.Uri resourceLocater = new System.Uri("/UserInterface;component/test/mlh1methalationanalysisresultpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Test\MLH1MethalationAnalysisResultPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            
            #line 47 "..\..\..\Test\MLH1MethalationAnalysisResultPage.xaml"
            ((System.Windows.Documents.Hyperlink)(target)).Click += new System.Windows.RoutedEventHandler(this.HyperLinkDetected_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 50 "..\..\..\Test\MLH1MethalationAnalysisResultPage.xaml"
            ((System.Windows.Documents.Hyperlink)(target)).Click += new System.Windows.RoutedEventHandler(this.HyperLinkNotDetected_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 53 "..\..\..\Test\MLH1MethalationAnalysisResultPage.xaml"
            ((System.Windows.Documents.Hyperlink)(target)).Click += new System.Windows.RoutedEventHandler(this.HyperLinkNotSet_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 57 "..\..\..\Test\MLH1MethalationAnalysisResultPage.xaml"
            ((System.Windows.Documents.Hyperlink)(target)).Click += new System.Windows.RoutedEventHandler(this.HyperLinkAcceptResults_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 61 "..\..\..\Test\MLH1MethalationAnalysisResultPage.xaml"
            ((System.Windows.Documents.Hyperlink)(target)).Click += new System.Windows.RoutedEventHandler(this.HyperLinkShowDocument_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 65 "..\..\..\Test\MLH1MethalationAnalysisResultPage.xaml"
            ((System.Windows.Documents.Hyperlink)(target)).Click += new System.Windows.RoutedEventHandler(this.HyperLinkFinalizeResults_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 71 "..\..\..\Test\MLH1MethalationAnalysisResultPage.xaml"
            ((System.Windows.Documents.Hyperlink)(target)).Click += new System.Windows.RoutedEventHandler(this.HyperLinkUnacceptResults_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 75 "..\..\..\Test\MLH1MethalationAnalysisResultPage.xaml"
            ((System.Windows.Documents.Hyperlink)(target)).Click += new System.Windows.RoutedEventHandler(this.HyperLinkUnfinalResults_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ReferenceLabFinalControl = ((YellowstonePathology.UI.Test.ReferenceLabFinalControl)(target));
            return;
            case 10:
            
            #line 132 "..\..\..\Test\MLH1MethalationAnalysisResultPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonNext_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


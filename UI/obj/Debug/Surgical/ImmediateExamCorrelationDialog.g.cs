﻿#pragma checksum "..\..\..\Surgical\ImmediateExamCorrelationDialog.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "00F391A5257107FDE2C0D68F385EC731"
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


namespace YellowstonePathology.UI.Surgical {
    
    
    /// <summary>
    /// ImmediateExamCorrelationDialog
    /// </summary>
    public partial class ImmediateExamCorrelationDialog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 5 "..\..\..\Surgical\ImmediateExamCorrelationDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal YellowstonePathology.UI.Surgical.ImmediateExamCorrelationDialog ImmediateExamCorrelationWindow;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Surgical\ImmediateExamCorrelationDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBoxCorrelation;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\Surgical\ImmediateExamCorrelationDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBoxPatientCare;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\Surgical\ImmediateExamCorrelationDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBoxDiscrepancy;
        
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
            System.Uri resourceLocater = new System.Uri("/UserInterface;component/surgical/immediateexamcorrelationdialog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Surgical\ImmediateExamCorrelationDialog.xaml"
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
            this.ImmediateExamCorrelationWindow = ((YellowstonePathology.UI.Surgical.ImmediateExamCorrelationDialog)(target));
            return;
            case 2:
            this.ListBoxCorrelation = ((System.Windows.Controls.ListBox)(target));
            
            #line 38 "..\..\..\Surgical\ImmediateExamCorrelationDialog.xaml"
            this.ListBoxCorrelation.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListBoxCorrelation_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ListBoxPatientCare = ((System.Windows.Controls.ListBox)(target));
            return;
            case 4:
            this.ListBoxDiscrepancy = ((System.Windows.Controls.ListBox)(target));
            return;
            case 5:
            
            #line 138 "..\..\..\Surgical\ImmediateExamCorrelationDialog.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonOk_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


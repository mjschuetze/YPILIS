﻿#pragma checksum "..\..\..\..\Login\FinalizeAccession\PatientDetailsPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9F7B8AB286B024B26E5FEFD725BCBB71"
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
using YellowstonePathology.UI;
using YellowstonePathology.UI.Converter;
using YellowstonePathology.UI.CustomControls;
using YellowstonePathology.UI.ValidationRules;


namespace YellowstonePathology.UI.Login.FinalizeAccession {
    
    
    /// <summary>
    /// PatientDetailsPage
    /// </summary>
    public partial class PatientDetailsPage : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 58 "..\..\..\..\Login\FinalizeAccession\PatientDetailsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxPLastName;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\Login\FinalizeAccession\PatientDetailsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxPFirstName;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\Login\FinalizeAccession\PatientDetailsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxMiddleInitial;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\..\Login\FinalizeAccession\PatientDetailsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxSex;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\Login\FinalizeAccession\PatientDetailsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal YellowstonePathology.UI.CustomControls.ValidTextBox TextBoxBirthdate;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\..\Login\FinalizeAccession\PatientDetailsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal YellowstonePathology.UI.CustomControls.ValidTextBox TextBoxSSN;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\..\..\Login\FinalizeAccession\PatientDetailsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonBack;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\..\..\Login\FinalizeAccession\PatientDetailsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonNext;
        
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
            System.Uri resourceLocater = new System.Uri("/UserInterface;component/login/finalizeaccession/patientdetailspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Login\FinalizeAccession\PatientDetailsPage.xaml"
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
            
            #line 34 "..\..\..\..\Login\FinalizeAccession\PatientDetailsPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonCaseNotes_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TextBoxPLastName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TextBoxPFirstName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TextBoxMiddleInitial = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.ComboBoxSex = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.TextBoxBirthdate = ((YellowstonePathology.UI.CustomControls.ValidTextBox)(target));
            return;
            case 7:
            this.TextBoxSSN = ((YellowstonePathology.UI.CustomControls.ValidTextBox)(target));
            return;
            case 8:
            this.ButtonBack = ((System.Windows.Controls.Button)(target));
            
            #line 123 "..\..\..\..\Login\FinalizeAccession\PatientDetailsPage.xaml"
            this.ButtonBack.Click += new System.Windows.RoutedEventHandler(this.ButtonBack_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ButtonNext = ((System.Windows.Controls.Button)(target));
            
            #line 124 "..\..\..\..\Login\FinalizeAccession\PatientDetailsPage.xaml"
            this.ButtonNext.Click += new System.Windows.RoutedEventHandler(this.ButtonNext_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


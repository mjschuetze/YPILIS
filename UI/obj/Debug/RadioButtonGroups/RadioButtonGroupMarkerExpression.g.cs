﻿#pragma checksum "..\..\..\RadioButtonGroups\RadioButtonGroupMarkerExpression.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2EEE954C6B4EA03D066EDA4365F09EE0"
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


namespace YellowstonePathology.UI.RadioButtonGroups {
    
    
    /// <summary>
    /// RadioButtonGroupMarkerExpression
    /// </summary>
    public partial class RadioButtonGroupMarkerExpression : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 5 "..\..\..\RadioButtonGroups\RadioButtonGroupMarkerExpression.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox checkBoxMarkerSelected;
        
        #line default
        #line hidden
        
        
        #line 6 "..\..\..\RadioButtonGroups\RadioButtonGroupMarkerExpression.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton radioButtonExpresses;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\..\RadioButtonGroups\RadioButtonGroupMarkerExpression.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton radioButtonDoesNotExpress;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\..\RadioButtonGroups\RadioButtonGroupMarkerExpression.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton radioButtonEquivocal;
        
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
            System.Uri resourceLocater = new System.Uri("/UserInterface;component/radiobuttongroups/radiobuttongroupmarkerexpression.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\RadioButtonGroups\RadioButtonGroupMarkerExpression.xaml"
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
            this.checkBoxMarkerSelected = ((System.Windows.Controls.CheckBox)(target));
            
            #line 5 "..\..\..\RadioButtonGroups\RadioButtonGroupMarkerExpression.xaml"
            this.checkBoxMarkerSelected.Unchecked += new System.Windows.RoutedEventHandler(this.CheckBoxMarkerSelected_Unchecked);
            
            #line default
            #line hidden
            return;
            case 2:
            this.radioButtonExpresses = ((System.Windows.Controls.RadioButton)(target));
            
            #line 6 "..\..\..\RadioButtonGroups\RadioButtonGroupMarkerExpression.xaml"
            this.radioButtonExpresses.Click += new System.Windows.RoutedEventHandler(this.RadioButtonExpresses_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.radioButtonDoesNotExpress = ((System.Windows.Controls.RadioButton)(target));
            
            #line 7 "..\..\..\RadioButtonGroups\RadioButtonGroupMarkerExpression.xaml"
            this.radioButtonDoesNotExpress.Click += new System.Windows.RoutedEventHandler(this.RadioButtonDoesNotExpress_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.radioButtonEquivocal = ((System.Windows.Controls.RadioButton)(target));
            
            #line 8 "..\..\..\RadioButtonGroups\RadioButtonGroupMarkerExpression.xaml"
            this.radioButtonEquivocal.Click += new System.Windows.RoutedEventHandler(this.RadioButtonEquivocal_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


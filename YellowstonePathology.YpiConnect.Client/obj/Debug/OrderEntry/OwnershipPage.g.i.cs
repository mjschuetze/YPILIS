﻿#pragma checksum "..\..\..\OrderEntry\OwnershipPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6B9D2CB09E4C943F1DC3FF26E9BB1188"
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
using YellowstonePathology.YpiConnect.Client;
using YellowstonePathology.YpiConnect.Client.Converter;


namespace YellowstonePathology.YpiConnect.Client.OrderEntry {
    
    
    /// <summary>
    /// OwnershipPage
    /// </summary>
    public partial class OwnershipPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\OrderEntry\OwnershipPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal YellowstonePathology.YpiConnect.Client.OrderEntry.OwnershipPage OrderEntryControl;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\OrderEntry\OwnershipPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MainGrid;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\OrderEntry\OwnershipPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ContentGrid;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\OrderEntry\OwnershipPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid StepsGrid;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\OrderEntry\OwnershipPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockInstructions;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\OrderEntry\OwnershipPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridPageContent;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\OrderEntry\OwnershipPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonTakeOwnership;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\OrderEntry\OwnershipPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonFinish;
        
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
            System.Uri resourceLocater = new System.Uri("/YellowstonePathology.YpiConnect.Client;component/orderentry/ownershippage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\OrderEntry\OwnershipPage.xaml"
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
            this.OrderEntryControl = ((YellowstonePathology.YpiConnect.Client.OrderEntry.OwnershipPage)(target));
            return;
            case 2:
            this.MainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.ContentGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.StepsGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.TextBlockInstructions = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.GridPageContent = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.ButtonTakeOwnership = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\..\OrderEntry\OwnershipPage.xaml"
            this.ButtonTakeOwnership.Click += new System.Windows.RoutedEventHandler(this.ButtonTakeOwnerShip_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 84 "..\..\..\OrderEntry\OwnershipPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonBack_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ButtonFinish = ((System.Windows.Controls.Button)(target));
            
            #line 86 "..\..\..\OrderEntry\OwnershipPage.xaml"
            this.ButtonFinish.Click += new System.Windows.RoutedEventHandler(this.ButtonFinish_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


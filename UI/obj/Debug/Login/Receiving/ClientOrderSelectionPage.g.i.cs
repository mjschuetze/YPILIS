﻿#pragma checksum "..\..\..\..\Login\Receiving\ClientOrderSelectionPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3F3EBBDB7DBD98E031EBF28BC1D02337"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
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


namespace YellowstonePathology.UI.Login.Receiving {
    
    
    /// <summary>
    /// ClientOrderSelectionPage
    /// </summary>
    public partial class ClientOrderSelectionPage : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\Login\Receiving\ClientOrderSelectionPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ContentGrid;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Login\Receiving\ClientOrderSelectionPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListViewClientOrders;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Login\Receiving\ClientOrderSelectionPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonBack;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\Login\Receiving\ClientOrderSelectionPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonViewClientOrder;
        
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
            System.Uri resourceLocater = new System.Uri("/UserInterface;component/login/receiving/clientorderselectionpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Login\Receiving\ClientOrderSelectionPage.xaml"
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
            this.ContentGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.ListViewClientOrders = ((System.Windows.Controls.ListView)(target));
            
            #line 30 "..\..\..\..\Login\Receiving\ClientOrderSelectionPage.xaml"
            this.ListViewClientOrders.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ListViewClientOrders_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ButtonBack = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\..\Login\Receiving\ClientOrderSelectionPage.xaml"
            this.ButtonBack.Click += new System.Windows.RoutedEventHandler(this.ButtonBack_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ButtonViewClientOrder = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\..\Login\Receiving\ClientOrderSelectionPage.xaml"
            this.ButtonViewClientOrder.Click += new System.Windows.RoutedEventHandler(this.ButtonViewClientOrder_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


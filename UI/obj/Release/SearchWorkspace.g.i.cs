﻿#pragma checksum "..\..\SearchWorkspace.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B6139D23FD7AC9BFB059371517B401C2"
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


namespace YellowstonePathology.UI {
    
    
    /// <summary>
    /// SearchWorkspace
    /// </summary>
    public partial class SearchWorkspace : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\SearchWorkspace.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxSearchCriteria;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\SearchWorkspace.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxSort;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\SearchWorkspace.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listViewCaseList;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\SearchWorkspace.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listViewResultList;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\SearchWorkspace.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listViewDocumentList;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\SearchWorkspace.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem TabItemPatientHistory;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\SearchWorkspace.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listViewPatientHistory;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\SearchWorkspace.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listViewPatientHistoryCaseFileList;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\SearchWorkspace.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem TabItemDocumentViewer;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\SearchWorkspace.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem TabItemPhysicianSearch;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\SearchWorkspace.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxPhysicianLastName;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\SearchWorkspace.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listViewPhysicianClient;
        
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
            System.Uri resourceLocater = new System.Uri("/UserInterface;component/searchworkspace.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SearchWorkspace.xaml"
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
            this.textBoxSearchCriteria = ((System.Windows.Controls.TextBox)(target));
            
            #line 20 "..\..\SearchWorkspace.xaml"
            this.textBoxSearchCriteria.KeyUp += new System.Windows.Input.KeyEventHandler(this.TextBoxSearchCriteria_KeyUp);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ComboBoxSort = ((System.Windows.Controls.ComboBox)(target));
            
            #line 22 "..\..\SearchWorkspace.xaml"
            this.ComboBoxSort.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBoxSort_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.listViewCaseList = ((System.Windows.Controls.ListView)(target));
            
            #line 41 "..\..\SearchWorkspace.xaml"
            this.listViewCaseList.PreviewMouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.ListViewCaseList_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 44 "..\..\SearchWorkspace.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ContextMenuShowPatientHistoryDialog_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 45 "..\..\SearchWorkspace.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItemFlipToLabWorkspace_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 46 "..\..\SearchWorkspace.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItemFlipToFlowWorkspace_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.listViewResultList = ((System.Windows.Controls.ListView)(target));
            return;
            case 8:
            this.listViewDocumentList = ((System.Windows.Controls.ListView)(target));
            
            #line 69 "..\..\SearchWorkspace.xaml"
            this.listViewDocumentList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListViewDocumentList_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.TabItemPatientHistory = ((System.Windows.Controls.TabItem)(target));
            return;
            case 10:
            this.listViewPatientHistory = ((System.Windows.Controls.ListView)(target));
            
            #line 90 "..\..\SearchWorkspace.xaml"
            this.listViewPatientHistory.PreviewMouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.ListViewPatientHistoryCaseList_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 93 "..\..\SearchWorkspace.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ContextMenuGetPatientHistory_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.listViewPatientHistoryCaseFileList = ((System.Windows.Controls.ListView)(target));
            
            #line 103 "..\..\SearchWorkspace.xaml"
            this.listViewPatientHistoryCaseFileList.PreviewMouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.ListViewPatientHistoryViewDocument_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 13:
            this.TabItemDocumentViewer = ((System.Windows.Controls.TabItem)(target));
            return;
            case 14:
            this.TabItemPhysicianSearch = ((System.Windows.Controls.TabItem)(target));
            return;
            case 15:
            this.TextBoxPhysicianLastName = ((System.Windows.Controls.TextBox)(target));
            
            #line 128 "..\..\SearchWorkspace.xaml"
            this.TextBoxPhysicianLastName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBoxPhysicianLastName_TextChanged);
            
            #line default
            #line hidden
            return;
            case 16:
            this.listViewPhysicianClient = ((System.Windows.Controls.ListView)(target));
            
            #line 131 "..\..\SearchWorkspace.xaml"
            this.listViewPhysicianClient.PreviewMouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.ListViewPhysicianClient_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


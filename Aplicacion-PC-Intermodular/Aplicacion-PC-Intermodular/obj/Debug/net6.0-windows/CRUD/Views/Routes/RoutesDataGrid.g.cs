﻿#pragma checksum "..\..\..\..\..\..\CRUD\Views\Routes\RoutesDataGrid.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "67798A73FA96DDCFDEA16648B84F9751E5B62178"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Aplicacion_PC_Intermodular.CRUD.Views.Routes;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Aplicacion_PC_Intermodular.CRUD.Views.Routes {
    
    
    /// <summary>
    /// RoutesDataGrid
    /// </summary>
    public partial class RoutesDataGrid : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 31 "..\..\..\..\..\..\CRUD\Views\Routes\RoutesDataGrid.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridRoutes;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\..\..\CRUD\Views\Routes\RoutesDataGrid.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addRouteBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Aplicacion-PC-Intermodular;component/crud/views/routes/routesdatagrid.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\CRUD\Views\Routes\RoutesDataGrid.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.dataGridRoutes = ((System.Windows.Controls.DataGrid)(target));
            
            #line 31 "..\..\..\..\..\..\CRUD\Views\Routes\RoutesDataGrid.xaml"
            this.dataGridRoutes.AutoGeneratingColumn += new System.EventHandler<System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs>(this.dataGridRoutes_AutoGeneratingColumn);
            
            #line default
            #line hidden
            return;
            case 6:
            this.addRouteBtn = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\..\..\..\CRUD\Views\Routes\RoutesDataGrid.xaml"
            this.addRouteBtn.Click += new System.Windows.RoutedEventHandler(this.addRouteBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 2:
            
            #line 37 "..\..\..\..\..\..\CRUD\Views\Routes\RoutesDataGrid.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.viewRoute_btn_Click);
            
            #line default
            #line hidden
            break;
            case 3:
            
            #line 40 "..\..\..\..\..\..\CRUD\Views\Routes\RoutesDataGrid.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.addComment_button_Click);
            
            #line default
            #line hidden
            break;
            case 4:
            
            #line 43 "..\..\..\..\..\..\CRUD\Views\Routes\RoutesDataGrid.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.modify_btn_Click);
            
            #line default
            #line hidden
            break;
            case 5:
            
            #line 46 "..\..\..\..\..\..\CRUD\Views\Routes\RoutesDataGrid.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.remove_btn_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}


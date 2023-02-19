﻿#pragma checksum "..\..\..\..\..\CRUD\Views\CRUDView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "90993CB6FC8F723AEB8DB032ED07225C2981901E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Aplicacion_PC_Intermodular.CRUD;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace Aplicacion_PC_Intermodular.CRUD {
    
    
    /// <summary>
    /// CRUDView
    /// </summary>
    public partial class CRUDView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 55 "..\..\..\..\..\CRUD\Views\CRUDView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button usersBtn;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\..\CRUD\Views\CRUDView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button routesBtn;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\..\CRUD\Views\CRUDView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button commentsBtn;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\..\CRUD\Views\CRUDView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button logOutButton;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\..\..\CRUD\Views\CRUDView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button minimize_button;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\..\..\CRUD\Views\CRUDView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button close_button;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\..\..\CRUD\Views\CRUDView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame mainContent;
        
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
            System.Uri resourceLocater = new System.Uri("/Aplicacion-PC-Intermodular;component/crud/views/crudview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\CRUD\Views\CRUDView.xaml"
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
            
            #line 14 "..\..\..\..\..\CRUD\Views\CRUDView.xaml"
            ((Aplicacion_PC_Intermodular.CRUD.CRUDView)(target)).StateChanged += new System.EventHandler(this.CRUDWindow_StateChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 36 "..\..\..\..\..\CRUD\Views\CRUDView.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.usersBtn = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\..\..\CRUD\Views\CRUDView.xaml"
            this.usersBtn.Click += new System.Windows.RoutedEventHandler(this.usersBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.routesBtn = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\..\..\..\CRUD\Views\CRUDView.xaml"
            this.routesBtn.Click += new System.Windows.RoutedEventHandler(this.routesBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.commentsBtn = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\..\..\..\CRUD\Views\CRUDView.xaml"
            this.commentsBtn.Click += new System.Windows.RoutedEventHandler(this.commentsBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.logOutButton = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\..\..\..\CRUD\Views\CRUDView.xaml"
            this.logOutButton.Click += new System.Windows.RoutedEventHandler(this.logOutButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.minimize_button = ((System.Windows.Controls.Button)(target));
            
            #line 92 "..\..\..\..\..\CRUD\Views\CRUDView.xaml"
            this.minimize_button.Click += new System.Windows.RoutedEventHandler(this.minimize_button_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.close_button = ((System.Windows.Controls.Button)(target));
            
            #line 102 "..\..\..\..\..\CRUD\Views\CRUDView.xaml"
            this.close_button.Click += new System.Windows.RoutedEventHandler(this.close_button_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.mainContent = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


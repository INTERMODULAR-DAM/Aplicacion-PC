// Updated by XamlIntelliSenseFileGenerator 16/02/2023 13:02:53
#pragma checksum "..\..\..\..\..\..\CRUD\Views\Routes\ViewRouteWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "41896FA8D1F09DF52701320096B36EAB773A54E3"
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


namespace Aplicacion_PC_Intermodular.CRUD.Views.Routes
{


    /// <summary>
    /// ViewRouteWindow
    /// </summary>
    public partial class ViewRouteWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 21 "..\..\..\..\..\..\CRUD\Views\Routes\ViewRouteWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tb_title;

#line default
#line hidden


#line 23 "..\..\..\..\..\..\CRUD\Views\Routes\ViewRouteWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button nextPhotobtn;

#line default
#line hidden


#line 37 "..\..\..\..\..\..\CRUD\Views\Routes\ViewRouteWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button close_button;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Aplicacion-PC-Intermodular;component/crud/views/routes/viewroutewindow.xaml", System.UriKind.Relative);

#line 1 "..\..\..\..\..\..\CRUD\Views\Routes\ViewRouteWindow.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:

#line 13 "..\..\..\..\..\..\CRUD\Views\Routes\ViewRouteWindow.xaml"
                    ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseDown);

#line default
#line hidden
                    return;
                case 2:
                    this.tb_title = ((System.Windows.Controls.TextBlock)(target));
                    return;
                case 3:
                    this.nextPhotobtn = ((System.Windows.Controls.Button)(target));

#line 23 "..\..\..\..\..\..\CRUD\Views\Routes\ViewRouteWindow.xaml"
                    this.nextPhotobtn.Click += new System.Windows.RoutedEventHandler(this.nextPhotobtn_Click);

#line default
#line hidden
                    return;
                case 4:
                    this.minimize_button = ((System.Windows.Controls.Button)(target));

#line 32 "..\..\..\..\..\..\CRUD\Views\Routes\ViewRouteWindow.xaml"
                    this.minimize_button.Click += new System.Windows.RoutedEventHandler(this.minimize_button_Click);

#line default
#line hidden
                    return;
                case 5:
                    this.close_button = ((System.Windows.Controls.Button)(target));

#line 42 "..\..\..\..\..\..\CRUD\Views\Routes\ViewRouteWindow.xaml"
                    this.close_button.Click += new System.Windows.RoutedEventHandler(this.close_button_Click);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }
    }
}


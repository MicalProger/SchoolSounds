﻿#pragma checksum "..\..\..\Pages\DefaultLessonsView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B5B39695E33593BAFECDF39021B58DF472BD756F9B55B56E715BA1EE8EC7447F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using SSSApp;
using SSSApp.Pages;
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


namespace SSSApp.Pages {
    
    
    /// <summary>
    /// DefaultLessonsView
    /// </summary>
    public partial class DefaultLessonsView : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\Pages\DefaultLessonsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel WBCollector;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Pages\DefaultLessonsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox LsLB;
        
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
            System.Uri resourceLocater = new System.Uri("/SSSApp;component/pages/defaultlessonsview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\DefaultLessonsView.xaml"
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
            
            #line 20 "..\..\..\Pages\DefaultLessonsView.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Click += new System.Windows.RoutedEventHandler(this.ResetMuteMode);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 21 "..\..\..\Pages\DefaultLessonsView.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Click += new System.Windows.RoutedEventHandler(this.ResetMuteMode);
            
            #line default
            #line hidden
            return;
            case 3:
            this.WBCollector = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 4:
            
            #line 23 "..\..\..\Pages\DefaultLessonsView.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Click += new System.Windows.RoutedEventHandler(this.UpdateDayMute);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 24 "..\..\..\Pages\DefaultLessonsView.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Click += new System.Windows.RoutedEventHandler(this.UpdateDayMute);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 25 "..\..\..\Pages\DefaultLessonsView.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Click += new System.Windows.RoutedEventHandler(this.UpdateDayMute);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 26 "..\..\..\Pages\DefaultLessonsView.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Click += new System.Windows.RoutedEventHandler(this.UpdateDayMute);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 27 "..\..\..\Pages\DefaultLessonsView.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Click += new System.Windows.RoutedEventHandler(this.UpdateDayMute);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 28 "..\..\..\Pages\DefaultLessonsView.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Click += new System.Windows.RoutedEventHandler(this.UpdateDayMute);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 29 "..\..\..\Pages\DefaultLessonsView.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Click += new System.Windows.RoutedEventHandler(this.UpdateDayMute);
            
            #line default
            #line hidden
            return;
            case 11:
            this.LsLB = ((System.Windows.Controls.ListBox)(target));
            return;
            case 12:
            
            #line 55 "..\..\..\Pages\DefaultLessonsView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.LsAdd);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 56 "..\..\..\Pages\DefaultLessonsView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.LsRemove);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "..\..\ReplishBalance.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DA7380D8657AF6966F8C242D450548A6E76D4684"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using RentalService;
using Scar.Common.WPF.Controls;
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


namespace RentalService {
    
    
    /// <summary>
    /// ReplishBalance
    /// </summary>
    public partial class ReplishBalance : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\ReplishBalance.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Transitions.TransitioningContent TrainsitionigContentSlide;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\ReplishBalance.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox card_CVV2_CVC2;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\ReplishBalance.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox card_num;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\ReplishBalance.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox card_MM;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\ReplishBalance.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox card_YY;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\ReplishBalance.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Scar.Common.WPF.Controls.NumericUpDown numeric_ammount;
        
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
            System.Uri resourceLocater = new System.Uri("/RentalService;component/replishbalance.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ReplishBalance.xaml"
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
            this.TrainsitionigContentSlide = ((MaterialDesignThemes.Wpf.Transitions.TransitioningContent)(target));
            return;
            case 2:
            this.card_CVV2_CVC2 = ((System.Windows.Controls.TextBox)(target));
            
            #line 26 "..\..\ReplishBalance.xaml"
            this.card_CVV2_CVC2.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Num_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.card_num = ((System.Windows.Controls.TextBox)(target));
            
            #line 31 "..\..\ReplishBalance.xaml"
            this.card_num.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Num_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.card_MM = ((System.Windows.Controls.TextBox)(target));
            
            #line 32 "..\..\ReplishBalance.xaml"
            this.card_MM.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Num_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 5:
            this.card_YY = ((System.Windows.Controls.TextBox)(target));
            
            #line 33 "..\..\ReplishBalance.xaml"
            this.card_YY.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Num_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 6:
            this.numeric_ammount = ((Scar.Common.WPF.Controls.NumericUpDown)(target));
            return;
            case 7:
            
            #line 40 "..\..\ReplishBalance.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ReplishBalance_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 41 "..\..\ReplishBalance.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CancelButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


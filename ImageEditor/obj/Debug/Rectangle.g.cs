#pragma checksum "..\..\Rectangle.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2E0A281FAB6AB36AD161BE1A0537694AD5CC75F9664D8FD5CCF07D9E2ACD9298"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ImageEditor;
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


namespace ImageEditor {
    
    
    /// <summary>
    /// Rectangle
    /// </summary>
    public partial class Rectangle : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\Rectangle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\Rectangle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox color;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\Rectangle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox color1;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Rectangle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox height;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Rectangle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox width;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Rectangle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox py;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Rectangle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox px;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Rectangle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox color1_Copy;
        
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
            System.Uri resourceLocater = new System.Uri("/ImageEditor;component/rectangle.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Rectangle.xaml"
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
            this.grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.color = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.color1 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.height = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.width = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.py = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.px = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 22 "..\..\Rectangle.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnok);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 23 "..\..\Rectangle.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btncancel);
            
            #line default
            #line hidden
            return;
            case 10:
            this.color1_Copy = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


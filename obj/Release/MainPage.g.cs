﻿

#pragma checksum "C:\Users\userpc\documents\visual studio 2013\Projects\ScreenIT Lite\ScreenIT Lite\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DAD1245ED0F4AF78CF4C664976A8F27D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ScreenIT_Lite
{
    partial class MainPage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 14 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btnRecord_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 15 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Clear_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 28 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).PointerPressed += this.Pressed;
                 #line default
                 #line hidden
                #line 28 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).PointerReleased += this.Released;
                 #line default
                 #line hidden
                #line 28 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).PointerMoved += this.Moved;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}



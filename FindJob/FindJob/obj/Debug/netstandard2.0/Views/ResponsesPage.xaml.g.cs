//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("FindJob.Views.ResponsesPage.xaml", "Views/ResponsesPage.xaml", typeof(global::FindJob.Views.ResponsesPage))]

namespace FindJob.Views {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("Views/ResponsesPage.xaml")]
    public partial class ResponsesPage : global::Xamarin.Forms.ContentPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.RefreshView Refresh;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.ActivityIndicator downloadIndicator;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(ResponsesPage));
            Refresh = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.RefreshView>(this, "Refresh");
            downloadIndicator = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.ActivityIndicator>(this, "downloadIndicator");
        }
    }
}

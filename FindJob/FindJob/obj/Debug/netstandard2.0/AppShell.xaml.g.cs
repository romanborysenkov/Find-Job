//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("FindJob.AppShell.xaml", "AppShell.xaml", typeof(global::FindJob.AppShell))]

namespace FindJob {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("AppShell.xaml")]
    public partial class AppShell : global::Xamarin.Forms.Shell {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Label header;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.FlyoutItem resume;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.FlyoutItem responses;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.FlyoutItem login;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.MenuItem logout;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(AppShell));
            header = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Label>(this, "header");
            resume = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.FlyoutItem>(this, "resume");
            responses = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.FlyoutItem>(this, "responses");
            login = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.FlyoutItem>(this, "login");
            logout = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.MenuItem>(this, "logout");
        }
    }
}
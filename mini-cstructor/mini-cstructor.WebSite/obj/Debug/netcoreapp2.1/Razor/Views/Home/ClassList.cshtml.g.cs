#pragma checksum "C:\Users\G\src\csharp\mini-cstructor\mini-cstructor.WebSite\Views\Home\ClassList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "db704729589eb04df0ae5d27ad10bd9bf5b5ba6e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ClassList), @"mvc.1.0.view", @"/Views/Home/ClassList.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/ClassList.cshtml", typeof(AspNetCore.Views_Home_ClassList))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\G\src\csharp\mini-cstructor\mini-cstructor.WebSite\Views\_ViewImports.cshtml"
using mini_cstructor.WebSite;

#line default
#line hidden
#line 2 "C:\Users\G\src\csharp\mini-cstructor\mini-cstructor.WebSite\Views\_ViewImports.cshtml"
using mini_cstructor.WebSite.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db704729589eb04df0ae5d27ad10bd9bf5b5ba6e", @"/Views/Home/ClassList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eac4543261c8140ec0a1d1ce9805258acb1a8a49", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ClassList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<mini_cstructor.WebSite.Models.ClassesModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\G\src\csharp\mini-cstructor\mini-cstructor.WebSite\Views\Home\ClassList.cshtml"
  
    ViewData["Title"] = "Class List";

#line default
#line hidden
            BeginContext(97, 240, true);
            WriteLiteral("\r\n<h2>Classes</h2>\r\n<hr />\r\n\r\n<div class=\"row\">\r\n    <div class=\"text-weight-bold col-md-4\">Name</div>\r\n    <div class=\"text-weight-bold col-md-4\">Description</div>\r\n    <div class=\"text-weight-bold col-md-4\">Price</div>\r\n</div>\r\n<hr />\r\n\r\n");
            EndContext();
#line 16 "C:\Users\G\src\csharp\mini-cstructor\mini-cstructor.WebSite\Views\Home\ClassList.cshtml"
 foreach (var classModel in Model.Classes)
{

#line default
#line hidden
            BeginContext(384, 67, true);
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-md-4\">\r\n            ");
            EndContext();
            BeginContext(452, 20, false);
#line 20 "C:\Users\G\src\csharp\mini-cstructor\mini-cstructor.WebSite\Views\Home\ClassList.cshtml"
       Write(classModel.ClassName);

#line default
#line hidden
            EndContext();
            BeginContext(472, 62, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-4\">\r\n            ");
            EndContext();
            BeginContext(535, 27, false);
#line 23 "C:\Users\G\src\csharp\mini-cstructor\mini-cstructor.WebSite\Views\Home\ClassList.cshtml"
       Write(classModel.ClassDescription);

#line default
#line hidden
            EndContext();
            BeginContext(562, 62, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-4\">\r\n            ");
            EndContext();
            BeginContext(625, 38, false);
#line 26 "C:\Users\G\src\csharp\mini-cstructor\mini-cstructor.WebSite\Views\Home\ClassList.cshtml"
       Write(classModel.ClassPrice.ToString("#.##"));

#line default
#line hidden
            EndContext();
            BeginContext(663, 30, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
            EndContext();
            BeginContext(695, 12, true);
            WriteLiteral("    <hr />\r\n");
            EndContext();
#line 31 "C:\Users\G\src\csharp\mini-cstructor\mini-cstructor.WebSite\Views\Home\ClassList.cshtml"

}

#line default
#line hidden
            BeginContext(712, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<mini_cstructor.WebSite.Models.ClassesModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
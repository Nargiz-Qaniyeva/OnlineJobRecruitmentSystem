#pragma checksum "C:\Users\nargi\Desktop\Jobbply- Final Project\Jobbply- Final Project\Views\TopCategory\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b6b466bd7012836cb59cc394aac83c2d6073992e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TopCategory_Detail), @"mvc.1.0.view", @"/Views/TopCategory/Detail.cshtml")]
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
#nullable restore
#line 1 "C:\Users\nargi\Desktop\Jobbply- Final Project\Jobbply- Final Project\Views\_ViewImports.cshtml"
using Jobbply__Final_Project.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\nargi\Desktop\Jobbply- Final Project\Jobbply- Final Project\Views\_ViewImports.cshtml"
using Jobbply__Final_Project.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6b466bd7012836cb59cc394aac83c2d6073992e", @"/Views/TopCategory/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b880dbdf7d60f0f3d935e800be6e7f59cae8367", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_TopCategory_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<JobInfo>
    #nullable disable
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\nargi\Desktop\Jobbply- Final Project\Jobbply- Final Project\Views\TopCategory\Detail.cshtml"
  
    ViewData["Title"] = "Detail";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container pt-xl-5\">\r\n    <div class=\"py-lg-4 pt-lg-5\">\r\n    <div class=\"row pt-lg-5\">\r\n        <div class=\"col pt-lg-5\">\r\n\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b6b466bd7012836cb59cc394aac83c2d6073992e3678", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 259, "~/assets/image/category/", 259, 24, true);
#nullable restore
#line 11 "C:\Users\nargi\Desktop\Jobbply- Final Project\Jobbply- Final Project\Views\TopCategory\Detail.cshtml"
AddHtmlAttributeValue("", 283, Model.Image, 283, 12, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        <h2>");
#nullable restore
#line 12 "C:\Users\nargi\Desktop\Jobbply- Final Project\Jobbply- Final Project\Views\TopCategory\Detail.cshtml"
       Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n        <p>");
#nullable restore
#line 13 "C:\Users\nargi\Desktop\Jobbply- Final Project\Jobbply- Final Project\Views\TopCategory\Detail.cshtml"
      Write(Model.Desc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n    </div>\r\n    </div>\r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<JobInfo> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
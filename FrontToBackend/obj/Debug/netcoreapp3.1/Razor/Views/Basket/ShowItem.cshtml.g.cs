#pragma checksum "C:\Users\Clean__Laptop\Desktop\myProjectAps.net\FrontToBackend\FrontToBackend\Views\Basket\ShowItem.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5e598cf22c2e0ed334c0c1ca565e5abbb4f4dc07"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Basket_ShowItem), @"mvc.1.0.view", @"/Views/Basket/ShowItem.cshtml")]
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
#line 1 "C:\Users\Clean__Laptop\Desktop\myProjectAps.net\FrontToBackend\FrontToBackend\Views\_ViewImports.cshtml"
using FrontToBackend.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Clean__Laptop\Desktop\myProjectAps.net\FrontToBackend\FrontToBackend\Views\_ViewImports.cshtml"
using FrontToBackend.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e598cf22c2e0ed334c0c1ca565e5abbb4f4dc07", @"/Views/Basket/ShowItem.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64191b5ec8f6237e517ae7f58f0b9da4dc668aba", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Basket_ShowItem : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<BasketVM>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("80"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Clean__Laptop\Desktop\myProjectAps.net\FrontToBackend\FrontToBackend\Views\Basket\ShowItem.cshtml"
  
    ViewData["Title"] = "ShowItem";
    Layout = "~/Views/Shared/_Layout.cshtml";
      int count = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"



<div class=""container"">
    <div class=""row"">
        <table class=""table"">
  <thead>
    <tr>
      <th scope=""col"">No</th>
      <th scope=""col"">IMAGE</th>
      <th scope=""col"">NAME</th>
      <th scope=""col"">Price</th>
       <th scope=""col"">Quantity</th>
    </tr>
  </thead>
  <tbody>

");
#nullable restore
#line 26 "C:\Users\Clean__Laptop\Desktop\myProjectAps.net\FrontToBackend\FrontToBackend\Views\Basket\ShowItem.cshtml"
 foreach (var item in Model)
{
         count++;

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n      <th scope=\"row\">");
#nullable restore
#line 30 "C:\Users\Clean__Laptop\Desktop\myProjectAps.net\FrontToBackend\FrontToBackend\Views\Basket\ShowItem.cshtml"
                 Write(count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n      <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5e598cf22c2e0ed334c0c1ca565e5abbb4f4dc074838", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 585, "~/img/", 585, 6, true);
#nullable restore
#line 31 "C:\Users\Clean__Laptop\Desktop\myProjectAps.net\FrontToBackend\FrontToBackend\Views\Basket\ShowItem.cshtml"
AddHtmlAttributeValue("", 591, item.imgUrl, 591, 12, false);

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
            WriteLiteral("</td>\r\n      <td>");
#nullable restore
#line 32 "C:\Users\Clean__Laptop\Desktop\myProjectAps.net\FrontToBackend\FrontToBackend\Views\Basket\ShowItem.cshtml"
     Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n      <td>");
#nullable restore
#line 33 "C:\Users\Clean__Laptop\Desktop\myProjectAps.net\FrontToBackend\FrontToBackend\Views\Basket\ShowItem.cshtml"
     Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n     \r\n      <td  > \r\n          <span data-id=\"");
#nullable restore
#line 36 "C:\Users\Clean__Laptop\Desktop\myProjectAps.net\FrontToBackend\FrontToBackend\Views\Basket\ShowItem.cshtml"
                    Write(item.id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"minusBtn\" style=\"cursor:pointer; padding:2px 5px; border-radius:10px; background:red ; margin-right:10px;\">-</span>\r\n        <span data-id=\"");
#nullable restore
#line 37 "C:\Users\Clean__Laptop\Desktop\myProjectAps.net\FrontToBackend\FrontToBackend\Views\Basket\ShowItem.cshtml"
                  Write(item.id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"productCount\"> ");
#nullable restore
#line 37 "C:\Users\Clean__Laptop\Desktop\myProjectAps.net\FrontToBackend\FrontToBackend\Views\Basket\ShowItem.cshtml"
                                                  Write(item.ProductCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span> \r\n      <span data-id=\"");
#nullable restore
#line 38 "C:\Users\Clean__Laptop\Desktop\myProjectAps.net\FrontToBackend\FrontToBackend\Views\Basket\ShowItem.cshtml"
                Write(item.id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"plusBtn\" style=\"cursor:pointer; padding:2px 5px; border-radius:10px; background:red ; margin-left:10px;\" >+</span>\r\n      </td>\r\n      <td data-id=\"");
#nullable restore
#line 40 "C:\Users\Clean__Laptop\Desktop\myProjectAps.net\FrontToBackend\FrontToBackend\Views\Basket\ShowItem.cshtml"
              Write(item.id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"closeTd\" style=\"cursor:pointer\">X</td>\r\n    </tr>\r\n");
#nullable restore
#line 42 "C:\Users\Clean__Laptop\Desktop\myProjectAps.net\FrontToBackend\FrontToBackend\Views\Basket\ShowItem.cshtml"

}

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n  \r\n  </tbody>\r\n</table>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<BasketVM>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

#pragma checksum "C:\projetos\SnackHouse\SnackHouse\SnackHouse\Areas\Admin\Views\AdminOrders\OrderSnack.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1cf31baeb75f53821916372d21f0c7e0f31fb17e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_AdminOrders_OrderSnack), @"mvc.1.0.view", @"/Areas/Admin/Views/AdminOrders/OrderSnack.cshtml")]
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
#line 1 "C:\projetos\SnackHouse\SnackHouse\SnackHouse\Areas\Admin\Views\_ViewImports.cshtml"
using SnackHouse;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\projetos\SnackHouse\SnackHouse\SnackHouse\Areas\Admin\Views\_ViewImports.cshtml"
using SnackHouse.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\projetos\SnackHouse\SnackHouse\SnackHouse\Areas\Admin\Views\_ViewImports.cshtml"
using SnackHouse.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\projetos\SnackHouse\SnackHouse\SnackHouse\Areas\Admin\Views\_ViewImports.cshtml"
using ReflectionIT.Mvc.Paging;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1cf31baeb75f53821916372d21f0c7e0f31fb17e", @"/Areas/Admin/Views/AdminOrders/OrderSnack.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc2a528a44c08240572a0c232f36ae76124c5f93", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_AdminOrders_OrderSnack : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OrderSnackViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\projetos\SnackHouse\SnackHouse\SnackHouse\Areas\Admin\Views\AdminOrders\OrderSnack.cshtml"
   
    ViewData["Title"] = "Detalhes do pedido";
    decimal totalOrders = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Lanches do pedido</h1>\r\n<hr />\r\n<h3>Pedido :  ");
#nullable restore
#line 10 "C:\projetos\SnackHouse\SnackHouse\SnackHouse\Areas\Admin\Views\AdminOrders\OrderSnack.cshtml"
         Write(Html.DisplayFor(model => model.Order.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n<h3>Cliente : ");
#nullable restore
#line 11 "C:\projetos\SnackHouse\SnackHouse\SnackHouse\Areas\Admin\Views\AdminOrders\OrderSnack.cshtml"
         Write(Html.DisplayFor(model => model.Order.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n<h3>Data : ");
#nullable restore
#line 12 "C:\projetos\SnackHouse\SnackHouse\SnackHouse\Areas\Admin\Views\AdminOrders\OrderSnack.cshtml"
      Write(Html.DisplayFor(model => model.Order.SendDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n<h3>Entrega : ");
#nullable restore
#line 13 "C:\projetos\SnackHouse\SnackHouse\SnackHouse\Areas\Admin\Views\AdminOrders\OrderSnack.cshtml"
         Write(Html.DisplayFor(model => model.Order.DeliveryDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n<table class=\"table\">\r\n");
#nullable restore
#line 16 "C:\projetos\SnackHouse\SnackHouse\SnackHouse\Areas\Admin\Views\AdminOrders\OrderSnack.cshtml"
     foreach (var item in Model.Order.OrderDetails)
    {
        totalOrders += (item.Snack.Price * item.Quantity);


#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td align=\"right\">\r\n                <h3>");
#nullable restore
#line 22 "C:\projetos\SnackHouse\SnackHouse\SnackHouse\Areas\Admin\Views\AdminOrders\OrderSnack.cshtml"
               Write(Html.DisplayFor(modelItem => item.Snack.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n            </td>\r\n            <td align=\"right\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1cf31baeb75f53821916372d21f0c7e0f31fb17e7728", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 759, "~/img/snacks/", 759, 13, true);
#nullable restore
#line 25 "C:\projetos\SnackHouse\SnackHouse\SnackHouse\Areas\Admin\Views\AdminOrders\OrderSnack.cshtml"
AddHtmlAttributeValue("", 772, item.Snack.ImgUrl, 772, 18, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </td>\r\n            <td align=\"right\">\r\n                <h3>");
#nullable restore
#line 28 "C:\projetos\SnackHouse\SnackHouse\SnackHouse\Areas\Admin\Views\AdminOrders\OrderSnack.cshtml"
               Write(string.Format("{0:C}", item.Snack.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n            </td>\r\n            <td align=\"right\">\r\n                <h3>(");
#nullable restore
#line 31 "C:\projetos\SnackHouse\SnackHouse\SnackHouse\Areas\Admin\Views\AdminOrders\OrderSnack.cshtml"
                Write(Html.DisplayFor(modelItem => item.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral(")</h3>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 34 "C:\projetos\SnackHouse\SnackHouse\SnackHouse\Areas\Admin\Views\AdminOrders\OrderSnack.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr>\r\n        <td colspan=\"2\">&nbsp;</td>\r\n        <td align=\"right\">\r\n            <h3>Total do pedido : ");
#nullable restore
#line 38 "C:\projetos\SnackHouse\SnackHouse\SnackHouse\Areas\Admin\Views\AdminOrders\OrderSnack.cshtml"
                             Write(string.Format("{0:C}", Model.Order.TotalOrder));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n        </td>\r\n    </tr>\r\n</table>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1cf31baeb75f53821916372d21f0c7e0f31fb17e10905", async() => {
                WriteLiteral("Retornar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OrderSnackViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

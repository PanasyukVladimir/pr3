#pragma checksum "C:\Users\Вова\Desktop\PR3\Store\Store\Views\Search\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b51499f37739defd26ef84cbba7df961408d8a1a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Search_Index), @"mvc.1.0.view", @"/Views/Search/Index.cshtml")]
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
#line 1 "C:\Users\Вова\Desktop\PR3\Store\Store\Views\_ViewImports.cshtml"
using Store.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Вова\Desktop\PR3\Store\Store\Views\_ViewImports.cshtml"
using Store.Data.Entities.PhoneAggregate;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Вова\Desktop\PR3\Store\Store\Views\_ViewImports.cshtml"
using Store;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b51499f37739defd26ef84cbba7df961408d8a1a", @"/Views/Search/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"80d495cd5f26a8757f357af146be0c90530f4a7e", @"/Views/_ViewImports.cshtml")]
    public class Views_Search_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Вова\Desktop\PR3\Store\Store\Views\Search\Index.cshtml"
  
    Layout = "_Layout";
    ViewData["Title"] = "Результаты поиска";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Результаты поиска</h1>\r\n\r\n");
#nullable restore
#line 8 "C:\Users\Вова\Desktop\PR3\Store\Store\Views\Search\Index.cshtml"
 if (Model.Count == 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Ничего не найдено.</p>\r\n");
#nullable restore
#line 11 "C:\Users\Вова\Desktop\PR3\Store\Store\Views\Search\Index.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <ul>\r\n");
#nullable restore
#line 15 "C:\Users\Вова\Desktop\PR3\Store\Store\Views\Search\Index.cshtml"
         foreach (Phone phone in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li><a");
            BeginWriteAttribute("href", " href=\"", 260, "\"", 319, 1);
#nullable restore
#line 17 "C:\Users\Вова\Desktop\PR3\Store\Store\Views\Search\Index.cshtml"
WriteAttributeValue("", 267, Url.Action("Index", "Phone", new { id = phone.Id }), 267, 52, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 17 "C:\Users\Вова\Desktop\PR3\Store\Store\Views\Search\Index.cshtml"
                                                                          Write(phone.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 17 "C:\Users\Вова\Desktop\PR3\Store\Store\Views\Search\Index.cshtml"
                                                                                      Write(phone.Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 18 "C:\Users\Вова\Desktop\PR3\Store\Store\Views\Search\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\r\n");
#nullable restore
#line 20 "C:\Users\Вова\Desktop\PR3\Store\Store\Views\Search\Index.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591

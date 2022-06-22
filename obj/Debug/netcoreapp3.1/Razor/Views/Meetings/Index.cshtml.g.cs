#pragma checksum "D:\Projects\OnlinePanelForProjectsControl\Views\Meetings\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a2748827a32d29ff1340760a7d1312fe55fa7bde"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Meetings_Index), @"mvc.1.0.view", @"/Views/Meetings/Index.cshtml")]
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
#line 2 "D:\Projects\OnlinePanelForProjectsControl\Views\_ViewImports.cshtml"
using OnlinePanelForProjectsControl.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Projects\OnlinePanelForProjectsControl\Views\_ViewImports.cshtml"
using OnlinePanelForProjectsControl.Service;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Projects\OnlinePanelForProjectsControl\Views\_ViewImports.cshtml"
using OnlinePanelForProjectsControl.Domain;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Projects\OnlinePanelForProjectsControl\Views\_ViewImports.cshtml"
using OnlinePanelForProjectsControl.Domain.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Projects\OnlinePanelForProjectsControl\Views\_ViewImports.cshtml"
using OnlinePanelForProjectsControl.Models.ViewComponents;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a2748827a32d29ff1340760a7d1312fe55fa7bde", @"/Views/Meetings/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5b4bc9956248d380512f6400dd477e135b966b48", @"/Views/_ViewImports.cshtml")]
    public class Views_Meetings_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IQueryable<Meeting>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Projects\OnlinePanelForProjectsControl\Views\Meetings\Index.cshtml"
  
    string strTitle = "Зустрічі";
    ViewBag.Title = strTitle;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n    <h2>");
#nullable restore
#line 8 "D:\Projects\OnlinePanelForProjectsControl\Views\Meetings\Index.cshtml"
   Write(strTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n    <div>\r\n");
#nullable restore
#line 10 "D:\Projects\OnlinePanelForProjectsControl\Views\Meetings\Index.cshtml"
         if (Model.Any())
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("        <div>\r\n");
#nullable restore
#line 14 "D:\Projects\OnlinePanelForProjectsControl\Views\Meetings\Index.cshtml"
             foreach (Meeting meet in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div>\r\n                <label>");
#nullable restore
#line 17 "D:\Projects\OnlinePanelForProjectsControl\Views\Meetings\Index.cshtml"
                  Write(meet.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label><br>\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 346, "\"", 362, 1);
#nullable restore
#line 18 "D:\Projects\OnlinePanelForProjectsControl\Views\Meetings\Index.cshtml"
WriteAttributeValue("", 353, meet.Url, 353, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\">Посилання зустрічі</a><br>\r\n                <label>Назначені користувачі:</label><br>\r\n");
#nullable restore
#line 20 "D:\Projects\OnlinePanelForProjectsControl\Views\Meetings\Index.cshtml"
                 foreach (Developer dev in meet.Devs)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <label>");
#nullable restore
#line 22 "D:\Projects\OnlinePanelForProjectsControl\Views\Meetings\Index.cshtml"
                      Write(dev.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n");
#nullable restore
#line 23 "D:\Projects\OnlinePanelForProjectsControl\Views\Meetings\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <br>\r\n                <label>Дата проведення зустрічі: ");
#nullable restore
#line 25 "D:\Projects\OnlinePanelForProjectsControl\Views\Meetings\Index.cshtml"
                                            Write(meet.DateOfMeet);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label><br>\r\n                <label>Опис зустрічі: ");
#nullable restore
#line 26 "D:\Projects\OnlinePanelForProjectsControl\Views\Meetings\Index.cshtml"
                                 Write(meet.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label><br>\r\n            </div>\r\n                <hr>\r\n");
#nullable restore
#line 29 "D:\Projects\OnlinePanelForProjectsControl\Views\Meetings\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n");
#nullable restore
#line 31 "D:\Projects\OnlinePanelForProjectsControl\Views\Meetings\Index.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <br />\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IQueryable<Meeting>> Html { get; private set; }
    }
}
#pragma warning restore 1591
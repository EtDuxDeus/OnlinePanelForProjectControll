#pragma checksum "D:\Projects\OnlinePanelForProjectsControl\Views\Shared\Components\UserList\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e02f3e43ff0b4fd0b96cbad56b1d85a58cc4942d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_UserList_Default), @"mvc.1.0.view", @"/Views/Shared/Components/UserList/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e02f3e43ff0b4fd0b96cbad56b1d85a58cc4942d", @"/Views/Shared/Components/UserList/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5b4bc9956248d380512f6400dd477e135b966b48", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_UserList_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IQueryable<Developer>>
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Projects\OnlinePanelForProjectsControl\Views\Shared\Components\UserList\Default.cshtml"
 if(Model?.Any() == true)
{
	

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Projects\OnlinePanelForProjectsControl\Views\Shared\Components\UserList\Default.cshtml"
     foreach(Developer entity in Model)
	{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e02f3e43ff0b4fd0b96cbad56b1d85a58cc4942d4261", async() => {
#nullable restore
#line 7 "D:\Projects\OnlinePanelForProjectsControl\Views\Shared\Components\UserList\Default.cshtml"
                              Write(entity.UserName);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 7 "D:\Projects\OnlinePanelForProjectsControl\Views\Shared\Components\UserList\Default.cshtml"
           WriteLiteral(entity.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 8 "D:\Projects\OnlinePanelForProjectsControl\Views\Shared\Components\UserList\Default.cshtml"
	}

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Projects\OnlinePanelForProjectsControl\Views\Shared\Components\UserList\Default.cshtml"
     
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IQueryable<Developer>> Html { get; private set; }
    }
}
#pragma warning restore 1591

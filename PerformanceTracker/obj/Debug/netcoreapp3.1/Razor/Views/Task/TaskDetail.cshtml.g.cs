#pragma checksum "C:\Users\m.erkan\Desktop\PerformanceTracker\PerformanceTracker\Views\Task\TaskDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "794b50f94d4f33d17d19fbb287c253e2c324d3c6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Task_TaskDetail), @"mvc.1.0.view", @"/Views/Task/TaskDetail.cshtml")]
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
#line 1 "C:\Users\m.erkan\Desktop\PerformanceTracker\PerformanceTracker\Views\_ViewImports.cshtml"
using PerformanceTracker;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\m.erkan\Desktop\PerformanceTracker\PerformanceTracker\Views\_ViewImports.cshtml"
using PerformanceTracker.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\m.erkan\Desktop\PerformanceTracker\PerformanceTracker\Views\Task\TaskDetail.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"794b50f94d4f33d17d19fbb287c253e2c324d3c6", @"/Views/Task/TaskDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1cb06c7dbdbf7554a043c9375f922900d04d133e", @"/Views/_ViewImports.cshtml")]
    public class Views_Task_TaskDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PerformanceTracker.ViewModels.TaskView>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CompleteTask", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\m.erkan\Desktop\PerformanceTracker\PerformanceTracker\Views\Task\TaskDetail.cshtml"
  
    ViewData["Title"] = "Group";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-10\">\r\n        <div class=\"row\">\r\n            <h5>");
#nullable restore
#line 11 "C:\Users\m.erkan\Desktop\PerformanceTracker\PerformanceTracker\Views\Task\TaskDetail.cshtml"
           Write(Model.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n        </div>\r\n        <div class=\"row\">\r\n            <p>");
#nullable restore
#line 14 "C:\Users\m.erkan\Desktop\PerformanceTracker\PerformanceTracker\Views\Task\TaskDetail.cshtml"
          Write(Model.Explanation);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n    </div>\r\n    <div class=\"col-2\">\r\n        <div class=\"row\"><h5>Start Date: </h5>");
#nullable restore
#line 18 "C:\Users\m.erkan\Desktop\PerformanceTracker\PerformanceTracker\Views\Task\TaskDetail.cshtml"
                                         Write(Model.StartDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        <div class=\"row\"> <h5>Due Date: </h5>");
#nullable restore
#line 19 "C:\Users\m.erkan\Desktop\PerformanceTracker\PerformanceTracker\Views\Task\TaskDetail.cshtml"
                                        Write(Model.DueDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"row\">\r\n    <div class=\"col\">\r\n");
#nullable restore
#line 25 "C:\Users\m.erkan\Desktop\PerformanceTracker\PerformanceTracker\Views\Task\TaskDetail.cshtml"
         foreach (var item in Model.TaskMembers)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\Users\m.erkan\Desktop\PerformanceTracker\PerformanceTracker\Views\Task\TaskDetail.cshtml"
             if (item.UserId == Context.Session.GetInt32("userid"))
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Users\m.erkan\Desktop\PerformanceTracker\PerformanceTracker\Views\Task\TaskDetail.cshtml"
           Write(item.Status.Value);

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "C:\Users\m.erkan\Desktop\PerformanceTracker\PerformanceTracker\Views\Task\TaskDetail.cshtml"
                 if (@item.Status.Id == 4)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"row\"> <p>Waiting for start date of this task to complete</p></div>\r\n");
#nullable restore
#line 34 "C:\Users\m.erkan\Desktop\PerformanceTracker\PerformanceTracker\Views\Task\TaskDetail.cshtml"
                }
                else if (@item.Status.Id == 1)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"row\"> <p>You have completed this task successfully.</p></div>\r\n");
#nullable restore
#line 38 "C:\Users\m.erkan\Desktop\PerformanceTracker\PerformanceTracker\Views\Task\TaskDetail.cshtml"
                }
                else if (@item.Status.Id == 2)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"row\"> <p>You have failed since you didn\'t complete this task on time.</p></div>\r\n");
#nullable restore
#line 42 "C:\Users\m.erkan\Desktop\PerformanceTracker\PerformanceTracker\Views\Task\TaskDetail.cshtml"
                }
                else if (@item.Status.Id == 3)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "794b50f94d4f33d17d19fbb287c253e2c324d3c68451", async() => {
                WriteLiteral("\r\n                        <div class=\"form-group\">\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "794b50f94d4f33d17d19fbb287c253e2c324d3c68791", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 47 "C:\Users\m.erkan\Desktop\PerformanceTracker\PerformanceTracker\Views\Task\TaskDetail.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.TaskId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 47 "C:\Users\m.erkan\Desktop\PerformanceTracker\PerformanceTracker\Views\Task\TaskDetail.cshtml"
                                                                    WriteLiteral(item.TaskId);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            <input type=\"submit\" value=\"Complete\" class=\"btn btn-success\" />\r\n                        </div>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 51 "C:\Users\m.erkan\Desktop\PerformanceTracker\PerformanceTracker\Views\Task\TaskDetail.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 51 "C:\Users\m.erkan\Desktop\PerformanceTracker\PerformanceTracker\Views\Task\TaskDetail.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 52 "C:\Users\m.erkan\Desktop\PerformanceTracker\PerformanceTracker\Views\Task\TaskDetail.cshtml"
             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>
</div>

<div class=""row"">
    <h5>Assigned Users</h5>
</div>
<div class=""row"">
    <table class=""table"">
        <thead>
            <tr>
                <th scope=""col"">User</th>
                <th scope=""col"">Email</th>
                <th scope=""col"">Status</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 70 "C:\Users\m.erkan\Desktop\PerformanceTracker\PerformanceTracker\Views\Task\TaskDetail.cshtml"
             foreach (var item in Model.TaskMembers)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 73 "C:\Users\m.erkan\Desktop\PerformanceTracker\PerformanceTracker\Views\Task\TaskDetail.cshtml"
                   Write(item.User.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 73 "C:\Users\m.erkan\Desktop\PerformanceTracker\PerformanceTracker\Views\Task\TaskDetail.cshtml"
                                        Write(item.User.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 74 "C:\Users\m.erkan\Desktop\PerformanceTracker\PerformanceTracker\Views\Task\TaskDetail.cshtml"
                   Write(item.User.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 75 "C:\Users\m.erkan\Desktop\PerformanceTracker\PerformanceTracker\Views\Task\TaskDetail.cshtml"
                   Write(item.Status.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 77 "C:\Users\m.erkan\Desktop\PerformanceTracker\PerformanceTracker\Views\Task\TaskDetail.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n\r\n<div class=\"row\">\r\n    ");
#nullable restore
#line 83 "C:\Users\m.erkan\Desktop\PerformanceTracker\PerformanceTracker\Views\Task\TaskDetail.cshtml"
Write(Html.ActionLink("Go To Group", "GroupDetail", "Group",
             new { groupId = Model.GroupId }, // giving parameter to IActionResult function
           null));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PerformanceTracker.ViewModels.TaskView> Html { get; private set; }
    }
}
#pragma warning restore 1591
#pragma checksum "C:\Users\CHall\Desktop\classwork-hall-charles\CourseManager\CourseManager\Views\Course\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5e30aba4e81da49ed7f578b69260da1cf3e46631"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Course_Edit), @"mvc.1.0.view", @"/Views/Course/Edit.cshtml")]
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
#line 1 "C:\Users\CHall\Desktop\classwork-hall-charles\CourseManager\CourseManager\Views\_ViewImports.cshtml"
using CourseManager;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\CHall\Desktop\classwork-hall-charles\CourseManager\CourseManager\Views\_ViewImports.cshtml"
using CourseManager.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e30aba4e81da49ed7f578b69260da1cf3e46631", @"/Views/Course/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86a0572f074d3b8a640e694913b8cb8b34518460", @"/Views/_ViewImports.cshtml")]
    public class Views_Course_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EditCourseViewModel>
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
#line 5 "C:\Users\CHall\Desktop\classwork-hall-charles\CourseManager\CourseManager\Views\Course\Edit.cshtml"
 using (Html.BeginForm("Edit", "Course", FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\CHall\Desktop\classwork-hall-charles\CourseManager\CourseManager\Views\Course\Edit.cshtml"
Write(Html.HiddenFor(m => m.ToEdit.Id));

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\CHall\Desktop\classwork-hall-charles\CourseManager\CourseManager\Views\Course\Edit.cshtml"
                                     ;

    

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\CHall\Desktop\classwork-hall-charles\CourseManager\CourseManager\Views\Course\Edit.cshtml"
Write(Html.LabelFor(m => m.ToEdit.Name));

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\CHall\Desktop\classwork-hall-charles\CourseManager\CourseManager\Views\Course\Edit.cshtml"
Write(Html.TextBoxFor(m => m.ToEdit.Name));

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\CHall\Desktop\classwork-hall-charles\CourseManager\CourseManager\Views\Course\Edit.cshtml"
                                        ;


#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n");
#nullable restore
#line 13 "C:\Users\CHall\Desktop\classwork-hall-charles\CourseManager\CourseManager\Views\Course\Edit.cshtml"

Teacher:
    

#line default
#line hidden
#nullable disable
            WriteLiteral("<select name=\"ToEdit.ClassTeacher.Id\">\r\n");
#nullable restore
#line 16 "C:\Users\CHall\Desktop\classwork-hall-charles\CourseManager\CourseManager\Views\Course\Edit.cshtml"
         foreach (var t in Model.AllTeachers)
        {
            if (t.Id == Model.ToEdit.ClassTeacher.Id)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5e30aba4e81da49ed7f578b69260da1cf3e466315181", async() => {
#nullable restore
#line 20 "C:\Users\CHall\Desktop\classwork-hall-charles\CourseManager\CourseManager\Views\Course\Edit.cshtml"
                                          Write(t.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 20 "C:\Users\CHall\Desktop\classwork-hall-charles\CourseManager\CourseManager\Views\Course\Edit.cshtml"
                   WriteLiteral(t.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 21 "C:\Users\CHall\Desktop\classwork-hall-charles\CourseManager\CourseManager\Views\Course\Edit.cshtml"

            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5e30aba4e81da49ed7f578b69260da1cf3e466317586", async() => {
#nullable restore
#line 25 "C:\Users\CHall\Desktop\classwork-hall-charles\CourseManager\CourseManager\Views\Course\Edit.cshtml"
                                 Write(t.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 25 "C:\Users\CHall\Desktop\classwork-hall-charles\CourseManager\CourseManager\Views\Course\Edit.cshtml"
                   WriteLiteral(t.Id);

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
#line 26 "C:\Users\CHall\Desktop\classwork-hall-charles\CourseManager\CourseManager\Views\Course\Edit.cshtml"
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </select>\r\n");
            WriteLiteral("    <br />\r\n");
#nullable restore
#line 32 "C:\Users\CHall\Desktop\classwork-hall-charles\CourseManager\CourseManager\Views\Course\Edit.cshtml"
     foreach (var s in Model.AllStudents)
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\CHall\Desktop\classwork-hall-charles\CourseManager\CourseManager\Views\Course\Edit.cshtml"
   Write(s.Name);

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\CHall\Desktop\classwork-hall-charles\CourseManager\CourseManager\Views\Course\Edit.cshtml"
               

        if (Model.ToEdit.ClassStudents.Any(inClass => inClass.Id == s.Id))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <input type=\"checkbox\" checked name=\"SelectedStudentIds\"");
            BeginWriteAttribute("value", " value=\"", 871, "\"", 884, 1);
#nullable restore
#line 38 "C:\Users\CHall\Desktop\classwork-hall-charles\CourseManager\CourseManager\Views\Course\Edit.cshtml"
WriteAttributeValue("", 879, s.Id, 879, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
#nullable restore
#line 39 "C:\Users\CHall\Desktop\classwork-hall-charles\CourseManager\CourseManager\Views\Course\Edit.cshtml"

        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <input type=\"checkbox\" name=\"SelectedStudentIds\"");
            BeginWriteAttribute("value", " value=\"", 988, "\"", 1001, 1);
#nullable restore
#line 43 "C:\Users\CHall\Desktop\classwork-hall-charles\CourseManager\CourseManager\Views\Course\Edit.cshtml"
WriteAttributeValue("", 996, s.Id, 996, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
#nullable restore
#line 44 "C:\Users\CHall\Desktop\classwork-hall-charles\CourseManager\CourseManager\Views\Course\Edit.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <br />\r\n");
#nullable restore
#line 46 "C:\Users\CHall\Desktop\classwork-hall-charles\CourseManager\CourseManager\Views\Course\Edit.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <button>Edit</button>\r\n");
#nullable restore
#line 49 "C:\Users\CHall\Desktop\classwork-hall-charles\CourseManager\CourseManager\Views\Course\Edit.cshtml"

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EditCourseViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

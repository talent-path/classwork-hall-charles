#pragma checksum "C:\Users\CHall\Desktop\classwork-hall-charles\CourseManager\CourseManager\Views\Course\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bbac490f60af6ee6c79d87ce14356fc1d21dc36f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Course_Details), @"mvc.1.0.view", @"/Views/Course/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bbac490f60af6ee6c79d87ce14356fc1d21dc36f", @"/Views/Course/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86a0572f074d3b8a640e694913b8cb8b34518460", @"/Views/_ViewImports.cshtml")]
    public class Views_Course_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Course>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 5 "C:\Users\CHall\Desktop\classwork-hall-charles\CourseManager\CourseManager\Views\Course\Details.cshtml"
Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1><br />\r\n<hr />\r\n<h2>");
#nullable restore
#line 7 "C:\Users\CHall\Desktop\classwork-hall-charles\CourseManager\CourseManager\Views\Course\Details.cshtml"
Write(Model.ClassTeacher.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n");
#nullable restore
#line 8 "C:\Users\CHall\Desktop\classwork-hall-charles\CourseManager\CourseManager\Views\Course\Details.cshtml"
 foreach( var s in Model.ClassStudents)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h3>");
#nullable restore
#line 10 "C:\Users\CHall\Desktop\classwork-hall-charles\CourseManager\CourseManager\Views\Course\Details.cshtml"
               Write(s.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3><br />\r\n");
#nullable restore
#line 11 "C:\Users\CHall\Desktop\classwork-hall-charles\CourseManager\CourseManager\Views\Course\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Course> Html { get; private set; }
    }
}
#pragma warning restore 1591

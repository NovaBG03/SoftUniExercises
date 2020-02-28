#pragma checksum "C:\Programming\SoftUniExercises\ASP.NET Core MVC\01. Introduction-to-ASP.NET-Core-MVC\CatExhibitionWebsite\CatWebsite\Views\Cat\Add.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7106bc4c97a63be7b7090cba02de9d7b5d2cf78f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cat_Add), @"mvc.1.0.view", @"/Views/Cat/Add.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7106bc4c97a63be7b7090cba02de9d7b5d2cf78f", @"/Views/Cat/Add.cshtml")]
    public class Views_Cat_Add : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CatWebsite.Models.AddCatViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Programming\SoftUniExercises\ASP.NET Core MVC\01. Introduction-to-ASP.NET-Core-MVC\CatExhibitionWebsite\CatWebsite\Views\Cat\Add.cshtml"
  
    ViewData["Title"] = "View";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Add</h1>

<hr />
<div class=""row"">
    <div class=""col-md-4"">
        <form asp-controller=""Cat"" asp-action=""Add"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
            <div class=""form-group"">
                <label asp-for=""Name"" class=""control-label"">Name</label>
                <input asp-for=""Name"" class=""form-control"" />
                <span asp-validation-for=""Name"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""Age"" class=""control-label"">Age</label>
                <input asp-for=""Age"" class=""form-control"" />
                <span asp-validation-for=""Age"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""Breed"" class=""control-label"">Breed</label>
                <input asp-for=""Breed"" class=""form-control"" />
                <span asp-validation-for=""Breed"" class=""text-danger""></span>
            </div>
 ");
            WriteLiteral(@"           <div class=""form-group"">
                <label asp-for=""ImageUrl"" class=""control-label"">Image Url</label>
                <input asp-for=""ImageUrl"" class=""form-control"" />
                <span asp-validation-for=""ImageUrl"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <input type=""submit"" value=""Add"" class=""btn btn-primary"" />
            </div>
        </form>
    </div>
</div>

<div>
    <a href=""/"">Back to List</a>
</div>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CatWebsite.Models.AddCatViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

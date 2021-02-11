using Acmion.CshtmlComponent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleRazorPagesApplication.Pages.Components.Example
{
    // The associated tag of the component.
    [HtmlTargetElement("ExampleComponent")]
    public class ExampleComponent : CshtmlComponentBase
    {
        // Explicitly named attribute.
        [HtmlAttributeName("Title")]
        public string Title { get; set; } = "";

        public ExampleComponent(IHtmlHelper htmlHelper) : base(htmlHelper)
        {
            // The constructor. 
            // Note: Only dependency injected arguments.

            // This component resolves the name of the associated .cshtml file automatically. 
            // The path to the .cshtml file must match the namespace and class name perfectly.

            // For this component the resolving logic is the following:
            //      Namespace = SampleRazorPagesApplication.Pages.Components.Example
            //      Class Name = ExampleComponent
            //
            //      1. Remove first part of namespace and replace dots with '/'. 
            //      2. Append a '/'.
            //      3. Append Class Name.
            //      4. Append ".cshtml".
            //      
            //      Associated .cshtml file = /Pages/Components/Example/ExampleComponent.cshtml
        }
    }
}

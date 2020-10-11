using Acmion.CshtmlComponent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleRazorPagesApplication
{
    // The associated tag of the component.
    [HtmlTargetElement("ExampleComponent")]
    public class ExampleComponent : CshtmlComponentBase
    {
        // Explicitly named attribute.
        [HtmlAttributeName("Title")]
        public string Title { get; set; } = "";

        public ExampleComponent(IHtmlHelper htmlHelper) : base(htmlHelper, "/Pages/Components/Example/ExampleComponent.cshtml", "div", TagMode.StartTagAndEndTag)
        {
            // The constructor. 
            // Note: Only dependency injected arguments.

            // "/Pages/Components/Example/ExampleComponent.cshtml" is the path to the associated .cshtml file.
            // "div" is the output tag name.
            // TagMode.StartTagAndEndTag determines the tag structure, optional parameter. Defaults to TagMode.StartTagAndEndTag.
        }
    }
}

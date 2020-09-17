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
        // These properties are explicitly named.
        [HtmlAttributeName("ItemCount")]
        public int ItemCount { get; set; } = 0;

        [HtmlAttributeName("ItemsPerPage")]
        public int ItemsPerPage { get; set; } = 0;

        [HtmlAttributeName("PrefixString")]
        public string PrefixString { get; set; } = "";

        // These properties will default to their kebabcased variants.
        public string FontSize { get; set; } = "1rem";
        public string BackgroundColor { get; set; } = "rgba(255, 0, 0, 0.1)";

        // A not HTML bound properties, that is can not be accessed as a attribute in the component tag.
        [HtmlAttributeNotBound]
        public int PageCount { get; set; } = 0;

        public ExampleComponent(IHtmlHelper htmlHelper) : base(htmlHelper, "/Pages/Components/Example/ExampleComponent.cshtml", "div", TagMode.StartTagAndEndTag)
        {
            // The constructor. 
            // Note: Only dependency injected arguments.

            // "/Pages/Components/Example/ExampleComponent.cshtml" is the path to the associated .cshtml file.
            // "div" is the output tag name.
            // TagMode.StartTagAndEndTag determines the tag structure, optional parameter. Defaults to TagMode.StartTagAndEndTag.

            // Properties should not be accessed here, because they will not yet be set.
        }

        protected override Task ProcessComponent()
        {
            // This method is called just before the associated .cshtml file is execute.
            // Properties have been initialized and can be accessed.

            // The property ChildContent is a string that contains the child content.

            // Use this method to edit some other properties or fields.

            PageCount = (int)Math.Ceiling((ItemCount + 0.0) / ItemsPerPage);

            return base.ProcessComponent();
        }
    }
}

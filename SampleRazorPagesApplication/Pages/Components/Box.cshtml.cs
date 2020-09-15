using Acmion.CshtmlComponent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleRazorPagesApplication.Pages.Components
{
    [HtmlTargetElement("Box")]
    public class Box : CshtmlComponentBase
    {
        public string FontSize { get; set; } = "1rem";
        public string BackgroundColor { get; set; } = "rgba(255, 0, 0, 0.1)";

        public Box(IHtmlHelper htmlHelper) : base(htmlHelper, "/Pages/Components/Box.cshtml", "div")
        {
        }
    }
}

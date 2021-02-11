using Acmion.CshtmlComponent;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleRazorPagesApplication.Pages.Components.Example
{
    [HtmlTargetElement("AdvancedExampleComponentTypedSlot")]
    public class AdvancedExampleComponentTypedSlot : CshtmlComponentSlot
    {
        public static string SlotName { get; } = "AdvancedExampleComponentTypedSlot";

        public AdvancedExampleComponentTypedSlot(IHtmlHelper htmlHelper) : base(htmlHelper)
        {
            Name = SlotName;
        }
    }
}

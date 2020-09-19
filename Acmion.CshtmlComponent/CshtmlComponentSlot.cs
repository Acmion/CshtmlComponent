using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Acmion.CshtmlComponent
{
    [HtmlTargetElement("CshtmlSlot")]
    public class CshtmlComponentSlot : CshtmlComponentBase
    {
        [HtmlAttributeName("Name")]
        public string Name { get; set; }

        public CshtmlComponentSlot(IHtmlHelper htmlHelper) : base(htmlHelper, null, null)
        {
            // Will be replaced when initialized
            Name = "";
        }

        protected override Task ProcessComponent(TagHelperContext context, TagHelperOutput output)
        {
            if (ParentComponent != null) 
            {
                ParentComponent.NamedSlots[Name] = ChildContent;
            }

            output.SuppressOutput();

            return base.ProcessComponent(context, output);
        }
    }
}

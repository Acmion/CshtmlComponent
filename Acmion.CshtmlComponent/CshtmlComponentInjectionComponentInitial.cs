using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Acmion.CshtmlComponent
{
    [HtmlTargetElement("CshtmlInitial")]
    public class CshtmlComponentInjectionComponentInitial : CshtmlComponentInjectionComponentBase
    {
        public CshtmlComponentInjectionComponentInitial(IHtmlHelper htmlHelper, ICshtmlComponentTracker cshtmlComponentTracker, ICshtmlComponentInjectionContentStore cshtmlComponentPostContentStore) : base(htmlHelper, cshtmlComponentTracker, cshtmlComponentPostContentStore)
        {
        }

        protected override Task ProcessComponent(TagHelperContext context, TagHelperOutput output)
        {
            if (Multiple)
            {
                output.Content.SetHtmlContent(ChildContent);
            }
            else if (!CshtmlComponentTracker.HasComponentTypeInjectedInitialContent(CshtmlComponentTrackerKey))
            {
                CshtmlComponentTracker.AddInjectedInitialContentComponentType(CshtmlComponentTrackerKey);

                output.Content.SetHtmlContent(ChildContent);
            }
            else 
            {
                output.SuppressOutput();
            }

            return base.ProcessComponent(context, output);
        }
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Acmion.CshtmlComponent
{
    [HtmlTargetElement("CshtmlBody")]
    public class CshtmlComponentInjectionComponentBody : CshtmlComponentInjectionComponentBase
    {
        [HtmlAttributeName("ContentOrder")]
        public int ContentOrder { get; set; } = int.MaxValue;

        public CshtmlComponentInjectionComponentBody(IHtmlHelper htmlHelper, ICshtmlComponentTracker cshtmlComponentTracker, ICshtmlComponentInjectionContentStore cshtmlComponentPostContentStore) : base(htmlHelper, cshtmlComponentTracker, cshtmlComponentPostContentStore)
        {
        }

        protected override Task ProcessComponent(TagHelperContext context, TagHelperOutput output)
        {
            if (Multiple)
            {
                CshtmlComponentInjectionContentStore.AddBodyInjectionContentItem(new CshtmlComponentInjectionContentItem(ContentOrder, ChildContent));
            }
            else 
            {
                if (!CshtmlComponentTracker.HasComponentTypeInjectedBodyContent(CshtmlComponentTrackerKey))
                {
                    CshtmlComponentTracker.AddInjectedBodyContentComponentType(CshtmlComponentTrackerKey);

                    CshtmlComponentInjectionContentStore.AddBodyInjectionContentItem(new CshtmlComponentInjectionContentItem(ContentOrder, ChildContent));
                }
            }

            output.SuppressOutput();

            return base.ProcessComponent(context, output);
        }
    }
}

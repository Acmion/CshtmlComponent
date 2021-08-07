using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Acmion.CshtmlComponent
{
    [HtmlTargetElement("CshtmlHead")]
    public class CshtmlComponentInjectionComponentHead : CshtmlComponentInjectionComponentBase
    {
        [HtmlAttributeName("ContentOrder")]
        public int ContentOrder { get; set; } = int.MaxValue;

        public CshtmlComponentInjectionComponentHead(IHtmlHelper htmlHelper, ICshtmlComponentTracker cshtmlComponentTracker, ICshtmlComponentInjectionContentStore cshtmlComponentPostContentStore) : base(htmlHelper, cshtmlComponentTracker, cshtmlComponentPostContentStore)
        {
        }

        protected override Task ProcessComponent(TagHelperContext context, TagHelperOutput output)
        {
            if (string.Equals(context.TagName, "head", StringComparison.OrdinalIgnoreCase))
            {
            }

            if (Multiple)
            {
                CshtmlComponentInjectionContentStore.AddHeadInjectionContentItem(new CshtmlComponentInjectionContentItem(ContentOrder, ChildContent));
            }
            else
            {
                if (!CshtmlComponentTracker.HasComponentTypeInjectedHeadContent(CshtmlComponentTrackerKey))
                {
                    CshtmlComponentTracker.AddInjectedHeadContentComponentType(CshtmlComponentTrackerKey);

                    CshtmlComponentInjectionContentStore.AddHeadInjectionContentItem(new CshtmlComponentInjectionContentItem(ContentOrder, ChildContent));
                }
            }

            output.SuppressOutput();

            return base.ProcessComponent(context, output);
        }
    }

}

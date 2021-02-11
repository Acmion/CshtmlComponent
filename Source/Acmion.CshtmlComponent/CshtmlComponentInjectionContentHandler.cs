using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acmion.CshtmlComponent
{
    public class CshtmlComponentInjectionContentHandler : TagHelperComponent
    {
        public override int Order { get; } = int.MaxValue;

        private ICshtmlComponentInjectionContentStore _cshtmlComponentPostContentStore;

        public CshtmlComponentInjectionContentHandler(ICshtmlComponentInjectionContentStore cshtmlComponentPostContentStore) 
        {
            _cshtmlComponentPostContentStore = cshtmlComponentPostContentStore;
        }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var currentCshtmlPostContentStoreItems = _cshtmlComponentPostContentStore.HeadInjectionContentItems;

            if(string.Equals(context.TagName, "body", StringComparison.OrdinalIgnoreCase))
            {
                currentCshtmlPostContentStoreItems = _cshtmlComponentPostContentStore.BodyInjectionContentItems;
            }

            foreach (var postHeadContentItem in currentCshtmlPostContentStoreItems.OrderBy(i => i.ContentOrder))
            {
                if (postHeadContentItem.ContentOrder < 0)
                {
                    output.PreContent.AppendHtml(postHeadContentItem.PostContent);
                }
                else
                {
                    output.PostContent.AppendHtml(postHeadContentItem.PostContent);
                }
            }

            return Task.CompletedTask;
        }
    }
}

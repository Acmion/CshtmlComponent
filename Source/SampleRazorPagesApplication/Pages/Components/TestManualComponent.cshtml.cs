using Acmion.CshtmlComponent;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SampleRazorPagesApplication.Pages.Components
{
    [HtmlTargetElement(nameof(TestManualComponent))]
    public class TestManualComponent : CshtmlComponentBase
    {
        [HtmlAttributeName(nameof(Title))]
        public string Title { get; set; } = "";

        [HtmlAttributeName(nameof(TitleLower))]
        public string TitleLower { get; set; } = "";


        public TestManualComponent(IHtmlHelper htmlHelper) : base(htmlHelper)
        {
        }

        protected override async Task ProcessComponent(TagHelperContext context, TagHelperOutput output)
        {
            TitleLower = Title.ToLowerInvariant();
        }
    }
}

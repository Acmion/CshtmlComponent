using CshtmlComponent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleRazorPagesApplication.Pages.Components
{
    [HtmlTargetElement("CaptionedImage")]
    public class CaptionedImage : CshtmlComponentBase
    {
        [HtmlAttributeName("ImgSrc")]
        public string ImgSrc { get; set; } = "";

        [HtmlAttributeName("Caption")]
        public string Caption { get; set; } = "";

        public CaptionedImage(IHtmlHelper htmlHelper) : base(htmlHelper, "/Pages/Components/CaptionedImage.cshtml", "div")
        {
        }

        protected override Task ProcessComponent()
        {
            return base.ProcessComponent();
        }
    }
}

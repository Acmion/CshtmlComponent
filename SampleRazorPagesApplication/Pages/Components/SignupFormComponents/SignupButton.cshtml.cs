using CshtmlComponent;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleRazorPagesApplication.Pages.Components.SignupFormComponents
{
    [HtmlTargetElement("SignupButton")]
    public class SignupButton : CshtmlComponentBase
    {
        [HtmlAttributeName("FontSize")]
        public string FontSize { get; set; } = "1rem";

        public SignupButton(IHtmlHelper htmlHelper) : base(htmlHelper, "/Pages/Components/SignupFormComponents/SignupButton.cshtml", "div")
        {
        }
    }
}

using Acmion.CshtmlComponent;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleRazorPagesApplication.Pages.Components.SignupFormComponents
{
    [HtmlTargetElement("SignupForm")]
    public class SignupForm : CshtmlComponentBase
    {
        [HtmlAttributeName("Action")]
        public string Action { get; set; } = "";

        public SignupForm(IHtmlHelper htmlHelper) : base(htmlHelper, "/Pages/Components/SignupFormComponents/SignupForm.cshtml", "div")
        {
        }
    }
}

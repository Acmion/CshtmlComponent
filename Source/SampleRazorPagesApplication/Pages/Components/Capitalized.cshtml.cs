using Acmion.CshtmlComponent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleRazorPagesApplication.Pages.Components
{
    [HtmlTargetElement("Capitalized")]
    public class Capitalized : CshtmlComponentBase
    {
        public Capitalized(IHtmlHelper htmlHelper) : base(htmlHelper, "/Pages/Components/Capitalized.cshtml", null)
        {
        }
    }
}

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
    [HtmlTargetElement("ObfuscatedEmail", TagStructure = TagStructure.WithoutEndTag)]
    public class ObfuscatedEmail : CshtmlComponentBase
    {
        public string Email { get; set; } = "";

        public ObfuscatedEmail(IHtmlHelper htmlHelper) : base(htmlHelper, "/Pages/Components/ObfuscatedEmail.cshtml", null)
        {
        }
    }
}

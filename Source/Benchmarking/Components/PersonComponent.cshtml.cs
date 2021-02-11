using Acmion.CshtmlComponent;
using Benchmarking.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benchmarking.Components
{
    [HtmlTargetElement("PersonComponent")]
    public class PersonComponent : CshtmlComponentBase
    {
        [HtmlAttributeName("Person")]
        public Person Person { get; set; } = null!;

        public PersonComponent(IHtmlHelper htmlHelper) : base(htmlHelper)
        {
        }
    }
}

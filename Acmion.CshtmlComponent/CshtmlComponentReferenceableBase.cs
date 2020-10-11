using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acmion.CshtmlComponent
{
    public abstract class CshtmlComponentReferenceableBase<ReferencableComponentType> : CshtmlComponentBase where ReferencableComponentType : CshtmlComponentReferenceableBase<ReferencableComponentType>
    {
        [HtmlAttributeName("Reference")]
        public CshtmlComponentReference<ReferencableComponentType> Reference 
        {
            get { return _reference; }
            set { _reference = value; value.Component = (ReferencableComponentType)this; }
        }

        private CshtmlComponentReference<ReferencableComponentType> _reference = null!;

        public CshtmlComponentReferenceableBase(IHtmlHelper htmlHelper, string? partialViewName, string? outputTagName, TagMode outputTagMode = TagMode.StartTagAndEndTag) : base(htmlHelper, partialViewName, outputTagName, outputTagMode)
        {
        }
    }
}

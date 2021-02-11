using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acmion.CshtmlComponent
{
    public abstract class CshtmlComponentInjectionComponentBase : CshtmlComponentBase
    {
        [HtmlAttributeName("Key")]
        public string Key { get; set; } = "";

        [HtmlAttributeName("Multiple")]
        public bool Multiple { get; set; } = false;

        [HtmlAttributeNotBound]
        public ICshtmlComponentTracker CshtmlComponentTracker { get; set; }
        
        [HtmlAttributeNotBound]
        public ICshtmlComponentInjectionContentStore CshtmlComponentInjectionContentStore { get; set; }

        [HtmlAttributeNotBound]
        public string CshtmlComponentTrackerKey => ViewContext.View.Path + "/" + Key;

        public CshtmlComponentInjectionComponentBase(IHtmlHelper htmlHelper, ICshtmlComponentTracker cshtmlComponentTracker, ICshtmlComponentInjectionContentStore cshtmlComponentInjectionContentStore) : base(htmlHelper, null, null)
        {
            CshtmlComponentTracker = cshtmlComponentTracker;
            CshtmlComponentInjectionContentStore = cshtmlComponentInjectionContentStore;
        }
    }
}

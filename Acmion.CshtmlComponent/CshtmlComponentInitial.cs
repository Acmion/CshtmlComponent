using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Acmion.CshtmlComponent
{
    [HtmlTargetElement("CshtmlInitial")]
    public class CshtmlComponentInitial : CshtmlComponentBase
    {
        [HtmlAttributeName("Context")]
        public CshtmlComponentBase Context { get; set; }

        private ICshtmlComponentTracker _cshtmlComponentCounter;


        // ICshtmlComponentTracker cshtmlComponentCounter must be dependency injected in Startup.cs
        public CshtmlComponentInitial(IHtmlHelper htmlHelper, ICshtmlComponentTracker cshtmlComponentCounter) : base(htmlHelper, null, null)
        {
            Context = null!;

            _cshtmlComponentCounter = cshtmlComponentCounter;
        }

        protected override Task ProcessComponent(TagHelperContext context, TagHelperOutput output)
        {
            var contextComponentType = Context.GetType();

            if (_cshtmlComponentCounter.HasComponentTypeBeenInstantiated(contextComponentType))
            {
                _cshtmlComponentCounter.AddInstantiatedComponentType(contextComponentType);

                output.Content.SetHtmlContent(ChildContent);
            }
            else 
            {
                output.SuppressOutput();
            }


            return base.ProcessComponent(context, output);
        }


    }
}

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Acmion.CshtmlComponent
{
    public abstract class CshtmlComponentBase : TagHelper
    {
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext 
        { 
            get { return _viewContext; } 
            set { SetViewContext(value); } 
        }

        [HtmlAttributeNotBound]
        public string PartialViewName { get; set; }

        [HtmlAttributeNotBound]
        public string? OutputTagName { get; set; }
        
        [HtmlAttributeNotBound]
        public TagMode OutputTagMode { get; set; }

        [HtmlAttributeNotBound]
        public string ChildContent { get; set; }

        private IHtmlHelper _htmlHelper;
        private ViewContext _viewContext;

        // IHtmlHelper htmlHelper is dependency injected by ASP.NET Core
        // string partialViewName should be provided by the class that implements CshtmlComponentBase
        // string outputTagName should be provided by the class that implements CshtmlComponentBase
        // TagMode outputTagMode determines the tag structure
        public CshtmlComponentBase(IHtmlHelper htmlHelper, string partialViewName, string? outputTagName, TagMode outputTagMode = TagMode.StartTagAndEndTag)
        {
            _htmlHelper = htmlHelper;
            PartialViewName = partialViewName;
            OutputTagName = outputTagName;
            OutputTagMode = outputTagMode;

            ChildContent = ""; // Will be replaced in ProcessAsync

            _viewContext = null!; // Will be replaced in SetViewContext
        }

        private void SetViewContext(ViewContext vc)
        {
            _viewContext = vc;

            ((IViewContextAware)_htmlHelper).Contextualize(ViewContext);
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            ChildContent = (await output.GetChildContentAsync()).GetContent();

            await ProcessComponent();

            var content = await _htmlHelper.PartialAsync(PartialViewName, this);

            output.TagName = OutputTagName;
            output.TagMode = OutputTagMode;
            output.Content.SetHtmlContent(content);
        }

        protected virtual Task ProcessComponent() 
        {
            return Task.CompletedTask;
        }
    }
}

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Acmion.CshtmlComponent
{
    public abstract class CshtmlComponentBase : TagHelper
    {
        private static string CshtmlComponentContextComponentStackKey { get; set; } = "CshtmlComponentContextComponentStack";
        private static Dictionary<Type, string> AutomaticallyGeneratedComponentPartialViewNames { get; set; } = new Dictionary<Type, string>();

        [HtmlAttributeNotBound]
        public IHtmlHelper HtmlHelper { get; }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext 
        { 
            get { return _viewContext; } 
            set { SetViewContext(value); } 
        }

        [HtmlAttributeNotBound]
        public string? PartialViewName { get; set; }

        [HtmlAttributeNotBound]
        public string? OutputTagName { get; set; }
        
        [HtmlAttributeNotBound]
        public TagMode OutputTagMode { get; set; }

        [HtmlAttributeNotBound]
        public string ChildContent { get; set; }

        [HtmlAttributeNotBound]
        public Dictionary<string, string> NamedSlots { get; set; } 

        [HtmlAttributeNotBound]
        public CshtmlComponentBase? ParentComponent { get; set; }

        private ViewContext _viewContext;

        public CshtmlComponentBase(IHtmlHelper htmlHelper)
        {
            HtmlHelper = htmlHelper;
            PartialViewName = GetAutomaticallyGeneratedPartialViewName();
            OutputTagName = null;
            OutputTagMode = TagMode.StartTagAndEndTag;

            // Will be replaced in ProcessAsync.
            ChildContent = "";

            // Will be populated by possible CshtmlComponentSlots.
            NamedSlots = new Dictionary<string, string>();

            // Will be replaced in Init.
            ParentComponent = null;

            // Will be replaced in SetViewContext.
            _viewContext = null!;
        }
        public CshtmlComponentBase(IHtmlHelper htmlHelper, string? partialViewName)
        {
            HtmlHelper = htmlHelper;
            PartialViewName = partialViewName;
            OutputTagName = null;
            OutputTagMode = TagMode.StartTagAndEndTag;

            // Will be replaced in ProcessAsync.
            ChildContent = "";

            // Will be populated by possible CshtmlComponentSlots.
            NamedSlots = new Dictionary<string, string>();

            // Will be replaced in Init.
            ParentComponent = null;

            // Will be replaced in SetViewContext.
            _viewContext = null!;
        }
        public CshtmlComponentBase(IHtmlHelper htmlHelper, string? partialViewName, string? outputTagName = null)
        {
            HtmlHelper = htmlHelper;
            PartialViewName = partialViewName;
            OutputTagName = outputTagName;
            OutputTagMode = TagMode.StartTagAndEndTag;

            // Will be replaced in ProcessAsync.
            ChildContent = "";

            // Will be populated by possible CshtmlComponentSlots.
            NamedSlots = new Dictionary<string, string>();

            // Will be replaced in Init.
            ParentComponent = null;

            // Will be replaced in SetViewContext.
            _viewContext = null!;
        }
        public CshtmlComponentBase(IHtmlHelper htmlHelper, string? partialViewName, string? outputTagName = null, TagMode outputTagMode = TagMode.StartTagAndEndTag)
        {
            // IHtmlHelper htmlHelper is dependency injected by ASP.NET Core
            // string partialViewName should be provided by the class that implements CshtmlComponentBase
            // string outputTagName should be provided by the class that implements CshtmlComponentBase
            // TagMode outputTagMode determines the tag structure

            HtmlHelper = htmlHelper;
            PartialViewName = partialViewName;
            OutputTagName = outputTagName;
            OutputTagMode = outputTagMode;

            // Will be replaced in ProcessAsync.
            ChildContent = "";

            // Will be populated by possible CshtmlComponentSlots.
            NamedSlots = new Dictionary<string, string>();

            // Will be replaced in Init.
            ParentComponent = null;

            // Will be replaced in SetViewContext.
            _viewContext = null!; 
        }

        public IHtmlContent Render()
        {
            return HtmlHelper.Partial(PartialViewName, this);
        }
        public Task<IHtmlContent> RenderAsync()
        {
            return HtmlHelper.PartialAsync(PartialViewName, this);
        }
        public string RenderToString(bool preserveLineBreaks = true)
        {
            var html = HtmlHelper.Partial(PartialViewName, this);

            using (var writer = new StringWriter())
            {
                html.WriteTo(writer, HtmlEncoder.Default);

                if (preserveLineBreaks)
                {
                    return writer.ToString();
                }
                else
                {
                    return writer.ToString().Replace("\n", "").Replace("\r", "");
                }
            }
        }
        public async Task<string> RenderToStringAsync(bool preserveLineBreaks = true)
        {
            var html = await HtmlHelper.PartialAsync(PartialViewName, this);

            using (var writer = new StringWriter())
            {
                html.WriteTo(writer, HtmlEncoder.Default);

                if (preserveLineBreaks)
                {
                    return writer.ToString();
                }
                else
                {
                    return writer.ToString().Replace("\n", "").Replace("\r", "");
                }
            }
        }

        protected virtual Task ProcessComponent(TagHelperContext context, TagHelperOutput output)
        {
            // Classes that inherit CshtmlComponentBase can override this method to edit properties etc.

            return Task.CompletedTask;
        }

        private void SetViewContext(ViewContext vc)
        {
            // Sets the ViewContext.
            // Called automatically by ASP.NET Core

            _viewContext = vc;

            ((IViewContextAware)HtmlHelper).Contextualize(ViewContext);
        }
        private string GetAutomaticallyGeneratedPartialViewName()
        {
            // Maybe use ConcurrentDictionary instead? 
            // However, AutomaticallyGeneratedComponentPartialViewNames is locked quite seldomly,
            // so maybe unnecessary.

            var type = GetType();

            if (AutomaticallyGeneratedComponentPartialViewNames.TryGetValue(type, out var autoGeneratedPartialViewName)) 
            {
                return autoGeneratedPartialViewName;
            }

            var partialViewName = "/" + string.Join('/', type.FullName!.Split('.').Skip(1)) + ".cshtml";

            lock (AutomaticallyGeneratedComponentPartialViewNames) 
            {
                AutomaticallyGeneratedComponentPartialViewNames[type] = partialViewName;
            }

            return partialViewName;
        }
        
        private Stack<CshtmlComponentBase> GetParentComponentStack(TagHelperContext context) 
        {
            return (context.Items[CshtmlComponentContextComponentStackKey] as Stack<CshtmlComponentBase>)!;
        }
        private void SetParentComponentStack(TagHelperContext context, Stack<CshtmlComponentBase> parentComponentStack)
        {
            context.Items[CshtmlComponentContextComponentStackKey] = parentComponentStack;
        }

        public override sealed void Init(TagHelperContext context)
        {
            // Initialize 

            if (!context.Items.ContainsKey(CshtmlComponentContextComponentStackKey))
            {
                var parentComponentStack = new Stack<CshtmlComponentBase>();

                ParentComponent = null;
                parentComponentStack.Push(this);

                SetParentComponentStack(context, parentComponentStack);
            }
            else 
            {
                var parentComponentStack = GetParentComponentStack(context);

                ParentComponent = parentComponentStack.Peek();

                parentComponentStack.Push(this);
            }

            base.Init(context);
        }
        public override sealed void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Method unoverridable in classes that inherit CshtmlComponentBase.

            base.Process(context, output);
        }
        public override sealed async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            // Process the component.
            // Method unoverridable in classes that inherit CshtmlComponentBase.

            ChildContent = (await output.GetChildContentAsync()).GetContent();

            await ProcessComponent(context, output);

            var parentComponentStack = GetParentComponentStack(context);
            parentComponentStack.Pop();

            output.TagName = OutputTagName;
            output.TagMode = OutputTagMode;

            if (PartialViewName != null) 
            {
                var content = await HtmlHelper.PartialAsync(PartialViewName, this);
                output.Content.SetHtmlContent(content);
            }
        }
        
    }
}

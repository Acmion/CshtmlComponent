# CshtmlComponent
CshtmlComponent - ASP.NET Core MVC and Razor Pages Component.

Using components in ASP.NET Core MVC or Razor Pages, out of the box, is annoying to say the least (read: a real PITA). Tag Helpers do not support Razor syntax, View Components can not access nested child content. Razor Components do not support runtime compilation and do not work too well in standard MVC or Razor Page projects. CshtmlComponent, from the perspective of an MVC or Razor Pages app, combines the best features of these technologies.

## Documentation
[http://cshtml-component.acmion.com](http://cshtml-component.acmion.com)



## Features
+ Razor Syntax
+ Nested Child Content
+ Runtime Compilation
+ MVC & Razor Pages
+ Lenient File Structure
+ Named Slots
+ Reference Capturing
+ One-Off Content [1]
+ Head Content Injection [2]
+ Body Content Injection [3]
+ Render to IHtmlContent
+ Render to String

[1] One-Off Content  
Component content that is rendered only for the first instantiated component.

[2] Head Content Injection  
Inject HTML content to the head tag from a component.

[3] Body Content Injection  
Inject HTML content to the body tag from a component.

## Installation & Usage
[https://cshtml-component.acmion.com/#usage](https://cshtml-component.acmion.com/#usage)

## Sample Component Usage
With CshtmlComponent one can define and use components like this. Note that this is a simple example and does not cover all the features of CshtmlComponent. Refer to the documentation for more information.

**ExampleComponent.cshtml.cs**
```
namespace SampleRazorPagesApplication.Pages.Components.Example
{
    // The associated tag of the component.
    [HtmlTargetElement("ExampleComponent")]
    public class ExampleComponent : CshtmlComponentBase
    {
        // Explicitly named attribute.
        [HtmlAttributeName("Title")]
        public string Title { get; set; } = "";

        public ExampleComponent(IHtmlHelper htmlHelper) : base(htmlHelper)
        {
            // The constructor. 
            // Note: Only dependency injected arguments.

            // This component resolves the name of the associated .cshtml file automatically. 
            // The path to the .cshtml file must match the namespace and class name perfectly.

            // For this component the resolving logic is the following:
            //      Namespace = SampleRazorPagesApplication.Pages.Components.Example
            //      Class Name = ExampleComponent
            //
            //      1. Remove first part of namespace and replace dots with '/'. 
            //      2. Append a '/'.
            //      3. Append Class Name.
            //      4. Append ".cshtml".
            //      
            //      Associated .cshtml file = /Pages/Components/Example/ExampleComponent.cshtml
        }
    }
}
```

**ExampleComponent.cshtml**
```
@* Reference the associated component as model. *@
@using SampleRazorPagesApplication.Pages.Components.Example
@model ExampleComponent

<!-- The content of the component. -->
<div class="example-component" style="border: medium solid rgba(0, 0, 0, 0.1); padding: 1rem;">
    <h1>
        ExampleComponent: @Model.Title
    </h1>

    <div class="example-component-child-content">
        <!-- Render the child content. -->
        @Html.Raw(Model.ChildContent)
    </div>
</div>
```

**Instantiating the Component**
```
<ExampleComponent Title="Some title">
    <div>
        Some custom HTML content.
        <Box>
            Supports nested components.
        </Box>
    </div>
</ExampleComponent>
```

## Video Demonstration
A simple video demonstration of CshtmlComponent can be found here: [https://www.youtube.com/watch?v=T608th58dJM](https://www.youtube.com/watch?v=T608th58dJM). Skip to 11:50 for the visual results.

## Sample Project
1. Clone this repository.
2. Start `SampleRazorPageApplication`.
3. `SampleRazorPageApplication/Pages/Index.cshtml` uses several components.
4. The components are defined in `SampleRazorPageApplication/Pages/Components`.
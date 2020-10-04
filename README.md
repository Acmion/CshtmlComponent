# CshtmlComponent
CshtmlComponent - ASP.NET Core MVC and Razor Pages Component.

## Documentation
[http://cshtml-component.acmion.com](http://cshtml-component.acmion.com)

## Sample Component Usage
With CshtmlComponent one can instantiate components like this:

```
<ExampleComponent Title="Some title" font-size="1.2rem" background-color="rgba(0, 0, 255, 0.1)">
    <div>
        Some custom HTML content.

        @{
            var boxReference = new CshtmlComponentReference<Box>();
        }
        <Box Reference="boxReference">
            Supports nested components.
        </Box>

        The fontsize of the referenced box is: @boxReference.Component.FontSize
    </div>
    <CshtmlSlot Name="SlotName0">
        Some custom HTML content within a named slot. The parent component decides where
        this content is placed. Slots can also be typed.
    </CshtmlSlot>
    <CshtmlSlot Name="SlotName1">
        Additional custom HTML content within a second named slot.
        <Box>
            Supports nested components.
        </Box>
    </CshtmlSlot>
</ExampleComponent>
```

## Sample Project
1. Clone this repository.
2. Start `SampleRazorPageApplication`.
3. `SampleRazorPageApplication/Pages/Index.cshtml` uses several components.
4. The components are defined in `SampleRazorPageApplication/Pages/Components`.
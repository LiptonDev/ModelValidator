# ModelValidator

## Example model:
```C#
public class ExampleModel : ModelValidatorBase
{
    /// <summary>
    /// Example string.
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = "Input text")]
    [StringLength(maximumLength: 10, MinimumLength = 4, ErrorMessage = "Min length: {1}, max length: {0}")]
    public string ExampleString { get; set; }

    /// <summary>
    /// Example int.
    /// </summary>
    [Range(minimum: 5, maximum: 10, ErrorMessage = "Min value: {0}, max value: {1}")]
    public int ExampleInt { get; set; }
}
```

Binding example:
```XAML
<StackPanel>
    <TextBox Text="{Binding TestModel.ExampleString, UpdateSourceTrigger=PropertyChanged, ValidatesOnDataErrors=True}"/>
    <TextBox Text="{Binding TestModel.ExampleInt, UpdateSourceTrigger=PropertyChanged, ValidatesOnDataErrors=True}"/>
</StackPanel>
```

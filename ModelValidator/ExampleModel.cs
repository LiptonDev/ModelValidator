using System.ComponentModel.DataAnnotations;

namespace $rootnamespace$.Models
{
    /// <summary>
    /// Example model.
    /// </summary>
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
}

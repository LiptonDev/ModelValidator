using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace $rootnamespace$.Models
{
    /// <summary>
    /// Model validator.
    /// </summary>
    public abstract class ModelValidatorBase : IDataErrorInfo
    {
        /// <summary>
        /// Current type.
        /// </summary>
        Type currentType;

        /// <summary>
        /// Constructor.
        /// </summary>
        public ModelValidatorBase()
        {
            currentType = GetType();
        }

        /// <summary>
        /// Gets property value by name.
        /// </summary>
        /// <param name="propName">Property name.</param>
        /// <returns></returns>
        private object GetPropertyValue(string propName) => currentType.GetProperty(propName).GetValue(this);

        /// <summary>
        /// All errors in model.
        /// </summary>
        public string Error => string.Join(Environment.NewLine, GetValidationErrors());

        /// <summary>
        /// Returns valid status.
        /// </summary>
        public bool IsValid => !GetValidationErrors().Any();

        /// <summary>
        /// Gets error text by property name.
        /// </summary>
        /// <param name="propName">Property name.</param>
        /// <returns></returns>
        public string this[string propName] => GetValidationError(propName);

        /// <summary>
        /// Gets error text by property name.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        /// <returns></returns>
        protected string GetValidationError(string propertyName)
        {
            string error = string.Empty;
            var context = new ValidationContext(this) { MemberName = propertyName };
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateProperty(GetPropertyValue(propertyName), context, results))
            {
                error = results.First().ErrorMessage;
            }

            return error;
        }

        /// <summary>
        /// Returns all errors in model.
        /// </summary>
        protected IEnumerable<ValidationResult> GetValidationErrors()
        {
            var context = new ValidationContext(this);
            var results = new List<ValidationResult>();

            Validator.TryValidateObject(this, context, results, true);

            return results;
        }
    }
}

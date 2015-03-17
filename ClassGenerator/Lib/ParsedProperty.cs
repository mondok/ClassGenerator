using System;

namespace ClassGenerator.Lib
{
    /// <summary>
    /// Temporary holding spot for parsed properties
    /// </summary>
    public class ParsedProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParsedProperty"/> class.
        /// </summary>
        /// <param name="propStr">The property string in the format propertyName:propertyType.</param>
        public ParsedProperty(string propStr)
        {
            var broken = propStr.Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            this.PropertyName = broken[0];
            if (broken.Length == 2)
            {
                this.PropertyType = broken[1];
            }

        }

        /// <summary>
        /// Gets the type of the property. 
        /// Used to set a default if PropertyType is null
        /// </summary>
        /// <param name="defaultType">The default type.</param>
        /// <returns>System.String.</returns>
        public string GetPropertyType(string defaultType = "")
        {
            return this.PropertyType ?? defaultType;
        }

        /// <summary>
        /// Gets or sets the name of the property.
        /// </summary>
        /// <value>The name of the property.</value>
        public string PropertyName { get; set; }

        /// <summary>
        /// Gets or sets the type of the property.
        /// </summary>
        /// <value>The type of the property.</value>
        public string PropertyType { get; set; }
    }
}
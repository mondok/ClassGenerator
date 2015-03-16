using System;
using System.Linq;
using System.Text;
using ClassGenerator.Lib;

namespace ClassGenerator.Languages
{
    /// <summary>
    /// Generator for C# language
    /// </summary>
    public class CsharpGenerator : IClassGenerator
    {
        /// <summary>
        /// Gets the name of the generator (the language).
        /// </summary>
        /// <value>The name of the generator.</value>
        public string GeneratorName
        {
            get { return "C#"; }
        }

        /// <summary>
        /// Generates the class to a string
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="scaffoldText">The scaffold text.</param>
        /// <returns>System.String.</returns>
        public string GenerateClass(string className, string scaffoldText)
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("public class {0}", className);
            output.AppendLine("{");
            var properties =
                scaffoldText.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => new ParsedProperty(s));
            foreach (var property in properties)
            {
                output.AppendFormat("\tpublic {0} {1} {{ get;set; }}", property.PropertyType, property.PropertyName);
                output.AppendLine();
            }
            output.AppendLine("}");
            return output.ToString();
        }
    }
}
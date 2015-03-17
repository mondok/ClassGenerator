using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassGenerator.Lib
{
    /// <summary>
    /// Useful extension methods
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Creates a properly named CSharp property
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string CsharpifyProperty(this string value)
        {
            if (string.IsNullOrEmpty(value)) return String.Empty;
            string output = String.Empty;
            string okProps = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            bool upperNext = false;

            for(int i = 0; i < value.Length; i++)
            {
                char c = value[i];
                if (i == 0)
                {
                    output = c.ToString().ToUpper();
                }
                else
                {
                    if (okProps.Any(s => s == c))
                    {
                        output += upperNext ? c.ToString().ToUpper() : c.ToString();
                        upperNext = false;
                    }
                    else
                    {
                        upperNext = true;
                    }
                }
            }
            return output;
        }
    }
}

namespace ClassGenerator.Languages
{
    /// <summary>
    /// Class generator interface.  Implement this to 
    /// generate a class for a new language.  Don't use
    /// custom constructors, though.  Right now we need an 
    /// empty constructor for Activator
    /// </summary>
    public interface IClassGenerator
    {
        /// <summary>
        /// Gets the name of the generator.
        /// </summary>
        /// <value>The name of the generator.</value>
        string GeneratorName { get; }

        /// <summary>
        /// Generates the class.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="scaffoldText">The scaffold text.</param>
        /// <returns>System.String.</returns>
        string GenerateClass(string className, string scaffoldText);
    }
}
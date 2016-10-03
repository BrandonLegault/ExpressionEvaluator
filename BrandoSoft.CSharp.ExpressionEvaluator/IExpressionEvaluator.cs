namespace BrandoSoft.CSharp
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines methods to be implemented to evaluate C# expressions during runtime.
    /// </summary>
    public interface IExpressionEvaluator
    {
        /// <summary>
        /// A list of assemblies that the evaluator is currently referencing.
        /// </summary>
        IReadOnlyCollection<string> ReferencedAssemblies { get; }

        /// <summary>
        /// A list of using directives that've been added to the evaluator.
        /// </summary>
        IReadOnlyCollection<string> ImportedNamespaces { get; }

        /// <summary>
        /// Adds a reference to a .NET assembly to this expression evaluator
        /// </summary>
        /// <param name="fullAssemblyName">The name of the assembly to add to the list.</param>
        void AddAssemblyReference(string fullAssemblyName);

        /// <summary>
        /// Imports a collection of namespaces.
        /// </summary>
        /// <param name="usingDirectives"></param>
        void ImportNamespaces(IEnumerable< string > usingDirectives);

        /// <summary>
        /// Makes the IExpressionEvaluator aware of an instantiated .NET object so it can be evaluated.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="instanceName"></param>
        void AddInstancedObject<T>(T instance, string instanceName);

        /// <summary>
        /// Evaluates or applies any valid C# expression and returns its output.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        string Evaluate(string expression);

    }


}
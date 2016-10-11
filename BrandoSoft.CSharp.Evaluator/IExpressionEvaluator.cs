/*
    MIT License

    Copyright (c) 2016 BrandonLegault

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in all
    copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    SOFTWARE. 
 */
namespace BrandoSoft.CSharp.Evaluator
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
        /// Reports errors, if any, in the most-recently executed operation.
        /// </summary>
        string LastOperationErrors { get; }

        /// <summary>
        /// Adds a reference to a .NET assembly to this expression evaluator
        /// </summary>
        /// <param name="fullAssemblyName">The name of the assembly to add to the list.</param>
        void AddAssemblyReference(string fullAssemblyName);

        /// <summary>
        /// Imports a collection of namespaces.
        /// </summary>
        /// <param name="usingDirectives"></param>
        void ImportNamespaces(IEnumerable<string> usingDirectives);

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

        IEnumerable< string > GetCompletions(string expression);
    }
}
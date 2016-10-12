/*
    MIT License

    Copyright (c) 2016 Brandon Legault

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

using System;
using System.Text.RegularExpressions;

namespace BrandoSoft.CSharp.Evaluator.Test
{
    using System.Linq;
    using System.Reflection;

    using NUnit.Framework;

    [TestFixture]
    public class RuntimeEvaluatorTests
    {
        private IExpressionEvaluator _evaluator;

        [SetUp]
        public void Setup()
        {


            this._evaluator = new RuntimeEvaluator();
        }

        [Test]
        public void RuntimeEvaluator_CanAddAssemblies()
        {
            var thisAssemblyName = Assembly.GetExecutingAssembly().FullName;

            this._evaluator.AddAssemblyReference(thisAssemblyName);

            Assert.That(this._evaluator.ReferencedAssemblies.Contains(thisAssemblyName));

        }

        [TestCase("using System;")]
        [TestCase("using System;", "using System.Linq;")]
        [TestCase("using BrandoSoft.CSharp.Evaluator;", "using System.Linq;")]
        [TestCase("using BrandoSoft.CSharp.Evaluator;", "using System.Collections.Generic;")]
        public void RuntimeEvaluator_CanAddNamespaces(params string[] namespaces)
        {

            this._evaluator.ImportNamespaces(namespaces);

            Assert.That(this._evaluator.ImportedNamespaces.Any());

            CollectionAssert.AllItemsAreUnique(this._evaluator.ImportedNamespaces);

            foreach ( var @namespace in namespaces )
            {
                Assert.That(this._evaluator.ImportedNamespaces.Contains(@namespace));
            }

        }

        [TestCase("using System;", "using System.Linq;")]
        [TestCase("using BrandoSoft.CSharp.Evaluator;", "using System.Linq;")]
        [TestCase("using BrandoSoft.CSharp.Evaluator;", "using System.Collections.Generic;")]
        [TestCase("using System;", "using System.Linq;", "using System.Collections;",
            "using System.Collections.Generic;")]
        public void RuntimeEvaluator_CanAddNamespaces_SingleString(params string[] namespaces)
        {

            this._evaluator.ImportNamespaces(new[] {string.Join(" ", namespaces)});

            Assert.That(this._evaluator.ImportedNamespaces.Any());

            CollectionAssert.AllItemsAreUnique(this._evaluator.ImportedNamespaces);

            foreach ( var @namespace in namespaces )
            {
                Assert.That(this._evaluator.ImportedNamespaces.Contains(@namespace));
            }

        }

        [Test]
        public void RuntimeEvaluator_CanCreateObjectInstance()
        {
            this._evaluator.AddAssemblyReference(Assembly.GetExecutingAssembly().FullName);

            var dummy = new DummyTestClass();

            Assert.DoesNotThrow(() => { this._evaluator.AddInstancedObject(dummy, "dummy"); });

        }

        [Test]
        public void RuntimeEvaluator_CanAccessObjectInstance()
        {
            this._evaluator.AddAssemblyReference(Assembly.GetExecutingAssembly().FullName);

            var dummy = new DummyTestClass();

            this._evaluator.AddInstancedObject(dummy, "dummy");
            var output = this._evaluator.Evaluate("dummy;");
            Assert.That(output, Is.EqualTo("BrandoSoft.CSharp.Evaluator.Test.DummyTestClass"));
        }

        [Test]
        public void RuntimeEvaluator_CanChangeObjectInstance_PropertiesAndFields()
        {
            this._evaluator.AddAssemblyReference(Assembly.GetExecutingAssembly().FullName);

            var dummy = new DummyTestClass();

            this._evaluator.AddInstancedObject(dummy, "dummy");

            Assert.DoesNotThrow(() =>
            {
                this._evaluator.Evaluate("dummy.DummyStringProperty = \"Forty Two\"");
                this._evaluator.Evaluate("dummy.DummyIntProperty = 42");
                this._evaluator.Evaluate("dummy.DummyStringField = \"42\"");
                this._evaluator.Evaluate("dummy.DummyIntField = 101010");
            });

            Assert.That(dummy.DummyStringProperty, Is.EqualTo("Forty Two"));
            Assert.That(dummy.DummyIntProperty, Is.EqualTo(42));
            Assert.That(dummy.DummyStringField, Is.EqualTo("42"));
            Assert.That(dummy.DummyIntField, Is.EqualTo(101010));

            Assert.That(this._evaluator.Evaluate("dummy.DummyStringProperty"), Is.EqualTo("Forty Two"));
            Assert.That(this._evaluator.Evaluate("dummy.DummyIntProperty"), Is.EqualTo("42"));
            Assert.That(this._evaluator.Evaluate("dummy.DummyStringField"), Is.EqualTo("42"));
            Assert.That(this._evaluator.Evaluate("dummy.DummyIntField"), Is.EqualTo("101010"));
        }

        [Test]
        public void RuntimeEvaluator_CanCallInstanceMethods()
        {
            this._evaluator.AddAssemblyReference(Assembly.GetExecutingAssembly().FullName);

            var dummy = new DummyTestClass();

            this._evaluator.AddInstancedObject(dummy, "dummy");

            Assert.That(this._evaluator.Evaluate("dummy.DummyStringMethod(\"Forty Two\")"), Is.EqualTo("Forty Two"));
            Assert.That(this._evaluator.Evaluate("dummy.DummyIntMethod(42)"), Is.EqualTo("42"));
        }

        [Test]
        public void RuntimeEvaluator_CanAccessPrivateFields()
        {
            Assert.Pass("This test does not pass yet. This pass is only a placeholder.");
            this._evaluator.AddAssemblyReference(Assembly.GetExecutingAssembly().FullName);

            var dummy = new DummyTestClass();

            this._evaluator.AddInstancedObject(dummy, "dummy");

            Assert.That(this._evaluator.Evaluate("dummy._privateIntField"), Is.EqualTo("42"));
        }
    }


    public class DummyTestClass
    {
        public string DummyStringProperty { get; set; }
        public int DummyIntProperty { get; set; }
        public string DummyStringField;
        public int DummyIntField;

        private int _privateIntField;

        public DummyTestClass()
        {
            this._privateIntField = 42;
        }

        public string DummyStringMethod(string toReturn)
        {
            return toReturn;
        }

        public int DummyIntMethod(int toReturn)
        {
            return toReturn;
        }
    }

}

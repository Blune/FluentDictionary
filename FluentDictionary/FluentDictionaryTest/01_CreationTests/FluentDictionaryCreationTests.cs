using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace FluentDictionaryTest._01_CreationTests
{
    [TestClass]
    public class FluentDictionaryCreationsTests
    {
        [TestMethod]
        public void CreateAFluentDictionaryTest()
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            Assert.IsNotNull(FluentDictionary.FluentDictionary.For(dictionary), "FluentDictionary was not created");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateAFluentDictionaryWithNullAndExpectExceptionTest()
        {
            Dictionary<string, object> dictionary = null;
            Assert.IsNull(FluentDictionary.FluentDictionary.For(dictionary), "FluentDictionary was created with null");
        }
    }
}

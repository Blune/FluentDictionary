using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FluentDictionaryTest._02_GetValuesTests
{
    [TestClass]
    public class GetValueTests
    {
        private enum TestEnumeration
        {
            Key1,
            Key2,
            Key3,
            NotUsed,
            Nothing
        }

        private readonly Dictionary<string, object> resultDictionary = new Dictionary<string, object>()
        {
            {"Key1", 1.0},
            {"Key2", 2.0},
            {"Key3", 3.0},
            {"Key4", 4.0},
            {"Key5", 5.0},
            {"Key6", 6.0},
            {"Key7", 7.0},
            {"Key8", 8.0},
            {"Nothing", null},

        };

        [TestMethod]
        public void GetSingleValue()
        {
            var result = FluentDictionary.FluentDictionary
                    .For(resultDictionary)
                        .Get("Key3")
                        .As<double>();

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void GetValueWithMultipleFallbacks()
        {
            var result = FluentDictionary.FluentDictionary
                .For(resultDictionary)
                    .Get("Nothing")
                    .Or("Key3")
                    .As<double>();

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void GetSingleValueAndThenSingleValue()
        {
            var result = FluentDictionary.FluentDictionary
                    .For(resultDictionary)
                        .Get("Key1")
                        .Or("Key3")
                        .As<double>();

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GetNullValueAndThenNullValueAndThenResult()
        {
            var result = FluentDictionary.FluentDictionary
                .For(resultDictionary)
                    .Get("Nothing")
                    .Or("Nothing")
                    .As<double>();

            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void GetNullValueAndThenNullValueAndThenResultWithDefaultValue()
        {
            var result = FluentDictionary.FluentDictionary
                .For(resultDictionary)
                    .Get("Nothing")
                    .Or("Nothing")
                    .As<double>(0.0);

            Assert.AreEqual(0.0, result);
        }

        [TestMethod]
        public void GetEnumValue()
        {
            var result = FluentDictionary.FluentDictionary
                .For(resultDictionary)
                    .Get(TestEnumeration.Key1)
                    .As<double>(0.0);

            Assert.AreEqual(1.0, result);
        }

        [TestMethod]
        public void GetEnumValueWithFallback()
        {
            var result = FluentDictionary.FluentDictionary
                .For(resultDictionary)
                    .Get(TestEnumeration.NotUsed)
                    .Or(TestEnumeration.Key1)
                    .As<double>(0.0);

            Assert.AreEqual(1.0, result);
        }
    }
}
